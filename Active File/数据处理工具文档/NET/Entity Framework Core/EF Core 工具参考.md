## .NET Core CLI

适用于 Entity Framework Core 的命令行接口 (CLI) 工具可执行设计时开发任务。 例如，可以创建[迁移](https://learn.microsoft.com/zh-cn/aspnet/core/data/ef-mvc/migrations)、应用迁移，并为基于现有数据库的模型生成代码。 这些命令是跨平台 [dotnet](https://learn.microsoft.com/zh-cn/dotnet/core/tools) 命令（属于 [.NET Core SDK](https://www.microsoft.com/net/core)）的扩展。 这些工具适用于 .NET Core 项目。

使用 Visual Studio 时，请考虑使用 [包管理器控制台工具](https://learn.microsoft.com/zh-cn/ef/core/cli/powershell) 而不是 CLI 工具。 包管理器控制台工具自动执行以下操作：

- 使用包管理器控制台中选择的当前项目，无需手动切换目录。
- 在命令完成后打开该命令生成的文件。
- 提供命令、参数、项目名称、上下文类型和迁移名称的 Tab 自动补全。