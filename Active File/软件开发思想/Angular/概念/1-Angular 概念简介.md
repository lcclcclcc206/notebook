Angular 是一个用 HTML 和 TypeScript 构建客户端应用的平台与框架。Angular 本身就是用 TypeScript 写成的。它将核心功能和可选功能作为一组 TypeScript 库进行实现，你可以把它们导入你的应用中。

Angular 的基本构造块是 *NgModule*，它为*组件*提供了编译的上下文环境。NgModule 会把相关的代码收集到一些功能集中。Angular 应用就是由一组 NgModule 定义出的。应用至少会有一个用于引导应用的*根模块*，通常还会有很多*特性模块*。

- 组件定义*视图*。视图是一组可见的屏幕元素，Angular 可以根据你的程序逻辑和数据来选择和修改它们。每个应用都至少有一个根组件。
- 组件使用*服务*。服务会提供那些与视图不直接相关的功能。服务提供者可以作为*依赖*被*注入*到组件中，这能让你的代码更加模块化、更加可复用、更加高效。

模块、组件和服务都是使用*装饰器*的类，这些*装饰器*会标出它们的类型并提供元数据，以告知 Angular 该如何使用它们。

- 组件类的元数据将组件类和一个用来定义视图的*模板*关联起来。模板把普通的 HTML 和 Angular *指令*与*绑定标记（markup）*组合起来，这样 Angular 就可以在渲染 HTML 之前先修改这些 HTML。
- 服务类的元数据提供了一些信息，Angular 要用这些信息来让组件可以通过*依赖注入（DI）*使用该服务。

应用的组件通常会定义很多视图，并进行分级组织。Angular 提供了 `Router` 服务来帮助你定义视图之间的导航路径。路由器提供了先进的浏览器内导航功能。

## 模块 Module

