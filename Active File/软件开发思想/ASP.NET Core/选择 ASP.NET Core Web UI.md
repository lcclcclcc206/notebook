[选择 ASP.NET Core UI | Microsoft Learn](https://learn.microsoft.com/zh-cn/aspnet/core/tutorials/choose-web-ui)

ASP.NET Core 是一个完整的 UI 框架。 你可以选择要结合哪些功能，以满足应用的 Web UI 需求。

## 服务器和客户端呈现 UI 的优势和成本

有三种常见的方法可以使用 ASP.NET Core 构建新式 Web UI：

- 从服务器呈现 UI 的应用。
- 在浏览器的客户端上呈现 UI 的应用。
- 利用服务器和客户端 UI 呈现方法的混合应用。 例如，大多数 Web UI 呈现在服务器上，并会根据需要来添加客户端呈现的组件。

在服务器或客户端上呈现 UI 时，需要考虑其优点和缺点。

### 服务器呈现的 UI

在服务器上呈现的 Web UI 应用会在服务器上动态生成页面的 HTML 和 CSS，以响应浏览器请求。 页面在到达客户端时已准备好显示。

优点：

- 客户端的需求最少，因为是由服务器执行逻辑和页面生成工作：
  - 非常适用于低端设备和低带宽连接。
  - 允许在客户端上使用各种浏览器版本。
  - 快速加载初始页面。
  - 尽可能少地使用或不使用 JavaScript 拉到客户端。
- 灵活地访问受保护的服务器资源：
  - 数据库访问。
  - 访问机密，如对 Azure 存储的 API 调用值。
- 静态站点分析优点，例如搜索引擎优化。

常见的服务器呈现的 Web UI 应用场景的示例：

- 动态站点，例如提供个性化页面、数据和窗体的站点。
- 显示只读数据，如事务列表。
- 显示静态博客页面。
- 面向公众的内容管理系统。

缺点：

- 计算和内存使用的成本都集中在服务器上，而不是分摊到每个客户端。
- 用户交互需要往返服务器才能生成 UI 更新。

### 客户端呈现的 UI

客户端呈现的应用在客户端上动态地呈现 Web UI，从而根据需求直接更新浏览器 DOM。

优点：

- 可以实现几乎即时的丰富交互性，无需往返服务器。 UI 事件处理和逻辑在用户的设备上本地运行，延迟最小。
- 支持增量更新，保存部分完成的窗体或文档，用户无需选择按钮提交窗体。
- 可设计为在断开连接模式下运行。 重建连接后，针对客户端模型的更新最终会同步回服务器。
- 降低了服务器的负载和成本，将工作负荷转移到客户端。 许多客户端呈现的应用也可以作为静态网站进行托管。
- 利用用户设备的功能。

客户端呈现的 Web UI 示例：

- 交互式仪表板。
- 具有拖放功能的应用
- 响应式协作社交应用。

缺点：

- 必须在客户端下载和执行逻辑的代码，这增加了初始加载时间。
- 客户端要求可能不包含那些具有低端设备、较旧版本的浏览器或低带宽连接的用户。

## 选择服务器呈现的 ASP.NET Core UI 解决方案

下面的部分介绍了可用的 ASP.NET Core Web UI 服务器呈现的模型，并提供了入门链接。 ASP.NET Core Razor Pages 和 ASP.NET Core MVC 是基于服务器的框架，用于通过 .Net 生成 Web 应用。

### ASP.NET Core Razor Pages

Razor Pages 是一个基于页面的模型。 UI 和业务逻辑关注点保持分离状态，但都在页面内。 对于刚接触 ASP.NET Core 的开发人员，建议使用 Razor Pages 创建新的基于页面或基于窗体的应用。 Razor Pages 入门比 ASP.NET Core MVC 要简单一些。

在服务器呈现的优点基础上，Razor Pages 也有它的优点：

- 快速构建和更新 UI。 页面的代码与页面一起保存，同时保持 UI 和业务逻辑关注点相互分离。
- 可进行测试并缩放到大型应用。
- 组织 ASP.NET Core 页面，使用起来比 ASP.NET MVC 更简单：
  - 视图的具体逻辑和视图模型可以一起保存在它们自己的命名空间和目录中。
  - 相关页面的组可以保存在各自的命名空间和目录中。

若要开始使用你的第一个 ASP.NET Core Razor Pages 应用，请参阅Razor。 有关 ASP.NET Core Razor Pages、其体系结构和优势的完整概述，请参阅 Razor。

### ASP.NET Core MVC

ASP.NET MVC 在服务器上呈现 UI，并使用模型-视图-控制器 (MVC) 结构模式。 MVC 模式将应用分成三组主要组件：模型、视图和控制器。 用户请求被路由到控制器。 控制器负责使用模型来执行用户操作或检索查询结果。 控制器选择要显示给用户的视图，并为其提供所需的任何模型数据。 对 Razor Pages 的支持是建立在 ASP.NET Core MVC 基础之上的。

在服务器呈现的优点基础上，MVC 也有它的优点：

- 基于可缩放且成熟的模型生成大型 Web 应用。
- 明确[分离关注点](https://learn.microsoft.com/zh-cn/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#separation-of-concerns)以获得最大的灵活性。
- 模型-视图-控制器的责任分离，确保了业务模型的发展，而不会与底层的实现细节紧密相连。

若要开始使用 ASP.NET Core MVC，请参阅[开始使用 ASP.NET Core MVC](https://learn.microsoft.com/zh-cn/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-7.0)。 有关 ASP.NET Core MVC 的体系结构和优势的概述，请参阅 [ASP.NET Core MVC 概述](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/overview?view=aspnetcore-7.0)。

## 选择客户端呈现的 ASP.NET Core 解决方案

下面的部分简要介绍了可用的 ASP.NET Core Web UI 客户端呈现的模型，并提供了入门链接。

### Blazor

Blazor 应用由 Razor 组件组成：使用 C#、HTML 和 CSS 实现的可重用的 Web UI 段。 客户端和服务器代码都以 C# 编写，允许使用共享代码和库。 Razor 组件可以从视图和页面呈现或预呈现。

Razor 组件的优点：

- 使用 C# 而不是 JavaScript 构建交互式 Web UI。 对前端和后端代码使用同一语言，可以：
  - 加快应用开发。
  - 降低生成管道的复杂性。
  - 简化维护。
  - 利用现有的 [.NET 库](https://learn.microsoft.com/zh-cn/dotnet/standard/class-libraries)生态系统。
  - 让开发人员了解和处理客户端和服务器端代码。
- 创建可重用且可共享的 UI 组件。
- 使用Blazor提供的 Blazor 可重用 UI 组件，工作效率更高。
- 适用于所有新式 Web 浏览器，包括移动浏览器。 Blazor 使用开放 Web 标准，没有插件或代码转译。

可以使用 Blazor Server 或 Blazor WebAssembly 托管 Razor 组件，以利用服务器或客户端呈现的优势。

有关详细信息，请参阅 [ASP.NET Core Blazor](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/?view=aspnetcore-7.0) 和 [ASP.NET Core Blazor 托管模型](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/hosting-models?view=aspnetcore-7.0)。

### 使用 JavaScript 框架（例如 Angular 和 React）的 ASP.NET Core 单页应用程序 (SPA)

使用热门的 JavaScript 框架（如 [Angular](https://angular.io/) 或 [React](https://facebook.github.io/react/)）生成适用于 ASP.NET Core 应用的客户端逻辑。 ASP.NET Core 为 Angular 和 React 提供了项目模板，也可以用于其他 JavaScript 框架。

在前面列出的客户端呈现的优点基础上，将 ASP.NET Core SPA 与 JavaScript 框架结合使用也有一些优点：

- JavaScript 运行时环境已随浏览器提供。
- 大型社区和成熟的生态系统。
- 使用热门的 JS 框架（如 Angular 和 React）构建适用于 ASP.NET Core 应用的客户端逻辑。

缺点：

- 需要更多编码语言、框架和工具。
- 难以共享代码，因此一些逻辑可能会重复。

如要入门，请参阅：

- [ASP.NET Core 使用 Angular](https://learn.microsoft.com/zh-cn/aspnet/core/client-side/spa/angular?view=aspnetcore-7.0)
- [通过 ASP.NET Core 使用 React](https://learn.microsoft.com/zh-cn/aspnet/core/client-side/spa/react?view=aspnetcore-7.0)

## 选择混合解决方案：ASP.NET Core MVC 或 Razor Pages 与 Blazor 结合使用

MVC、Razor Pages 和 Blazor 都是 ASP.NET Core 框架的一部分，设计为可以结合使用。 Razor 组件可以通过托管的 Blazor WebAssembly 或 Blazor Server 解决方案集成到 Razor Pages 和 MVC 应用。 呈现视图或页面时，可以同时预呈现组件。

在 MVC 或 Razor Pages 的优点基础上，MVC 或 Razor Pages 与 Blazor 结合使用的优点如下：

- 预呈现会在服务器上执行 Razor 组件，并将其呈现到视图或页面中，从而提高应用的感知加载时间。
- 使用[组件标记帮助程序](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/tag-helpers/built-in/component-tag-helper?view=aspnetcore-7.0)将交互性添加到现有视图或页面。

若要开始将 ASP.NET Core MVC 或 Razor Pages 与 Blazor 结合使用，请参阅[预呈现和集成 ASP.NET Core Razor 组件](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/prerendering-and-integration?view=aspnetcore-7.0)。