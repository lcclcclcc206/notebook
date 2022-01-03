# html文档结构

## 声明 HTML 的文档类型

在文档的顶部，我们需要告诉浏览器网页所使用的 HTML 的版本。 HTML 是一个在不停发展的语言，大部分浏览器都支持 HTML 的最新标准，也就是 HTML5。 大部分主流浏览器都支持最新的 HTML5 规范。 但是一些陈旧的网页可能使用的是老版本的 HTML。

你可以通过 `<!DOCTYPE ...>` 来告诉浏览器页面上使用的 HTML 版本，"`...`" 部分就是版本号。 `<!DOCTYPE html>` 对应的就是 HTML5。

`!` 和大写的 `DOCTYPE` 是很重要的，尤其是对那些老的浏览器。 但 `html` 无论大写小写都可以。

所有的 HTML 代码都必须位于 `html` 标签中。 其中 `<html>` 位于 `<!DOCTYPE html>` 之后，`</html>` 位于网页的结尾。

这是一个网页结构的列子。 你的 HTML 代码会在两个 `html` 标签之间。

```html
<!DOCTYPE html>
<html>

</html>
```

## 定义 HTML 文档的 head 和 body

`html` 的结构主要分为两大部分：`head` 和 `body`。 网页的描述应放入 `head` 标签， 网页的内容（向用户展示的）则应放入 `body` 标签。

比如 `link`、`meta`、`title` 和 `style` 都应放入 `head` 标签。

这是网页布局的一个例子：

```html
<!DOCTYPE html>
<html>
  <head>
    <meta />
  </head>
  <body>
    <div>
    </div>
  </body>
</html>
```