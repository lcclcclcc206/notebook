ASP.NET Core 模块 (ANCM) 是插入 IIS 管道的本机 IIS 模块，能让 ASP.NET Core 应用程序通过 IIS 运行。 使用以下任一方式通过 IIS 运行 ASP.NET Core 应用：

- 在 IIS 工作进程 (`w3wp.exe`) 内托管 ASP.NET Core 应用，称为[进程内托管模型](https://learn.microsoft.com/zh-cn/aspnet/core/host-and-deploy/iis/in-process-hosting?view=aspnetcore-7.0)。
- 将 Web 请求转发到运行 Kestrel 服务器的后端 ASP.NET Core 应用，称为[进程外托管模型](https://learn.microsoft.com/zh-cn/aspnet/core/host-and-deploy/iis/out-of-process-hosting?view=aspnetcore-7.0)。

我们需要对这两类托管模型进行权衡。 默认情况下使用的是进程内托管模型，因为这样可以得到更好的性能和诊断。

有关详细信息和配置指南，请参阅以下主题：

- [ASP.NET Core 中的 Web 服务器实现](https://learn.microsoft.com/zh-cn/aspnet/core/fundamentals/servers/?view=aspnetcore-7.0)

## 安装 ASP.NET Core 模块 (ANCM)

ASP.NET Core 模块 (ANCM) 随 [.NET Core 托管捆绑包](https://learn.microsoft.com/zh-cn/aspnet/core/host-and-deploy/iis/hosting-bundle?view=aspnetcore-7.0)中的 .NET Core 运行时一起安装。 ASP.NET Core 模块与 .NET 的 LTS 版本向前和向后兼容。

[公告存储库](https://github.com/aspnet/Announcements/issues)上报告了重大更改和安全建议。 可以通过选择“标签”筛选器将公告限制为特定版本。

使用以下链接下载安装程序：

[当前 .NET Core 托管捆绑包安装程序（直接下载）](https://dotnet.microsoft.com/permalink/dotnetcore-current-windows-runtime-bundle-installer)

有关详细信息（包括安装模块的早期版本），请参阅[托管捆绑包](https://learn.microsoft.com/zh-cn/aspnet/core/host-and-deploy/iis/hosting-bundle?view=aspnetcore-7.0)。

若要学习将 ASP.NET Core 应用发布到 IIS 服务器的教程，请参阅[将 ASP.NET Core 应用发布到 IIS](https://learn.microsoft.com/zh-cn/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-7.0)。