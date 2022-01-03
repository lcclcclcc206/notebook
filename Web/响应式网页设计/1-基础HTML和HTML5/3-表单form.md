# 表单form

现在让我们来创建一个 Web 表单。

## 创建一个表单

我们可以只通过 HTML 来实现发送数据给服务器的表单， 只需要给 `form` 元素添加 `action` 属性即可。

例如：

```html
<form action="/url-where-you-want-to-submit-form-data">
  <input>
</form>
```

## 给表单添加提交按钮

让我们来给表单添加一个 `submit`（提交）按钮。 点击提交按钮时，表单中的数据将会被发送到 `action` 属性指定的 URL 上。

例如：

```html
<button type="submit">this button submits the form</button>
```

## 给表单添加一个必填字段

当你设计表单时，你可以指定某些字段为必填项（required），只有当用户填写了该字段后，才可以提交表单。

如果你想把文本输入框设置为必填项，在 `input` 元素中加上 `required` 属性就可以了，例如：`<input type="text" required>`

