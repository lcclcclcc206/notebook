# CSS继承

## 给 HTML 的 body 元素添加样式

现在让我们来讨论一下 CSS 中的继承。

每一个 HTML 页面都有一个 `body` 元素。

我们可以通过设置 `background-color` 的属性值为 黑色，来证明 `body` 元素的存在。

```css
body {
  background-color: black;
}
```

## 从 body 元素继承样式

设置 `body` 元素样式的方法跟设置其他 HTML 元素样式的方式一样，并且其他元素也会继承 `body` 中所设置的样式。

首先，创建一个内容文本为 `Hello World` 的 `h1` 元素。

接着，在 `body` 的 CSS 规则里面添加 `color: green;`，这会将页面内所有字体的颜色都设置为 `green`。

最后，在 `body` 的 CSS 规则里面添加 `font-family: monospace;`，这会将 `body` 内所有元素的字体都设置为 `monospace`。

## 样式中的优先级

有时候，HTML 元素的样式会跟其他样式发生冲突。

就像 `h1` 元素不能同时设置绿色和粉色两种颜色。

让我们尝试创建一个字体颜色为粉色的 class，并应用于其中一个元素中。 猜一猜，它会 *覆盖* `body` 元素的 `color: green;` CSS 规则吗？

class 会覆盖 `body` 的 CSS 样式。

## Class 选择器的优先级高于继承样式

创建一个 `blue-text` class，将元素的颜色设置为蓝色。 将它放在 `pink-text` class 下面。

将 `blue-text` class 应用于 `h1` 元素，看看它和该元素上的 `pink-text` class 哪一个会优先显示。

将多个 class 属性应用于一个 HTML 元素，需以空格来间隔这些属性，例如：

```html
class="class1 class2"
```

**注意：** HTML 元素里应用的 class 的先后顺序无关紧要。

**但是，在 `<style>` 标签里面声明的 `class` 顺序十分重要**，之后的声明会覆盖之前的声明。 第二个声明的优先级始终高于第一个声明。 由于 `.blue-text` 是在后面声明的，所以它的样式会覆盖 `.pink-text` 里的样式。

## ID 选择器优先级高于 Class 选择器

我们刚刚证明了浏览器读取 CSS 是由上到下的。 这就意味着，如果发生冲突，浏览器将会应用最后声明的样式。 注意，如果我们在 `h1` 元素的类中，将 `blue-text` 放置在 `pink-text` 之前，它仍然会检查声明顺序，而不是使用顺序！

但我们还没有完成。 其实还有其他方法可以覆盖 CSS 样式。 你还记得 id 属性吗？

我们来通过给 `h1` 元素添加 id 属性，覆盖 `pink-text` 和 `blue-text` 类，使 `h1` 元素变成橘色。

给 `h1` 元素添加 `id` 属性，属性值为 `orange-text`。 设置方式如下：

```html
<h1 id="orange-text">
```

`h1` 元素需继续保留 `blue-text` 和 `pink-text` 这两个 class。

在 `style` 元素中创建名为 `orange-text` 的 id 选择器。 例子如下：

```css
#brown-text {
  color: brown;
}
```

**注意：** 无论在 `pink-text` class 之前或者之后声明，`id` 选择器的优先级总是高于 class 选择器。

## 内联样式的优先级高于 ID 选择器

我们刚刚证明了，id 选择器无论在 `style` 标签的任何位置声明，都会覆盖 class 声明的样式。

其实还有其他方法可以覆盖 CSS 样式。 你还记得行内样式吗？

使用行内样式尝试让 `h1` 的字体颜色变白。 记住，内联样式看起来是像这样：

```html
<h1 style="color: green;">
```

行内样式会覆盖 `style` 标签里面所有的 CSS 声明。

## Important 的优先级最高

不过， 还有一种方式可以覆盖重新 CSS 样式。 这是所有方法里面最强大的一个。 在此之前，我们要考虑清楚，为什么我们要覆盖 CSS 样式。

很多时候，你会使用 CSS 库， CSS 库中的样式会意外覆盖你的 CSS 样式。 如果想保证你的 CSS 样式不受影响，你可以使用 `!important`。

让我们回到 `pink-text` 类声明。 `pink-text` 类的颜色样式已被之后的 class 声明、id 声明以及行内样式所覆盖。

给粉红文本元素的颜色声明添加关键词 `!important`，以确保 `h1` 元素为粉红色。

如下所示：

```css
color: red !important;
```