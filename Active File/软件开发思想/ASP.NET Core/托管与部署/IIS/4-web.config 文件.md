[web.config 文件 | Microsoft Learn](https://learn.microsoft.com/zh-cn/aspnet/core/host-and-deploy/iis/web-config)

`web.config` 文件由 IIS 和 `web.config`读取，用于使用 IIS 配置已托管的应用。

## `web.config` 文件位置

为了正确设置 [ASP.NET Core 模块](https://learn.microsoft.com/zh-cn/aspnet/core/host-and-deploy/aspnet-core-module?view=aspnetcore-7.0)，`web.config` 文件必须存在于已部署应用的[内容根](https://learn.microsoft.com/zh-cn/aspnet/core/fundamentals/?view=aspnetcore-7.0#content-root)路径（通常为应用基路径）中。 该位置与向 IIS 提供的网站物理路径相同。 若要使用 Web 部署发布多个应用，应用的根路径中需要包含 `web.config` 文件。

敏感文件存在于应用的物理路径中，如 `{ASSEMBLY}.runtimeconfig.json`、`{ASSEMBLY}.xml`（XML 文档注释）和 `{ASSEMBLY}.deps.json`，其中 `{ASSEMBLY}` 占位符为程序集名称。 如果有 `web.config` 文件且站点正常启动时，IIS 在收到敏感文件请求时不会提供这些敏感文件。 如果 `web.config` 文件缺失、名字错误或者无法将站点配置为正常启动，IIS 可能会公开提供敏感文件。

**`web.config` 文件必须始终存在于部署中、名称正确以及能够将站点配置为正常启动。 切勿从生产部署中删除 `web.config` 文件。**

如果项目中没有 `web.config` 文件，则该文件是使用正确的 `processPath` 和 `arguments`（用于配置 ASP.NET Core 模块）创建的，并且已被移到`web.config`中。

如果项目中没有 `web.config` 文件，则该文件是通过正确的 `processPath` 和 `arguments`（用于配置 ASP.NET Core 模块）转换的，并且已被移到发布的输出中。 转换不会修改文件中的 IIS 配置设置。

`web.config` 文件可能会提供控制活动 IIS 模块的额外 IIS 配置设置。 有关能够处理 ASP.NET Core 应用请求的 IIS 模块的信息，请参阅 [IIS 模块](https://learn.microsoft.com/zh-cn/aspnet/core/host-and-deploy/iis/modules?view=aspnetcore-7.0)主题。

发布项目时，`web.config` 文件的创建、转换和发布是由 MSBuild 目标 (`_TransformWebConfig`) 处理的。 此目标位于 Web SDK 目标 (`Microsoft.NET.Sdk.Web`) 中。 SDK 设置在项目文件的顶部：

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
```

为了防止 Web SDK 转换 `web.config` 文件，请在项目文件中使用 `<IsTransformWebConfigDisabled>` 属性：

```xml
<PropertyGroup>
  <IsTransformWebConfigDisabled>true</IsTransformWebConfigDisabled>
</PropertyGroup>
```

禁用 Web SDK 对文件的转换时，`processPath` 和 `arguments` 应由开发人员手动设置。 有关详细信息，请参阅[用于 IIS 的 ASP.NET Core 模块 (ANCM)](https://learn.microsoft.com/zh-cn/aspnet/core/host-and-deploy/aspnet-core-module?view=aspnetcore-7.0)。

## 使用 `web.config` 配置 ASP.NET Core 模块

[web.config 文件 | Microsoft Learn](https://learn.microsoft.com/zh-cn/aspnet/core/host-and-deploy/iis/web-config?view=aspnetcore-7.0#configuration-of-aspnet-core-module-with-webconfig)