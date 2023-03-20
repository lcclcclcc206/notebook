HTML 表单的灵活性使它们成为 HTML 中最复杂的结构之一;您可以使用专用的表单元素和属性构建任何类型的基本表单。在构建 HTML 表单时使用正确的结构将有助于确保表单可用性和无障碍。

`<form>` 元素按照一定的格式定义了表单和确定表单行为的属性。当您想要创建一个 HTML 表单时，都必须从这个元素开始，然后把所有内容都放在里面。许多辅助技术或浏览器插件可以发现`<form>` 元素并实现特殊的钩子，使它们更易于使用。

我们早在之前的文章中就遇见过它了。

## <fieldset> 和 <legend> 元素

<fieldset>元素是一种方便的用于创建具有相同目的的小部件组的方式，出于样式和语义目的。你可以在<fieldset>开口标签后加上一个 <legend>元素来给<fieldset> 标上标签。 <legend>的文本内容正式地描述了<fieldset>里所含有部件的用途。

许多辅助技术将使用<legend> 元素，就好像它是相应的 <fieldset> 元素里每个部件的标签的一部分。例如，在说出每个小部件的标签之前，像Jaws或NVDA这样的屏幕阅读器会朗读出 legend 的内容。

这里有一个小例子：

```html
<form>
  <fieldset>
    <legend>Fruit juice size</legend>
    <p>
      <input type="radio" name="size" id="size_1" value="small">
      <label for="size_1">Small</label>
    </p>
    <p>
      <input type="radio" name="size" id="size_2" value="medium">
      <label for="size_2">Medium</label>
    </p>
    <p>
      <input type="radio" name="size" id="size_3" value="large">
      <label for="size_3">Large</label>
    </p>
  </fieldset>
</form>
```

<form>
  <fieldset>
    <legend>Fruit juice size</legend>
    <p>
      <input type="radio" name="size" id="size_1" value="small">
      <label for="size_1">Small</label>
    </p>
    <p>
      <input type="radio" name="size" id="size_2" value="medium">
      <label for="size_2">Medium</label>
    </p>
    <p>
      <input type="radio" name="size" id="size_3" value="large">
      <label for="size_3">Large</label>
    </p>
  </fieldset>
</form>

本例中的用例是最重要的。每当您有一组单选按钮时，您应该将它们嵌套在<fieldset>元素中。还有其他用例，一般来说，<fieldset>元素也可以用来对表单进行分段。理想情况下，长表单应该在拆分为多个页面，但是如果表单很长，却必须在单个页面上，那么将以不同的关联关系划分的分段，分别放在不同的 fieldset 里，可以提高可用性。

因为它对辅助技术的影响， <fieldset> 元素是构建可访问表单的关键元素之一。无论如何，你有责任不去滥用它。如果可能，每次构建表单时，尝试侦听屏幕阅读器如何解释它。如果听起来很奇怪，试着改进表单结构。

## <label> 元素

正如我们在前一篇文章中看到的， <label> 元素是为 HTML 表单小部件定义标签的正式方法。如果你想构建可访问的表单，这是最重要的元素——当实现的恰当时，屏幕阅读器会连同有关的说明和表单元素的标签一起朗读。以我们在上一篇文章中看到的例子为例：

```html
<label for="name">Name:</label> <input type="text" id="name" name="user_name">
```

<label> 标签与 <input> 通过他们各自的for 属性和 id 属性正确相关联（label 的 for 属性和它对应的小部件的 id 属性），这样，屏幕阅读器会读出诸如“Name, edit text”之类的东西。

### [标签也可点击！](https://developer.mozilla.org/zh-CN/docs/Learn/Forms/How_to_structure_a_web_form#标签也可点击！)

正确设置标签的另一个好处是可以在所有浏览器中单击标签来激活相应的小部件。这对于像文本输入这样的例子很有用，这样你可以通过点击标签，和点击输入区效果一样，来聚焦于它，这对于单选按钮和复选框尤其有用——这种控件的可点击区域可能非常小，设置标签来使它们可点击区域变大是非常有用的。

举个例子：

```html
<form>
  <p>
    <input type="checkbox" id="taste_1" name="taste_cherry" value="1">
    <label for="taste_1">I like cherry</label>
  </p>
  <p>
    <input type="checkbox" id="taste_2" name="taste_banana" value="2">
    <label for="taste_2">I like banana</label>
  </p>
</form>
```

<form>
  <p>
    <input type="checkbox" id="taste_1" name="taste_cherry" value="1">
    <label for="taste_1">I like cherry</label>
  </p>
  <p>
    <input type="checkbox" id="taste_2" name="taste_banana" value="2">
    <label for="taste_2">I like banana</label>
  </p>
</form>