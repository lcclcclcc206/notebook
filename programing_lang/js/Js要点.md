## 现代模式，"use strict"

```js
'use strict'
```

这个指令看上去像一个字符串 "use strict" 或者 'use strict' 。当它处于脚本文件的顶 部时，则整个脚本文件都将以“现代”模式进行工作。

>   请确保 "use strict" 出现在脚本的最顶部，否则严格模式可能无法启用。















## 交互：alert、prompt 和 confirm



### **alert**

[alert效果]( .\.code\alert.html	"alert效果")

它会显示一条信息，并等待用户按下 “OK”

```js
alert('Hello');
```

弹出的这个带有信息的小窗口被称为 模态窗。“modal” 意味着用户不能与页面的其他部分（例如点 击其他按钮等）进行交互，直到他们处理完窗口。在上面示例这种情况下 —— 直到用户点击“确 定”按钮。



### prompt

[prompt效果]( .\.code\prompt.html   "prompt效果")

prompt 函数接收两个参数：

```js
result = prompt(title, [default]);
```

浏览器会显示一个带有文本消息的模态窗口，还有 input 框和确定/取消按钮。

**title**:显示给用户的文本 

**default**:可选的第二个参数，指定 input 框的初始值。

```js
let result = prompt('How old are you?', 100);
alert(`You are ${result} years old!`);
```



>   上述语法中 default 周围的方括号表示该参数是可选的，不是必需的。



### confirm

[confirm效果](.\.code\confirm.html)

语法：

```js
result = confirm(question);
```

confirm 函数显示一个带有 question 以及确定和取消两个按钮的模态窗口。 

点击确定返回 true ，点击取消返回 false 。

```js
let isBoss = confirm("Are you the boss?");
alert(isBoss);
```











## Javascript数据类型

JavaScript 中的值都具有特定的类型。例如，字符串或数字。

在 JavaScript 中有 8 种基本的数据类型（译注：7 种原始类型和 1 种引用类型）。



### Number

number 类型代表整数和浮点数。

```js
let n = 123;
n = 12.345;
```

数字可以有很多操作，比如，乘法 * 、除法 / 、加法 + 、减法 - 等等。

除了常规的数字，还包括所谓的“特殊数值（“**special numeric values**”）”也属于这种类型： **Infinity** 、 -**Infinity** 和 **NaN** 。

-   **Infinity** 代表数学概念中的 无穷大。是一个比任何数字都大的特殊值。
-   **NaN** 代表一个计算错误。它是一个不正确的或者一个未定义的数学操作所得到的结果。NaN 是粘性的。任何对 NaN 的进一步操作都会返回 NaN



### BigInt 类

**BigInt** 类型是最近被添加到 JavaScript 语言中的，用于表示任意长度的整数。

可以通过将 n 附加到整数字段的末尾来创建 BigInt 值。

```js
// 尾部的 "n" 表示这是一个 BigInt 类型
const bigInt = 1234567890123456789012345678901234567890n;
```



### String 类型

JavaScript 中的字符串必须被括在引号里。

```js
let str = "Hello";
let str2 = 'Single quotes are ok too';
let phrase = `can embed another ${str}`;
```

反引号是 功能扩展 引号。它们允许我们通过将变量和表达式包装在 ${…} 中，来将它们嵌入到字 符串中。



### Boolean 类型（逻辑类型）

boolean 类型仅包含两个值： true 和 false 。



### “null” 值

特殊的 null 值不属于上述任何一种类型。 它构成了一个独立的类型，只包含 null 值：

```js
let age = null;
```

相比较于其他编程语言，JavaScript 中的 null 不是一个“对不存在的 object 的引用”或者 “null 指针”。 JavaScript 中的 null 仅仅是一个代表“无”、“空”或“值未知”的特殊值。 上面的代码表示 age 是未知的。



### “undefined” 值

特殊值 undefined 和 null 一样自成类型。 

undefined 的含义是 未被赋值 。 

如果一个变量已被声明，但未被赋值，那么它的值就是 undefined ：

```js
let age;
alert(age); // 弹出 "undefined"
```

从技术上讲，可以显式地将 undefined 赋值给变量，……但是不建议这样做。通常，使用 null 将一个“空”或者“未知”的值写入变量中，而 undefined 则保留作为未进行初始化的事物的默认初始值。



### object 类型和 symbol 类型

**object** 类型是一个特殊的类型。 

其他所有的数据类型都被称为“原始类型”，因为它们的值只包含一个单独的内容（字符串、数字或 者其他）。相反， object 则用于储存数据集合和更复杂的实体。 

因为它非常重要，所以我们对其进行单独讲解。在充分学习了原始类型后，我们将会在 对象 一章 中介绍 object 。

symbol 类型用于创建对象的唯一标识符。我们在这里提到 symbol 类型是为了完整性，但我们 要在学完 object 类型后再学习它。

























## Debugger 命令

我们也可以使用 debugger 命令来暂停代码，像这样：

```js
function hello(name) {
    let phrase = `Hello, ${name}!`;
    debugger; // <-- 调试器会在这停止
    say(phrase);
}
```

当我们在一个代码编辑器中并且不想切换到浏览器在开发者工具中查找脚本来设置断点时，这真的 是非常方便。







































## 数字转化，一元运算符 +

加号 + 有两种形式。一种是上面我们刚刚讨论的二元运算符，还有一种是一元运算符。

一元运算符加号，或者说，加号 + 应用于单个值，对数字没有任何作用。但是如果运算元不是数字，加号 + 则会将其转化为数字。

它的效果和 Number(...) 相同，但是更加简短。



















## 字符串操作

获取子字符串，使用 `slice` 或 `substring`

字符串的大/小写转换，使用：`toLowerCase/toUpperCase`

查找子字符串时，使用 `indexOf` 或 `includes/startsWith/endsWith` 进行简单检查

根据语言比较字符串时使用 `localeCompare`，否则将按字符代码进行比较

`str.trim()` —— 删除字符串前后的空格 (“trims”)

`str.repeat(n)` —— 重复字符串 `n` 次

更多内容细节请参见 [手册](https://developer.mozilla.org/zh/docs/Web/JavaScript/Reference/Global_Objects/String)





























​		
