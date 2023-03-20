[Express - 基于 Node.js 平台的 web 应用开发框架 - Express 中文文档 | Express 中文网 (expressjs.com.cn)](https://www.expressjs.com.cn/)

使用 Web 作为运行应用程序的平台。 通过此平台，任何人都可以使用遵守 HTTP 的浏览器、客户端或软件访问你的应用程序。

可以使用 HTML 页面、JavaScript 和 CSS 构建网页。 Node.js 有一个名为 HTTP 的核心模块，可帮助构造 Web 应用程序。 它支持处理读取、写入和使用不同类型的内容的请求。

虽然 Node.js 中的 HTTP 模块功能强大，但它的速度不及使用框架那么快。 若要生成可以处理身份验证和授权等复杂操作的高效 API，还将使用框架。

Node.js 有许多 Web 框架，例如 Hapi、Fastify、Koa 和 Express。 许多开发者都使用 Express。 已经有很长时间了。 API 较为成熟，安全问题已修补等。

## 创建新的 Express 框架 Web 应用程序

公司通常会将大量数据存储在文件系统和数据库中。 他们访问数据的方法是，通过使用 HTTP 的 Web 应用和 API 来提供该数据。

以下是生成 Web 应用程序和 API 时需要考虑的重要概念：

- **路由**：应用程序根据 URL 地址的不同部分划分为不同的部分。
- **支持不同内容类型：**要提供的数据可能以不同的格式存在，例如纯文本、JSON、HTML、CSV 等。
- **身份验证/授权**：某些数据可能是敏感数据。 用户可能需要登录或具有特定角色或权限级别才能访问数据。
- **读取/写入数据**：用户通常需要同时查看和向系统添加数据。 若要添加数据，用户可以在窗体中输入数据或上传文件。
- **面市时间**：若要高效地创建 Web 应用程序和 API，请选择为常见问题提供解决方案的工具和库。 这些选择可帮助开发者尽可能多地将时间花在作业的业务需求上。

## Node.js 中的 HTTP 模块

Node.js 附带内置的 HTTP 模块。 这是一个相当小的模块，用于处理大多数类型的请求。 它支持常见类型的数据，例如标头、URL 和有效负载。

以下类可在整个过程中帮助管理请求：

- `http.Server`：表示 HTTP Server 的实例。 需要指示此对象侦听特定端口和地址上的不同事件。
- `http.IncomingMessage`：此对象是由 `http.Server` 或 `http.ClientRequest` 创建的可读流。 使用它访问状态、标头和数据。
- `http.ServerResponse`：此对象是 HTTP 服务器在内部创建的流。 此类定义响应应有的外观，例如标头的类型和响应内容。

## 示例 Web 应用程序

下面是 Web 应用的一个示例：

```javascript
const http = require('http');
const PORT = 3000;

const server = http.createServer((req, res) => {
  res.writeHead(200, {'Content-Type': 'text/plain'});
  res.end('hello world');
});

server.listen(PORT, () => {
  console.log(`listening on port ${PORT}`)
})
```

此示例使用以下步骤配置应用程序：

1. **创建服务器**：`createServer()` 方法创建 `http.Server` 类的实例。
2. **实现回调**：`createServer()` 方法需要一个称为“回调”的函数。 调用回调时，我们为该方法提供 `http.IncomingMessage` 和 `http.ServerResponse` 类的实例。 在此示例中，我们提供 `req` 和 `res` 实例：
   1. **客户端请求**：`req` 对象调查客户端请求中发送的标头和数据。
   2. **服务器响应**：服务器通过告诉 `res` 对象它应该回复的数据和响应标头来构造响应。
3. **开始侦听请求**：使用指定端口调用 `listen()` 方法。 调用 `listen()` 方法后，服务器即可接受客户端请求。

## 流

“流”不是 Node.js 概念，而是操作系统概念。 流定义数据来回传输的方式。 数据按区块从客户端发送到服务器，并从服务器发送到客户端。 流使服务器能够处理多个并发请求。

流是 Node.js 中的基本数据结构，它可以读取和写入数据，以及发送和接收消息或事件。 在 HTTP 模块中实现流式传输的方式是使用表示流的类。

在我们的示例中，`req` 和 `res` 参数是流。 使用 `on()` 方法侦听来自客户端请求的传入数据，如下所示：

```javascript
req.on('data', (chunk) => {
  console.log('You received a chunk of data', chunk)
})
```

对 `res` 对象响应流中发送回客户端的数据使用 `end()` 方法：

```javascript
res.end('some data')
```

## Express 中的路由管理

目前，你已了解 Node.js 中的 HTTP 模块的功能。 对于较小的 Web 应用程序而言，这是一个非常有效的选择。 如果应用程序变得很大，则 Express 等框架可以帮助你以可缩放的方式构建体系结构。

当客户端向 Web 应用程序发出请求时，它们使用 URL（指向特定服务器的地址）来执行此操作。 URL 可能如下所示：

```bash
http://localhost:3000/products
```

URL 中的术语 `localhost` 指你自己的计算机。 一个看起来更生产化的 URL 可能将术语 `localhost` 转换为了一个域名，例如 `microsoft.com`。 URL 的结尾部分即为路由。 它确定要转到的服务器上的特定位置。 在这种情况下，路由是 `/products`。

Express 框架使用 URL、路由和 HTTP 谓词进行路由管理。 `post`、`put` 和 `get` 等 HTTP 谓词描述了客户端所需的操作。 每个 HTTP 谓词对数据应该发生的情况都有特定的含义。 Express 可帮助注册路由，并将它们与适当的 HTTP 谓词配对以组织 Web 应用程序。

Express 具有用于处理不同 HTTP 谓词的专用方法，并具有用于将不同路由与代码的不同部分相关联的智能系统。 在下面的示例中，Express 可帮助你处理针对路由的请求，该请求具有与 HTTP 谓词 `get` 关联的地址 `/products`：

```javascript
app.get('/products', (req, res) => {
  // handle the request
})
```

Express 看待 `get` 对 `/products` 和 `post` 对 `/products` 不同，如下面的代码示例所示：

```javascript
app.get('/products', (req, res) => {
  // handle the request
})

app.post('/products', (req, res) => {
  // handle the request
})
```

HTTP 谓词 `get` 表示用户想要读取数据。 HTTP 谓词 `post` 表示用户想要写入数据。 划分应用，让不同“路由谓词对”执行代码的不同部分变得有意义。 稍后将更详细地介绍此概念。

## 提供不同的内容类型

Express 支持许多不同的内容格式，这些可以返回给调用客户端。 `res` 对象附带一组帮助程序函数，它们可以返回不同类型的数据。 若要返回纯文本，可使用 `send()` 方法，如下所示：

```javascript
res.send('plain text')
```

对于 JSON 等其他类型的数据，可通过专用方法确保内容类型和数据转换正确。 若要在 Express 中返回 JSON，请使用 `json()` 方法，如下所示：

```javascript
res.json({ id: 1, name: "Catcher in the Rye" })
```

前面的 Express 代码方法等效于此 HTTP 模块代码：

```javascript
res.writeHead(200, { 'Content-Type': 'application/json' });
res.end(JSON.stringify({ id: 1, name: "Catcher in the Rye" }))
```

已在 HTTP 中设置了 `Content-Type` 标头，并且响应也在返回到调用客户端之前从 JavaScript 对象转换为了字符串化版本。

比较这两个代码示例，你可以看到 Express 通过使用用于常见文件类型（如 JSON 和 HTML）的帮助器方法节省了几行输入内容。

## 创建 Express 应用程序

若要开始使用 Express 框架开发 Node.js 应用程序，需要将其安装为依赖项。 此外，还建议首先初始化 Node.js 项目，以便下载的任何依赖项最后都在 package.json 文件中。 这是针对为 Node.js 运行时开发的应用的一般建议。 将代码推送到 GitHub 等存储库时，可以体现出这样做的好处。 从 GitHub 提取代码的任何人都可以通过先安装其依赖项来轻松使用你编写的代码。

按照以下步骤使用 Express 框架创建 Web 应用程序：

1. **实例化应用**：创建 Web 应用程序实例。 此时，实例无法运行，但你可以扩展一些内容。
2. **定义路由和路由处理程序**：定义应用程序应侦听的路由。 路由是 URL 的一部分。 例如，在 URL `http://localhost:8000/products` 中，路由部分为 `/products`。 Express 使用不同的路由来执行不同的代码片段。 其他路由示例包括斜杠 `/`（也称为默认路由）和 `/orders`。 本模块稍后将更详细地探讨路由。
3. **配置中间件**：中间件是可以在请求之前或之后运行的一段代码。 还可以使用中间件来处理身份验证/授权，或向应用添加功能。
4. **启动应用**：定义端口，然后指示应用侦听该端口。 现在，应用已准备好接收请求。

## 使用中间件管理请求生命周期

在某些情况下，当请求到达 Web 应用程序时，你可能需要验证用户是否已登录或是否允许他们查看特定资源。

考虑将请求作为一系列步骤来处理。 如果用户需要登录才能处理请求的资源，则步骤可能如下所示：

1. **Pre 请求**：调查用户是否通过请求标头发送了正确的凭据。 如果验证了凭据，则将请求发送到下一步。
2. **构造响应**：与某种数据源（如数据库或终结点）通信。 只要请求正确请求资源，此步骤就会返回资源。
3. **Post 请求**： 一个可选步骤，用于在请求处理后运行一段代码。 出于日志记录目的，可以运行此步骤。

Express 框架对以此方式处理请求提供内置支持。 若要运行 pre 或 post 请求，需要对 Express 实例化对象实现 `use()` 方法。 Express 中的 pre 或 post 请求称为“中间件”，具有以下语法形式：

```javascript
app.use((req, res, next) => {})
```

传递给 `use()` 方法的方法具有三个参数：`req`、`res` 和 `next`。 这些参数具有以下含义：

- `req`：包含请求标头和调用 URL 的传入请求。 如果客户端随请求发送数据，它也可能具有一个数据主体。
- `res`：用于写入要发送回调用客户端的标头和数据等信息的响应流。
- `next`：指示请求正常并已准备好处理的参数。 如果未调用 `next()`，则请求的处理将停止。 此外，最佳做法是告诉客户端请求未处理的原因，例如调用 `res.send('\<specify a reason why the request is stopped>'\)`。

## 请求管道

如果你的路由从中间件运行 pre 或 post 请求中受益，请设置它，以便：

- 需要在请求之前运行的中间件（pre 请求）定义在实际请求前。
- 需要在请求之后运行的中间件（post 请求）定义在实际请求后。

请看下面的示例：

```javascript
app.use((req, res, next) => {
  // Pre request
})
app.get('/protected-resource', () => {
  // Handle the actual request
})
app.use((req, res, next) => {
  // Post request
})

app.get('/login', () => {})
```

还可以将 pre 请求中间件代码作为处理请求的参数来运行，如下所示：

```javascript
app.get(
  '/<some route>',
 () => {
   // Pre request middleware
 }, () => {
   // Handle the actual request
 })
```