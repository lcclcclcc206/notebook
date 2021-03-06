# CSS颜色

## 使用十六进制编码获得指定颜色

你知道在 CSS 里面还有其他方式来代表颜色吗？ 其中一个方法叫十六进制编码，简称 hex。

日常生活中，我们使用的计数方法一般是 decimals，或十进制，即使用数字 0 到 9 来表示。 而 Hexadecimals（或 hex）基于 16 位数字， 它包括 16 种不同字符。 像十进制一样，0-9 的符号代表 0 到 9 的值。 然后，A、B、C、D、E、F 代表 10 至 15 的值。 总的来说，0 到 F 在十六进制里代表数字，总共有 16 个值。 你可以在[此处](https://www.freecodecamp.org/news/hexadecimal-number-system/)找到更多关于十六进制信息。

在 CSS 里面，我们可以使用 6 个十六进制的数字来代表颜色，每两个数字控制一种颜色，分别是红（R）、绿（G）、蓝（B）。 例如，`#000000` 代表黑色，同时也是最小的值。 你可以在[此处](https://www.freecodecamp.org/news/rgb-color-html-and-css-guide/#whatisthergbcolormodel)找到更多关于 RGB 颜色系统的信息。

```css
body {
  color: #000000;
}
```

## 使用十六进制编码混合颜色

回顾一下，十六进制编码使用 6 个十六进制字符来表示颜色，两个字符为一组，分别代表红（R）、绿（G）、蓝（B）。

通过三原色（红、绿、蓝），我们可以创建 1600 万种不同颜色。

例如，橘色是纯红色混合一些绿色而成，其中没有蓝色。 在十六进制编码里面，它可以写成 `#FFA500`。

`0` 是十六进制里面最小的数字，表示没有颜色。

`F` 是十六进制里面最大的数字，有最高的亮度。

把 `style` 标签里面的颜色值用正确的十六进制编码替换。

|  颜色  | 十六进制编码 |
| :----: | :----------: |
| 道奇蓝 |  `#1E90FF`   |
|  绿色  |  `#00FF00`   |
|  橙色  |  `#FFA500`   |
|  红色  |  `#FF0000`   |

## 使用缩写的十六进制编码

许多人对超过 1600 万种颜色感到不知所措， 并且很难记住十六进制编码。 幸运的是，你可以使用缩写形式。

例如，红色的 `#FF0000` 十六进制编码可以缩写成 `#F00`。 在这种缩写形式里，三个数字分别代表着红（R）、绿（G）、蓝（B）三原色。

这样，颜色的数量减少到了大约 4000 种。 且在浏览器里 `#FF0000` 和 `#F00` 是完全相同的颜色。

## 使用 RGB 值为元素上色

`RGB` 值是在 CSS 中表示颜色的另一种方法。

黑色的 `RGB` 值：

```css
rgb(0, 0, 0)
```

白色的 `RGB` 值：

```css
rgb(255, 255, 255)
```

RGB 值与我们之前学到的十六进制编码不同。`RGB` 值不需要用到 6 位十六进制数字，而只需要指定每种颜色的亮度大小，数值范围从 0 到 255。

如果我们稍微计算一下，就不难发现这两种表示方式本质上是等价的。在十六进制编码中，我们用两个十六进制数表示一个颜色；这样，每种颜色都有 16 * 16（即 256）种可能。 所以，`RGB` 从零开始计算，与十六进制代码的值的数量完全相同。

下面是通过使用 RGB 值设置背景颜色为橘色的例子：`body`。

```css
body {
  background-color: rgb(255, 165, 0);
}
```

## 使用 RGB 混合颜色

就像使用十六进制编码一样，你可以通过不同值的组合，来混合得到不同的 RGB 颜色。

将 `style` 标签里面中的十六进制编码替换为正确的 RGB 值。

|  颜色  |         RGB          |
| :----: | :------------------: |
|  蓝色  |   `rgb(0, 0, 255)`   |
|  红色  |   `rgb(255, 0, 0)`   |
| 淡紫色 | `rgb(218, 112, 214)` |
| 赭黄色 |  `rgb(160, 82, 45)`  |