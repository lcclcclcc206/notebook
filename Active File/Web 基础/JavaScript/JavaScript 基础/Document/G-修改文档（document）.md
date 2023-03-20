DOM 修改是创建“实时”页面的关键。

在这里，我们将会看到如何“即时”创建新元素并修改现有页面内容。

## [例子：展示一条消息](https://zh.javascript.info/modifying-document#li-zi-zhan-shi-yi-tiao-xiao-xi)

让我们使用一个示例进行演示。我们将在页面上添加一条比 `alert` 更好看的消息。

它的外观如下：

```html
<style>
.alert {
  padding: 15px;
  border: 1px solid #d6e9c6;
  border-radius: 4px;
  color: #3c763d;
  background-color: #dff0d8;
}
</style>

<div class="alert">
  <strong>Hi there!</strong> You've read an important message.
</div>
```

这是一个 HTML 示例。现在，让我们使用 JavaScript 创建一个相同的 `div`（假设样式已经在 HTML/CSS 文件中）。