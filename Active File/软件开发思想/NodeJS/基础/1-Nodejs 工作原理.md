![img](https://learn.microsoft.com/zh-cn/training/advocates/intro-to-nodejs/media/npm.png)

## 什么是 NodeJS ？

Node.js（简称 Node）是开源服务器端 JavaScript 运行时环境。 可以使用 Node.js 在浏览器以外的多个位置（例如服务器上）运行 JavaScript 应用程序和代码。

Node.js 是名为 [V8](https://nodejs.dev/en/learn/the-v8-javascript-engine/) 的 JavaScript 引擎的包装器，它支持许多浏览器，包括 Google Chrome、Opera 和 Microsoft Edge。 通过在浏览器外使用 V8 引擎，可以使用 Node.js 来运行 JavaScript。 Node.js 还包含在服务器上运行的应用程序可能需要的许多 V8 优化。 例如，Node.js 添加了“缓冲区”类，使 V8 可以处理文件。 这使 Node.js 成为了构建 Web 服务器等的不错选择。

即使你从未使用过 JavaScript 作为主要编程语言，也可选择它来编写功能强大的模块化应用程序。 JavaScript 还具有一些独特的优势。 例如，由于浏览器使用 JavaScript，因此你可以使用 Node.js 在浏览器和服务器之间共享窗体验证规则等逻辑。

随着单页应用程序的兴起，JavaScript 变得越来越重要，并支持广泛使用的 JavaScript 对象表示法 (JSON) 数据交换格式。 许多 NoSQL 数据库技术（例如 CouchDB 和 MongoDB）也将 JavaScript 和 JSON 用作查询和架构格式。 Node.js 使用许多新式服务和框架所使用的语言和技术。

可以使用 Node.js 生成以下类型的应用程序：

- HTTP Web 服务器
- 微服务或无服务器 API 后端
- 用于数据库访问和查询的驱动程序
- 交互式命令行接口
- 桌面应用程序
- 实时物联网 (IoT) 客户端和服务器库
- 适用于桌面应用程序的插件
- 用于文件处理或网络访问的 Shell 脚本
- 机器学习库和模型

## Node.js 的工作原理

Node.js 基于单线程事件循环。 此体系结构模型可高效地处理并发操作。 并发是指事件循环在完成其他工作之后执行 JavaScript 回叫函数的能力。

在此体系结构模型中：

- 单线程是指 JavaScript 只有一个调用堆栈，一次只能执行一项任务。
- 事件循环运行代码，收集和处理事件，并在事件队列中运行下一个子任务。

此上下文中的线程是操作系统可以独立管理的单个编程指令序列。

在 Node.js 中，I/O 操作（例如，读取磁盘文件或对其写入，或者对远程服务器进行网络调用）被视为阻止操作。 阻止操作会阻止所有后续任务，直到该操作完成，然后才能继续下一个操作。 在非阻止模型中，事件循环可以同时运行多个 I/O 操作。

名称“事件循环”描述“忙碌-等待”机制的使用方式，该机制以同步方式等待消息到达，然后再处理消息。 下面显示了一个事件循环实现：

```js
while (queue.wait()) {
  queue.process();
}
```

Node.js 使用事件驱动的体系结构，其中的事件循环处理编排，辅助角色池阻止任务。 事件循环使 Node.js 能够处理并发操作。 下图大致说明了事件循环的工作原理：

![显示 Node.js 如何使用事件驱动的体系结构的关系图，其中的事件循环处理业务流程，辅助角色池阻止任务。](https://learn.microsoft.com/zh-cn/training/advocates/intro-to-nodejs/media/event-loop.svg)

事件循环的主要阶段包括：

- **计时器**处理由 `setTimeout()` 和 `setInterval()` 计划的回叫。
- **回叫**运行挂起的回叫。
- **轮询**检索传入的 I/O 事件并运行与 I/O 相关的回叫。
- **检查**允许完成轮询阶段后立即运行回叫。
- **关闭回叫**关闭事件（例如 `socket.destroy()`）和回叫（例如 `socket.on('close', ...)`）。

Node.js 使用工作线程池来处理阻止任务，例如阻止 I/O 操作以及占用大量 CPU 的任务。

总而言之，事件循环运行为事件注册的 JavaScript 回叫，还负责实现非阻止异步请求（如网络 I/O）。