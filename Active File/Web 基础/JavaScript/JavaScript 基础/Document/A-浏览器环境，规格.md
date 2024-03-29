JavaScript 语言最初是为 Web 浏览器创建的。此后，它已经演变成了一种具有多种用途和平台的语言。

平台可以是一个浏览器，一个 Web 服务器，或其他 **主机（host）**，甚至可以是一个“智能”咖啡机，如果它能运行 JavaScript 的话。它们每个都提供了特定于平台的功能。JavaScript 规范将其称为 **主机环境**。

主机环境提供了自己的对象和语言核心以外的函数。Web 浏览器提供了一种控制网页的方法。Node.JS 提供了服务器端功能，等等。

有一个叫做 `window` 的“根”对象。它有两个角色：

1. 首先，它是 JavaScript 代码的全局对象，如 [全局对象](https://zh.javascript.info/global-object) 一章所述。
2. 其次，它代表“浏览器窗口”，并提供了控制它的方法。

例如，我们可以将它用作全局对象：

```javascript
function sayHi() {
  alert("Hello");
}

// 全局函数是全局对象的方法：
window.sayHi();
```

并且我们可以将它用作浏览器窗口，以查看窗口高度：

```javascript
alert(window.innerHeight); // 内部窗口高度
```

还有更多窗口特定的方法和属性，我们稍后会介绍。

## [文档对象模型（DOM）](https://zh.javascript.info/browser-environment#wen-dang-dui-xiang-mo-xing-dom)

文档对象模型（Document Object Model），简称 DOM，将所有页面内容表示为可以修改的对象。

`document` 对象是页面的主要“入口点”。我们可以使用它来更改或创建页面上的任何内容。

例如：

```javascript
// 将背景颜色修改为红色
document.body.style.background = "red";

// 在 1 秒后将其修改回来
setTimeout(() => document.body.style.background = "", 1000);
```

在这里，我们使用了 `document.body.style`，但还有很多很多其他的东西。规范中有属性和方法的详细描述：[DOM Living Standard](https://dom.spec.whatwg.org/)。

## [浏览器对象模型（BOM）](https://zh.javascript.info/browser-environment#liu-lan-qi-dui-xiang-mo-xing-bom)

浏览器对象模型（Browser Object Model），简称 BOM，表示由浏览器（主机环境）提供的用于处理文档（document）之外的所有内容的其他对象。

例如：

- [navigator](https://developer.mozilla.org/zh/docs/Web/API/Window/navigator) 对象提供了有关浏览器和操作系统的背景信息。navigator 有许多属性，但是最广为人知的两个属性是：`navigator.userAgent` —— 关于当前浏览器，`navigator.platform` —— 关于平台（有助于区分 Windows/Linux/Mac 等）。
- [location](https://developer.mozilla.org/zh/docs/Web/API/Window/location) 对象允许我们读取当前 URL，并且可以将浏览器重定向到新的 URL。

这是我们可以如何使用 `location` 对象的方法：

```javascript
alert(location.href); // 显示当前 URL
if (confirm("Go to Wikipedia?")) {
  location.href = "https://wikipedia.org"; // 将浏览器重定向到另一个 URL
}
```

函数 `alert/confirm/prompt` 也是 BOM 的一部分：它们与文档（document）没有直接关系，但它代表了与用户通信的纯浏览器方法。