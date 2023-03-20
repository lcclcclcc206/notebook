[dotnet publish 命令 - .NET CLI | Microsoft Learn](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish)

`dotnet publish` - 将应用程序及其依赖项发布到文件夹以部署到托管系统。

## 摘要

```dotnet cli
dotnet publish [<PROJECT>|<SOLUTION>] [-a|--arch <ARCHITECTURE>]
    [-c|--configuration <CONFIGURATION>]
    [-f|--framework <FRAMEWORK>] [--force] [--interactive]
    [--manifest <PATH_TO_MANIFEST_FILE>] [--no-build] [--no-dependencies]
    [--no-restore] [--nologo] [-o|--output <OUTPUT_DIRECTORY>]
    [--os <OS>] [-r|--runtime <RUNTIME_IDENTIFIER>]
    [--sc|--self-contained [true|false]] [--no-self-contained]
    [-s|--source <SOURCE>] [--use-current-runtime, --ucr [true|false]]
    [-v|--verbosity <LEVEL>] [--version-suffix <VERSION_SUFFIX>]

dotnet publish -h|--help
```

## 描述

`dotnet publish` 编译应用程序、读取 project 文件中指定的所有依赖项并将生成的文件集发布到目录。 输出包括以下资产：

- 扩展名为 dll 的程序集中的中间语言 (IL) 代码。
- 包含项目所有依赖项的 .deps.json 文件。
- .runtimeconfig.json 文件，其中指定了应用程序所需的共享运行时，以及运行时的其他配置选项（例如垃圾回收类型）。
- 应用程序的依赖项，将这些依赖项从 NuGet 缓存复制到输出文件夹。

`dotnet publish` 命令的输出可供部署至托管系统（例如服务器、电脑、Mac、笔记本电脑）以便执行。 若要准备用于部署的应用程序，这是唯一正式受支持的方法。 根据项目指定的部署类型，托管系统不一定已在其上安装 .NET 共享运行时。 有关详细信息，请参阅[使用 .NET CLI 发布 .NET 应用](https://learn.microsoft.com/zh-cn/dotnet/core/deploying/deploy-with-cli)。

## MSBuild

https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish#msbuild

## 自变量

**`PROJECT|SOLUTION`**

要发布的项目或解决方案。

- `PROJECT` 是 C#、F# 或 Visual Basic 项目文件的路径和文件名，或包含 C#、F# 或 Visual Basic 项目文件的目录的路径。 如果未指定目录，则默认为当前目录。
- `SOLUTION` 是解决方案文件（扩展名为 .sln）的路径和文件名，或包含解决方案文件的目录的路径。 如果未指定目录，则默认为当前目录

## 选项

https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish#options

- **`-a|--arch <ARCHITECTURE>`**

  指定目标体系结构。 这是用于设置[运行时标识符 (RID)](https://learn.microsoft.com/zh-cn/dotnet/core/rid-catalog) 的简写语法，其中提供的值与默认 RID 相结合。 例如，在 `win-x64` 计算机上，指定 `--arch x86` 会将 RID 设置为 `win-x86`。 如果使用此选项，请不要使用 `-r|--runtime` 选项。 从 .NET 6 Preview 7 开始提供。

- **`-c|--configuration <CONFIGURATION>`**

  定义生成配置。 大多数项目的默认配置为 `Debug`，但你可以覆盖项目中的生成配置设置。

- **`-f|--framework <FRAMEWORK>`**

  为指定的[目标框架](https://learn.microsoft.com/zh-cn/dotnet/standard/frameworks)发布应用程序。 必须在项目文件中指定目标框架。

- **`-o|--output <OUTPUT_DIRECTORY>`**

  指定输出目录的路径。

  如果未指定，则默认为依赖框架的可执行文件和跨平台二进制文件的路径 [project_file_folder]/bin/[configuration]/[framework]/publish/。 默认为独立的可执行文件路径 [project_file_folder]/bin/[configuration]/[framework]/[runtime]/publish/。

- **`--os <OS>`**

  指定目标操作系统 (OS)。 这是用于设置[运行时标识符 (RID)](https://learn.microsoft.com/zh-cn/dotnet/core/rid-catalog) 的简写语法，其中提供的值与默认 RID 相结合。 例如，在 `win-x64` 计算机上，指定 `--os linux` 会将 RID 设置为 `linux-x64`。 如果使用此选项，请不要使用 `-r|--runtime` 选项。 自 .NET 6 之后可用。

- **`--sc|--self-contained [true|false]`**

  .NET 运行时随应用程序一同发布，因此无需在目标计算机上安装运行时。 如果指定了运行时标识符，并且项目是可执行项目（而不是库项目），则默认值为 `true`。 有关详细信息，请参阅 [.NET 应用程序发布](https://learn.microsoft.com/zh-cn/dotnet/core/deploying/)和[使用 .NET CLI 发布 .NET 应用](https://learn.microsoft.com/zh-cn/dotnet/core/deploying/deploy-with-cli)。

  如果在未指定 `true` 或 `false` 的情况下使用此选项，则默认值为 `true`。 在这种情况下，请不要紧接在 `--self-contained` 后放置解决方案或项目参数，因为该位置需要 `true` 或 `false`。

- **`--no-self-contained`**

  等效于 `--self-contained false`。

## 示例

- 为当前目录中的项目创建一个[依赖框架的跨平台二进制文件](https://learn.microsoft.com/zh-cn/dotnet/core/deploying/#produce-a-cross-platform-binary)：

  ```dotnetcli
  dotnet publish
  ```

  自 .NET Core 3.0 SDK 起，此示例还为当前平台创建[依赖框架的可执行文件](https://learn.microsoft.com/zh-cn/dotnet/core/deploying/#publish-framework-dependent)。

- 针对特定运行时，为当前目录中的项目创建[独立可执行文件](https://learn.microsoft.com/zh-cn/dotnet/core/deploying/#publish-self-contained)：

  ```dotnetcli
  dotnet publish --runtime osx.10.11-x64
  ```

  项目文件中必须包含 RID。

- 针对特定平台，为当前目录中的项目创建[依赖框架的可执行文件](https://learn.microsoft.com/zh-cn/dotnet/core/deploying/#publish-framework-dependent)：

  ```dotnetcli
  dotnet publish --runtime osx.10.11-x64 --self-contained false
  ```

  项目文件中必须包含 RID。 此示例适用于 .NET Core 3.0 SDK 及更高版本。

- 针对特定运行时和目标框架，在当前目录中发布项目：

  ```dotnetcli
  dotnet publish --framework netcoreapp3.1 --runtime osx.10.11-x64
  ```

- 发布指定的项目文件：

  ```dotnetcli
  dotnet publish ~/projects/app1/app1.csproj
  ```

- 发布当前应用程序，但在还原操作期间不还原项目到项目 (P2P) 引用，只还原根项目：

  ```dotnetcli
  dotnet publish --no-dependencies
  ```