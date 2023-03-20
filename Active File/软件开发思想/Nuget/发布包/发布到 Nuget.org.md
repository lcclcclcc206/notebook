创建 NuGet 包并具有 *.nupkg* 文件后，可以公开或私下向其他开发人员提供该包。 本文介绍如何通过 [nuget.org](https://www.nuget.org/packages/manage/upload) 全局共享公共包。

还可以通过将专用包托管在文件共享、专用 NuGet 服务器或第三方存储库（如 myget、ProGet、Nexus 存储库或 Artifactory）上，使专用包仅可供团队或组织使用。 有关详细信息，请参阅 [托管自己的 NuGet 源](https://learn.microsoft.com/zh-cn/nuget/hosting-packages/overview)。 有关使用 [Azure Artifacts](https://www.visualstudio.com/docs/package/nuget/publish) 进行发布，请参阅 [将包发布到 NuGet.org](https://learn.microsoft.com/zh-cn/azure/devops/artifacts/nuget/publish-to-nuget-org)。



## 发布到 nuget.org

若要在 nuget.org 上发布，请使用 Microsoft 帐户登录到 nuget.org，然后使用该帐户创建免费的 nuget.org 帐户。 按照 [添加新的个人帐户](https://learn.microsoft.com/zh-cn/nuget/nuget-org/individual-accounts#add-a-new-individual-account)中的说明进行操作。

![显示 NuGet 登录链接的屏幕截图。](https://learn.microsoft.com/zh-cn/nuget/nuget-org/media/publish-nuget-signin.png)

拥有帐户后，可以使用 nuget.org Web 门户、dotnet CLI 或 NuGet CLI 4.1.0 或更高版本将包发布到 nuget.org。 还可以通过 Azure Pipelines 发布包。

### 上传到 nuget.org Web 门户

若要将包上传到 nuget.org 网站，请执行以下操作：

1. 在 nuget.org 顶部菜单中选择 **“上传** ”，浏览到计算机上的包，然后选择“ **打开**”。

   ![显示 nuget.org 上的“上传”对话框的屏幕截图](https://learn.microsoft.com/zh-cn/nuget/nuget-org/media/publish-upload-package.png)

   如果 nuget.org 上已存在包 ID，则会收到错误。 更改项目中的包标识符，重新打包，然后重试上传。

2. 如果包名称可用，将打开 **“验证** ”部分，以便你可以查看包清单中的元数据。 如果包中包含 [自述文件](https://learn.microsoft.com/zh-cn/nuget/nuget-org/package-readme-on-nuget-org) ，请选择“ **预览** ”以确保所有内容正确呈现。

   若要更改任何元数据，请编辑项目文件或 *.nuspec* 文件，重新生成、重新打包并再次上传。

3. 所有信息准备就绪后，选择“ **提交**”。

### 使用命令行推送

若要使用命令行将包推送到 nuget.org，可以使用 `dotnet.exe` 或 `nuget.exe` v4.1.0 或更高版本，它们可实现所需的 NuGet 协议。 有关详细信息，请参阅 [NuGet 协议](https://learn.microsoft.com/zh-cn/nuget/api/nuget-protocols)。

若要使用任一命令行，首先需要从 nuget.org 获取 API 密钥。

#### 创建 API 密钥

1. [登录到 nuget.org 帐户](https://www.nuget.org/users/account/LogOn?returnUrl=%2F) ，或者 [创建一个帐户](https://learn.microsoft.com/zh-cn/nuget/nuget-org/individual-accounts#add-a-new-individual-account) （如果还没有帐户）。
2. 选择右上角的用户名，然后选择“ **API 密钥**”。
3. 选择“ **创建**”，并提供密钥的名称。
4. 在 **“选择范围”下**，选择“ **推送**”。
5. 在 **“选择包**>**Glob 模式”**下，输入*。
6. 选择“创建”。
7. 选择“ **复制** ”以复制新密钥。

![显示包含“复制”链接的新 API 密钥的屏幕截图。](https://learn.microsoft.com/zh-cn/nuget/quickstart/media/qs-create-api-key.png)

> - 始终将 API 密钥保密。 API 密钥类似于密码，允许任何人代表你管理包。 如果意外泄露了 API 密钥，请删除或重新生成该密钥。
> - 将密钥保存在安全位置，因为以后无法再次复制密钥。 如果返回到 API 密钥页，则需要重新生成密钥以对其进行复制。 如果你不再希望推送包，还可以删除 API 密钥。

*通过范围确定* ，可以创建用于不同用途的单独 API 密钥。 每个密钥都有一个过期时间范围，你可以将密钥的范围限定为特定的包或 glob 模式。 还将每个密钥的范围限定为特定操作：推送新包和包版本、仅推送新包版本或取消列出。

通过确定范围，可以为管理组织包的不同人员创建 API 密钥，以便他们仅拥有所需的权限。

有关详细信息，请参阅[范围内的 API 密钥](https://learn.microsoft.com/zh-cn/nuget/nuget-org/scoped-api-keys)。

#### 使用 dotnet CLI

从包含 *.nupkg* 文件的文件夹运行以下命令。 指定 *.nupkg* 文件名，并将密钥值替换为 API 密钥。

```dotnetcli
dotnet nuget push Contoso.08.28.22.001.Test.1.0.0.nupkg --api-key qz2jga8pl3dvn2akksyquwcs9ygggg4exypy3bhxy6w6x6 --source https://api.nuget.org/v3/index.json
```

输出显示发布过程的结果：

```output
Pushing Contoso.08.28.22.001.Test.1.0.0.nupkg to 'https://www.nuget.org/api/v2/package'...
  PUT https://www.nuget.org/api/v2/package/
warn : All published packages should have license information specified. Learn more: https://aka.ms/nuget/authoring-best-practices#licensing.
  Created https://www.nuget.org/api/v2/package/ 1221ms
Your package was pushed.
```

有关详细信息，请参阅 [dotnet nuget push](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-nuget-push)。

> 如果要避免测试包在 nuget.org 上处于活动状态，可以推送到 位于 [https://int.nugettest.org](https://int.nugettest.org/)的 nuget.org 测试站点。请注意，上载到 int.nugettest.org 的包可能不会保留。