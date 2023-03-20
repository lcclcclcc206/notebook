[.NET CLI | Microsoft Learn](https://learn.microsoft.com/zh-cn/dotnet/core/tools/)

.NET 命令行接口 (CLI) 工具是用于开发、生成、运行和发布 .NET 应用程序的跨平台工具链。

## CLI 命令简介

默认安装以下命令：

### 基本命令

- [`new`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-new)
- [`restore`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-restore)
- [`build`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-build)
- [`publish`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish)
- [`run`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-run)
- [`test`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-test)
- [`vstest`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-vstest)（已被 test 取代）
- [`pack`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-pack)
- [`migrate`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-migrate)（已弃用）
- [`clean`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-clean)
- [`sln`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-sln)
- [`help`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-help)
- [`store`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-store)

### 项目修改命令

- [`add package`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-add-package)
- [`add reference`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-add-reference)
- [`remove package`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-remove-package)
- [`remove reference`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-remove-reference)
- [`list reference`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-list-reference)

### 高级命令

- [`nuget delete`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-nuget-delete)
- [`nuget locals`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-nuget-locals)
- [`nuget push`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-nuget-push)
- [`msbuild`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-msbuild)
- [`dotnet install script`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-install-script)

### 工具管理命令

- [`tool install`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-install)
- [`tool list`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-list)
- [`tool update`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-update)
- [`tool restore`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/global-tools#install-a-local-tool) 自 .NET Core SDK 3.0 起可用。
- [`tool run`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/global-tools#invoke-a-local-tool) 自 .NET Core SDK 3.0 起可用。
- [`tool uninstall`](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-uninstall)

工具是控制台应用程序，它们从 NuGet 包中安装并从命令提示符处进行调用。 你可自行编写工具，也可安装由第三方编写的工具。 工具也称为全局工具、工具路径工具和本地工具。 有关详细信息，请参阅 [.NET 工具概述](https://learn.microsoft.com/zh-cn/dotnet/core/tools/global-tools)。