[Angular - NgModule 简介](https://angular.cn/guide/architecture-modules)

Angular 定义了 `NgModule`，它和 JavaScript（ES2015）的模块不同而且有一定的互补性。NgModule 为一个组件集声明了编译的上下文环境，它专注于某个应用领域、某个工作流或一组紧密相关的能力。NgModule 可以将其组件和一组相关代码（如服务）关联起来，形成功能单元。

每个 Angular 应用都有一个*根模块*，通常命名为 `AppModule`。根模块提供了用来启动应用的引导机制。一个应用通常会包含很多特性模块。

像 JavaScript 模块一样，NgModule 也可以从其它 NgModule 中导入功能，并允许导出它们自己的功能供其它 NgModule 使用。比如，要在你的应用中使用路由器（Router）服务，就要导入 `Router` 这个 NgModule。

把你的代码组织成一些清晰的特性模块，可以帮助管理复杂应用的开发工作并实现可复用性设计。另外，这项技术还能让你获得*惰性加载*（也就是按需加载模块）的优点，以尽可能减小启动时需要加载的代码体积。

## 组件 Component

[Angular - 组件简介](https://angular.cn/guide/architecture-components)

每个 Angular 应用都至少有一个组件，也就是*根组件*，它会把组件树和页面中的 DOM 连接起来。每个组件都会定义一个类，其中包含应用的数据和逻辑，并与一个 HTML *模板*相关联，该模板定义了一个供目标环境下显示的视图。

`@Component()` 装饰器表明紧随它的那个类是一个组件，并提供模板和该组件专属的元数据。

[到网上学习关于装饰器的更多知识。](https://medium.com/google-developers/exploring-es7-decorators-76ecb65fb841#.x5c2ndtx0)

### 模板、指令和数据绑定

模板会把 HTML 和 Angular 的标记（markup）组合起来，这些标记可以在 HTML 元素显示出来之前修改它们。模板中的*指令*会提供程序逻辑，而*绑定标记*会把你应用中的数据和 DOM 连接在一起。有两种类型的数据绑定：

| 数据绑定 | 详情                                                         |
| :------- | :----------------------------------------------------------- |
| 事件绑定 | 让你的应用可以通过更新应用的数据来响应目标环境下的用户输入。 |
| 属性绑定 | 让你将从应用数据中计算出来的值插入到 HTML 中。               |

在视图显示出来之前，Angular 会先根据你的应用数据和逻辑来运行模板中的指令并解析绑定表达式，以修改 HTML 元素和 DOM。Angular 支持*双向数据绑定*，这意味着 DOM 中发生的变化（比如用户的选择）同样可以反映回你的程序数据中。

你的模板也可以用*管道*转换要显示的值以增强用户体验。比如，可以使用管道来显示适合用户所在本地环境的日期和货币格式。Angular 为一些通用的转换提供了预定义管道，你还可以定义自己的管道。

## 服务与依赖注入 Services and dependency injection

[Angular - 服务与依赖注入简介](https://angular.cn/guide/architecture-services)

对于与特定视图无关并希望跨组件共享的数据或逻辑，可以创建*服务*类。服务类的定义通常紧跟在 “@Injectable()” 装饰器之后。该装饰器提供的元数据可以让你的服务作为依赖*被注入到*客户组件中。

*依赖注入*（或 DI）让你可以保持组件类的精简和高效。有了 DI，组件就不用从服务器获取数据、验证用户输入或直接把日志写到控制台，而是会把这些任务委托给服务。

### 路由

[Angular - 常见路由任务](https://angular.cn/guide/router)

Angular 的 `Router` 模块提供了一个服务，它可以让你定义在应用的各个不同状态和视图层次结构之间导航时要使用的路径。它的工作模型基于人们熟知的浏览器导航约定：

- 在地址栏输入 URL，浏览器就会导航到相应的页面。
- 在页面中点击链接，浏览器就会导航到一个新页面。
- 点击浏览器的前进和后退按钮，浏览器就会在你的浏览历史中向前或向后导航。

不过路由器会把类似 URL 的路径映射到视图而不是页面。当用户执行一个动作时（比如点击链接），本应该在浏览器中加载一个新页面，但是路由器拦截了浏览器的这个行为，并显示或隐藏一个视图层次结构。

如果路由器认为当前的应用状态需要某些特定的功能，而定义此功能的模块尚未加载，路由器就会按需*惰性加载*此模块。

路由器会根据你应用中的导航规则和数据状态来拦截 URL。当用户点击按钮、选择下拉框或收到其它任何来源的输入时，你可以导航到一个新视图。路由器会在浏览器的历史日志中记录这个动作，所以前进和后退按钮也能正常工作。

要定义导航规则，你就要把*导航路径*和你的组件关联起来。路径（path）使用类似 URL 的语法来和程序数据整合在一起，就像模板语法会把你的视图和程序数据整合起来一样。然后你就可以用程序逻辑来决定要显示或隐藏哪些视图，以根据你制定的访问规则对用户的输入做出响应。

## Angular 示意图

下面这张图展示了这些基础部分之间是如何关联起来的。

![overview](https://angular.cn/generated/images/guide/architecture/overview2.png)

- 组件和模板共同定义了 Angular 的视图。
  - 组件类上的装饰器为其添加了元数据，其中包括指向相关模板的指针。
  - 组件模板中的指令和绑定标记会根据程序数据和程序逻辑修改这些视图。
- 依赖注入器会为组件提供一些服务，比如路由器服务就能让你定义如何在视图之间导航。

这些主题的详情在下列页面中有介绍：

- [模块简介](https://angular.cn/guide/architecture-modules)
- [组件简介](https://angular.cn/guide/architecture-components)
  - [模板与视图](https://angular.cn/guide/architecture-components#templates-and-views)
  - [组件元数据](https://angular.cn/guide/architecture-components#component-metadata)
  - [数据绑定](https://angular.cn/guide/architecture-components#data-binding)
  - [指令](https://angular.cn/guide/architecture-components#directives)
  - [管道](https://angular.cn/guide/architecture-components#pipes)
- [服务与依赖注入简介](https://angular.cn/guide/architecture-services)

当你熟悉了这些基础构造块之后，就可以在本文档中进一步查看它们的详情了。要学习能帮你构建和发布 Angular 应用的更多工具和技巧，参阅[后续步骤：工具与技巧](https://angular.cn/guide/architecture-next-steps)。