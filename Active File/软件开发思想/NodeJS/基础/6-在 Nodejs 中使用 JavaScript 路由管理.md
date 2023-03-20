## 了解 URL 和路由

应用程序具有不同的资源，如产品或订单。 将应用程序划分为资源的各个部分。 使用这些部分将有助于维护和扩展应用。

扩展 Web 应用的一种简单方法是，确保资源可通过专用 URL 进行访问。 两个 URL 将在 Web 应用中触发两个不同的代码部分。

URL 是用户在浏览器等客户端中输入的用于查找特定服务器和特定资源的地址。 了解 URL 的工作原理有助于围绕它组织应用。

下面是一个典型的 URL：

```bash
http://localhost:8000/products/1?page=1&pageSize=20
```

URL 符合如下所示的语法：

```bash
scheme:[//authority]path[?query][#fragment]
```

让我们来解释各个部分。

### Scheme

URL 的方案部分说明协议。 在前面的典型 URL 示例中，方案为 `http`。 其他方案示例为 `https` `ftp` `irc` 和 `file`。

### 颁发机构

机构包含可选用户信息 (username@password) 和主机。 在示例 URL 中，`localhost` 是主机部分，并将你自己的计算机作为 Web 服务器。 在 Web 上，主机部分通常是类似 `google` 或 `microsoft` 的域名。

host 是一个易记名称，你将指定它而不是 IP 地址。 IP 地址是实际的 Web 地址。 这是一系列数字，如 `127.0.0.1`。 通过 IP 地址，路由器很容易将请求从 Web 的一部分路由到另一部分。 然而，这并不易记。 主机和域名存在，以便我们可以记住它们。

### 路径

URL 的路径部分包含零至多个段。 每个段由斜线 (`/`) 分割。 在示例 URL 中，唯一的段是 `/products`。 段会筛选出你感兴趣的确切资源。

### 查询

查询是在问号 (`?`) 字符后定义的 URL 的可选部分。 它包含由 & 号 (`&`) 或分号 (`;`) 分隔的查询参数/值对。 它可以通过请求特定页面中的多条记录来进一步筛选数据。

示例 URL 中的查询为 `?page=1&pageSize=20`。 假设资源上有 200 万条记录。 返回所有这些记录需要很长时间。 如果指定需要 20 条记录，则数据返回速度快且大小较小。

### Fragment

URL 的片段部分可帮助请求内容更加具体。 例如，片段可以按特定顺序排列你请求的数据。

## 路由

路由是 URL 的一个分段，通常指向特定资源。 Express 处理以下更有意义的路由概念。

### 路由参数

URL 中的路由参数表示你想要从集合访问特定资源。

查看路由 `/orders/1/items/2`，路由参数为 `1` 和 `2`。 `1` 表示想要访问具有唯一键 `1` 的特定订单。 `2` 请求具有唯一键 `2` 的特定订单项。 这些路由参数返回特定资源，而不是某一特定类型的所有资源。

Express 定义路由，并将不同处理程序与它们关联。 处理程序是在存在匹配的特定路径时调用的代码。 Express 具有管理不同路由的模式处理机制。 下表显示了将不同路由表示为路由模式。

| 路由                        | Express 路由模式              |
| :-------------------------- | :---------------------------- |
| /products                   | products/                     |
| /products/1 和 products/114 | products/:id                  |
| /orders/1/items/2           | orders/:orderId/items/:itemId |
| xyz                         | **                            |

编写代码以匹配 `/products/114` 的表，如下所示：

```javascript
app.get('/products/:id', (req, res) => {
  // handle this request `req.params.id`
})
```

路由参数写入请求对象 `req` 上的 `params` 属性中。 `/products/114` 的请求将使 `req.params.id` 包含 `114`。

### 查询参数

URL 的查询部分是 `?` 字符后存在的一组键/值对。 路由示例 `/products?page=1&pageSize=20` 介绍了查询参数 `page` 和 `pageSize`。 这两个参数协同工作以帮助筛选和缩小返回的响应。

假设路由 `/products` 从数据库中返回 200 万条记录。 该响应将会巨大，且需要很长时间才能显示。 这样用户体验差，且会对应用造成压力。 一种更好的方法是使用查询参数来限制响应的大小。

Express 具有一种处理查询参数的简单方法。 考虑到路由 `/products?page=1&pageSize=20`，查询参数会写入到 `res` 请求对象上的查询对象，如以下示例所示：

```javascript
app.get('/products', (req, res) => {
  // handle this request `req.query.page` and `req.query.pageSize`
})
```

若要使用路由 `/products?page=1&pageSize=20` 创建请求，`req.query` 具有以下值：

```javascript
{
  page: 1,
  pageSize: 20
}
```

### 常规模式管理

到目前为止，已经看到类似 `/products` 和 `/orders/1/items/2` 的简单路由。 还存在 `**` 等其他模式，这可能意味着“捕获全部”。 通常会定义这样的路由，以确保顺利处理意外请求（如拼写错误）。 这样有助于提供良好的用户体验。

### HTTP 谓词

HTTP 谓词表示“操作”。 HTTP 谓词（如 `get` 和 `post`）表示不同的意图。 通过使用谓词 `get`，表示希望从资源读取数据。 谓词 `post` 表示希望向资源写入数据。

Express 具有特定的方法，让你能够将代码关联到特定 URL 片段和 HTTP 谓词。

## 读取和写入

若要处理向 Web 应用程序发送数据的客户端，请根据传入数据的格式以不同的方式配置 Express。 例如，数据可能采用 HTML 或 JSON 格式。 无论数据采用哪种格式，都需要执行这些通用步骤。

1. “导入正文分析器”。 需要将传入数据转换为可读的格式。 导入随 Express 一起安装的库 `body-parser`：

   ```javascript
   let bodyParser = require('body-parser');
   ```

2. 配置数据。 配置 Express 以将传入的正文数据分析为预期格式。 以下代码将数据转换为 JSON：

   ```javascript
   app.use(bodyParser.json({ extended: false }));
   ```

客户端发送的数据现在可用于 `req` 请求对象上的 `body` 属性。 现在，你可以读取此数据并与数据源对话。 然后，还可以从该数据创建资源或更新资源，具体取决于请求使用 POST 还是 PUT 谓词。