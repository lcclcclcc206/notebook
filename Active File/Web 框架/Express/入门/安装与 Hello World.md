假设您已经安装了 [Node.js](https://nodejs.org/)，创建目录以保存应用程序，并将其设置为工作目录。

```console
$ mkdir myapp
$ cd myapp
```

使用 `npm init` 命令为应用程序创建 `package.json` 文件。 有关 `package.json` 工作方式的更多信息，请参阅 [Specifics of npm’s package.json handling](https://docs.npmjs.com/files/package.json)。

```console
$ npm init
```

此命令提示您输入若干项，例如应用程序的名称和版本。 现在，只需按回车键以接受其中大多数项的缺省值，但以下情况例外：

```console
entry point: (index.js)
```

输入 `app.js`，或者您希望使用的任何主文件名称。如果希望文件名为 `index.js`，请按回车键以接受建议的缺省文件名。

在 `myapp` 目录中安装 Express，然后将其保存在依赖项列表中。例如：

```console
$ npm install express
```

要暂时安装 Express 而不将其添加到依赖项列表中：

```console
$ npm install express --no-save
```

在 `myapp` 目录中，创建名为 `app.js` 的文件，然后添加以下代码：

```javascript
const express = require('express')
const app = express()
const port = 3000

app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})
```

应用程序会启动服务器，并在端口 3000 上侦听连接。此应用程序以“Hello World!”响应针对根 URL (`/`) 或*路由*的请求。对于其他所有路径，它将以 **404 Not Found** 进行响应。

使用以下命令运行应用程序：

```console
$ node app.js
```

然后，在浏览器中输入 http://localhost:3000/ 以查看输出。