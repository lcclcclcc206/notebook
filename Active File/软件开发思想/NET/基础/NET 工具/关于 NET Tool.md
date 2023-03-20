[.NET 工具 - .NET CLI | Microsoft Learn](https://learn.microsoft.com/zh-cn/dotnet/core/tools/global-tools)

.NET 工具是一种特殊的 NuGet 包，其中包含控制台应用程序。 可通过以下方式在计算机上安装该工具：

- 作为全局工具。

  工具二进制文件安装在添加到 PATH 环境变量的默认目录中。 无需指定工具位置即可从计算机上的任何目录调用该工具。 工具的一个版本用于计算机上的所有目录。

- 作为自定义位置中的全局工具（也称为工具路径工具）。

  工具二进制文件安装在你指定的位置中。 可以通过提供具有命令名称的目录从安装目录调用该工具，也可以将目录添加到 PATH 环境变量来调用该工具。 工具的一个版本用于计算机上的所有目录。

- 作为本地工具（适用于 .NET Core SDK 3.0 及更高版本）。

  工具二进制文件安装在默认目录中。 可以从安装目录或其任何子目录调用该工具。 不同目录可以使用同一工具的不同版本。

  .NET CLI 使用清单文件跟踪作为本地工具安装到目录的工具。 将清单文件保存到源代码存储库的根目录中后，参与者可以克隆存储库并调用用于安装清单文件中列出的所有工具的单个 .NET CLI 命令。

## 查找工具

以下是查找工具的一些方法：

- 使用 [dotnet tool search](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-search) 命令查找发布到 NuGet.org 的工具。
- 使用“.NET 工具”包类型筛选器搜索 [NuGet](https://www.nuget.org/) 网站。 有关详细信息，请参阅[查找和选择包](https://learn.microsoft.com/zh-cn/nuget/consume-packages/finding-and-choosing-packages)。
- 在 [dotnet/aspnetcore GitHub 存储库的工具目录](https://github.com/dotnet/aspnetcore/tree/main/src/Tools)中查看 ASP.NET Core 团队创建的工具的源代码。
- 在 [.NET 诊断工具](https://learn.microsoft.com/zh-cn/dotnet/core/diagnostics/#net-core-diagnostic-global-tools)中了解诊断工具。

## 安装全局工具

若要将工具作为全局工具安装，请使用 [dotnet tool install](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-install) 的 `-g` 或 `--global` 选项，如以下示例中所示：

```dotnetcli
dotnet tool install -g dotnetsay
```

输出显示用于调用该工具和已安装的版本的命令，类似于以下示例：

```output
You can invoke the tool using the following command: dotnetsay
Tool 'dotnetsay' (version '2.1.4') was successfully installed.
```

工具二进制文件的默认位置取决于操作系统：

| (OS)        | 路径                          |
| :---------- | :---------------------------- |
| Linux/macOS | `$HOME/.dotnet/tools`         |
| Windows     | `%USERPROFILE%\.dotnet\tools` |

## 安装自定义位置中的全局工具

若要将工具作为自定义位置中的全局工具安装，请使用 [dotnet tool install](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-install) 的 `--tool-path` 选项，如以下示例中所示：

在 Windows 上：

```dotnetcli
dotnet tool install dotnetsay --tool-path c:\dotnet-tools
```

在 Linux 或 macOS 上：

```dotnetcli
dotnet tool install dotnetsay --tool-path ~/bin
```

.NET SDK 不将此位置自动添加至 PATH 环境变量。 若要[调用工具路径工具](https://learn.microsoft.com/zh-cn/dotnet/core/tools/global-tools#invoke-a-tool-path-tool)，必须确保可使用以下方法之一来调用命令：

- 将安装目录添加到 PATH 环境变量。
- 调用该工具时，指定该工具的完整路径。
- 从安装目录调用该工具。

## 安装本地工具

> **适用于 .NET Core 3.0 SDK 及更高版本。**

如果要安装仅用于本地访问的工具（对于当前目录和子目录），必须将其添加到工具清单文件。 若要创建工具清单文件，请运行 `dotnet new tool-manifest` 命令：

```dotnetcli
dotnet new tool-manifest
```

此命令在“.config” 目录下创建一个名为“dotnet-tools.json” 的清单文件。 若要将本地工具添加到清单文件，请使用 [dotnet tool install](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-install) 命令并省略 `--global` 和 `--tool-path` 选项，如以下示例中所示 ：

```dotnetcli
dotnet tool install dotnetsay
```

以下示例显示安装了两个本地工具的清单文件：

```json
{
  "version": 1,
  "isRoot": true,
  "tools": {
    "botsay": {
      "version": "1.0.0",
      "commands": [
        "botsay"
      ]
    },
    "dotnetsay": {
      "version": "2.1.3",
      "commands": [
        "dotnetsay"
      ]
    }
  }
}
```

通常将本地工具添加到存储库的根目录。 将清单文件签入到存储库后，从存储库中签出代码的开发人员会获得最新的清单文件。 若要安装清单文件中列出的所有工具，请运行 `dotnet tool restore` 命令：

```dotnetcli
dotnet tool restore
```

## 使用工具

用于调用工具的命令可能不同于安装的包的名称。 若要显示计算机上目前安装的所有工具，请使用 [dotnet tool list](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-list) 命令：

```dotnetcli
dotnet tool list 
```

输出显示每个工具的版本和命令，类似于以下示例：

```console
Package Id      Version      Commands       Manifest
-------------------------------------------------------------------------------------------
botsay          1.0.0        botsay         /home/name/repository/.config/dotnet-tools.json
dotnetsay       2.1.3        dotnetsay      /home/name/repository/.config/dotnet-tools.json
```

如本示例中所示，列表显示了本地工具。 **若要查看全局工具，请使用 `--global` 选项。 若要查看工具路径工具，请使用 `--tool-path` 选项。**

## 调用本地工具

若要调用本地工具，必须从安装目录使用 `dotnet` 命令。 可以使用长格式 (`dotnet tool run <COMMAND_NAME>`) 或短格式 (`dotnet <COMMAND_NAME>`)，如以下示例中所示：

```dotnetcli
dotnet tool run dotnetsay
dotnet dotnetsay
```

## 更新工具

更新工具涉及卸载该工具并重新安装它的最新稳定版。 若要更新工具，请使用具有用于安装该工具的相同选项的 [dotnet tool update](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-update) 命令：

```dotnetcli
dotnet tool update --global <packagename>
dotnet tool update --tool-path <packagename>
dotnet tool update <packagename>
```

对于本地工具，SDK 将在当前目录和父目录中查找第一个包含包 ID 的清单文件。 如果任何清单文件中都没有此类包 ID，SDK 会将新条目添加到最近的清单文件。

## 卸载工具

使用具有用于安装该工具的相同选项的 [dotnet tool uninstall](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-uninstall) 命令卸载工具：

```dotnetcli
dotnet tool uninstall --global <packagename>
dotnet tool uninstall --tool-path <packagename>
dotnet tool uninstall <packagename>
```

对于本地工具，SDK 将在当前目录和父目录中查找第一个包含包 ID 的清单文件。