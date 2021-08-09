## 对象



### 文本和属性

我们可以在创建对象的时候，立即将一些属性以键值对的形式放到 {...} 中。

```js
let user = { // 一个对象
    name: "John", // 键 "name"，值 "John"
    age: 30 // 键 "age"，值 30
};
```

我们可以随时添加、删除和读取文件。

我们可以用 delete 操作符移除属性：

```js
delete user.age;
```

我们也可以用多字词语来作为属性名，但必须给它们加上引号：

```js
let user = {
    name: "John",
    age: 30,
    "likes birds": true // 多词属性名必须加引号
}
```



### 方括号

对于多词属性，点操作就不能用了：

```js
// 这将提示有语法错误
user.likes birds = true;
```

JavaScript 理解不了。它认为我们在处理 user.likes ，然后在遇到意外的 birds 时给出了语 法错误。

点符号要求 key 是有效的变量标识符。这意味着：不包含空格，不以数字开头，也不包含特殊字 符（允许使用 $ 和 _ ）。

有另一种方法，就是使用方括号，可用于任何字符串：

```js
let user = {};

user["like birds"] = true;

console.log(user["like birds"]);

delete user["like birds"];
```



### 计算属性

当创建一个对象时，我们可以在对象字面量中使用方括号。这叫做 计算属性。 

例如：

```js
let fruit = "apple";

let bag = {
    [fruit]: 5,
};

console.log(bag.apple);
```

使用方括号更好：

```js
console.log(bag[fruit]);
```

我们可以在方括号中使用更复杂的表达式。

方括号比点符号更强大。它允许任何属性名和变量，但写起来也更加麻烦。

 所以，大部分时间里，当属性名是已知且简单的时候，就使用点符号。如果我们需要一些更复杂的 内容，那么就用方括号。



### 属性值简写

在实际开发中，我们通常用已存在的变量当做属性名。 

例如：

```js
function makeUser(name, age) {
    return {
        name: name,
        age: age,
        // ……其他的属性
    };
}
```

在上面的例子中，属性名跟变量名一样。这种通过变量生成属性的应用场景很常见，在这有一种特 殊的 **属性值缩写** 方法，使属性名变得更短。

```js
function makeUser(name, age) {
    return {
        name, // 与 name: name 相同
        age, // 与 age: age 相同
        // ...
    };
}
```



### 属性存在性测试，“in” 操作符

相比于其他语言，JavaScript 的对象有一个需要注意的特性：能够被访问任何属性。

即使属性不存 在也不会报错！ 读取不存在的属性只会得到 undefined 。所以我们可以很容易地判断一个属性是否存在：

```js
let user = {};

console.log(user.noSuchProperty == undefined);//true
```

这里还有一个特别的，检查属性是否存在的操作符 "in" 。 

例如：

```js
let user = {
    name: 'John',
    age: 30,
};

console.log('name' in user);
```

请注意， in 的左边必须是 属性名。通常是一个带引号的字符串。

确实，大部分情况下与 undefined 进行比较来判断就可以了。但有一个例外情况，这种比对方 式会有问题，但 in 运算符的判断结果仍是对的。

那就是属性存在，但存储的值是 **undefined** 的时候。

这种情况很少发生，因为通常情况下不应该给对象赋值 undefined 。我们通常会用 null 来表 示未知的或者空的值。因此， in 运算符是代码中的特殊来宾。



### “for…in” 循环

为了遍历一个对象的所有键（key），可以使用一个特殊形式的循环： for..in 。这跟我们在前 面学到的 for(;;) 循环是完全不一样的东西。

例如，让我们列出 user 所有的属性：

```js
let user = {
    name: "John",
    age: 30,
    isAdmin: true,
};

for (let key in user) {
    console.log(key);
    console.log(user[key]);
}
```



## 对象引用和复制



### 通过引用来比较

仅当两个对象为同一对象时，两者才相等。



### 克隆与合并，Object.assign

如果我们真的想要这样做，那么就需要创建一个新对象，并通过遍历现有属性的结构，在原 始类型值的层面，将其复制到新对象，以复制已有对象的结构。

```js
let user =
{
    name: 'John',
    age: 30,
};

let clone = {};

for (let key in user) {
    clone[key] = user[key];
}

clone.name = "Peter";

console.log(user.name);
```

我们也可以使用 Object.assign 方法来达成同样的效果。

语法是：

```js
Object.assign(dest, [src1, src2, src3...])
```

例如，我们可以用它来合并多个对象：

```js
let user = { name: "John" };
let permissions1 = { canView: true };
let permissions2 = { canEdit: true };
// 将 permissions1 和 permissions2 中的所有属性都拷贝到 user 中
Object.assign(user, permissions1, permissions2);
```



### 深层克隆

到现在为止，我们都假设 user 的所有属性均为原始类型。但属性可以是对其他对象的引用。那 应该怎样处理它们呢？

例如：

```js
let user = {
    name: "John",
    sizes: {
        height: 182,
        width: 50
    }
};
console.log(user.sizes.height); // 182
```

现在这样拷贝 `clone.sizes = user.sizes` 已经不足够了，因为 user.sizes 是个对象， 它会以引用形式被拷贝。因此 clone 和 user 会共用一个 sizes。

为了解决此问题，我们应该使用会检查每个 user[key] 的值的克隆循环，如果值是一个对象， 那么也要复制它的结构。这就叫“深拷贝”。

我们可以用递归来实现。或者不自己造轮子，使用现成的实现，例如 JavaScript 库 lodash 中 的 _.cloneDeep(obj)  。



## 垃圾回收

对于开发者来说，JavaScript 的内存管理是自动的、无形的。我们创建的原始值、对象、函数…… 这一切都会占用内存。

当我们不再需要某个东西时会发生什么？JavaScript 引擎如何发现它并清理它？



### 可达性（Reachability）

JavaScript 中主要的内存管理概念是 **可达性**。

简而言之，“可达”值是那些以某种方式可访问或可用的值。它们一定是存储在内存中的。



## 对象方法，"this"



### 方法中的 “this”

通常，对象方法需要访问对象中存储的信息才能完成其工作。 

例如， user.sayHi() 中的代码可能需要用到 user 的 name 属性。

**为了访问该对象，方法中可以使用 this 关键字。** 

this 的值就是在点之前的这个对象，即调用该方法的对象。

```js
let user =
{
    name: "John",
    age: 30,

    sayHi() {
        console.log(this.name);
    }
};

user.sayHi();
```

在这里 user.sayHi() 执行过程中， this 的值是 user 。 

技术上讲，也可以在不使用 this 的情况下，通过外部变量名来引用它。

……但这样的代码是不可靠的。如果我们决定将 user 复制给另一个变量，例如 admin = user ，并赋另外的值给 user ，那么它将访问到错误的对象。

```js
let user = {
    name: "John",
    age: 30,
    sayHi() {
        alert( user.name ); // 导致错误
    }
};

let admin = user;
user = null; // 重写让其更明显
admin.sayHi(); // TypeError: Cannot read property 'name' of null
```



### “this” 不受限制

在 JavaScript 中， this 关键字与其他大多数编程语言中的不同。JavaScript 中的 this 可以用 于任何函数，即使它不是对象的方法。

**this 的值是在代码运行时计算出来的，它取决于代码上下文。**

例如，这里相同的函数被分配给两个不同的对象，在调用中有着不同的 “this” 值：

```js
'use strict';

let user = { name: 'John' };
let admin = { name: 'Admin' };

function sayHi() {
    console.log(this.name);
}

user.f = sayHi;
admin.f = sayHi;

user.f();//John
admin.f();//Admin
```



### 在没有对象的情况下调用： this == undefined

我们甚至可以在没有对象的情况下调用函数：

```js
function sayHi() {
    alert(this);
}
sayHi(); // undefined
```

在这种情况下，严格模式下的 this 值为 undefined 。如果我们尝试访问 this.name ， 将会报错。

在非严格模式的情况下， this 将会是 全局对象（浏览器中的 window ，我们稍后会在 全局 对象 一章中学习它）。这是一个历史行为， "use strict" 已经将其修复了。

 通常这种调用是程序出错了。如果在一个函数内部有 this ，那么通常意味着它是在对象上下 文环境中被调用的。



### 箭头函数没有自己的 “this”

箭头函数有些特别：它们没有自己的 this 。如果我们在这样的函数中引用 this ， this 值取 决于外部“正常的”函数。

举个例子，这里的 arrow() 使用的 this 来自于外部的 user.sayHi() 方法：

```js
let user = {
    firstName: "Ilya",
    sayHi() {
        let arrow = () => console.log(this.firstName);
        arrow();
    }
}

user.sayHi();//Ilya
```

这是箭头函数的一个特性，当我们并不想要一个独立的 this ，反而想从外部上下文中获取时， 它很有用。



## 构造器和操作符 "new"

常规的 {...} 语法允许创建一个对象。但是我们经常需要创建许多类似的对象，例如多个用户或菜单项等。
这可以使用构造函数和 "new" 操作符来实现。



### 构造函数

构造函数在技术上是常规函数。不过有两个约定：

1.  它们的命名以大写字母开头。
2.  它们只能由 "new" 操作符来执行。

```js
function User(name) {
    // this = {};（隐式创建）
    
    // 添加属性到 this
    this.name = name;
    this.isAdmin = false;
    
    // return this;（隐式返回）
}
```



### new function() { … }

如果我们有许多行用于创建单个复杂对象的代码，我们可以将它们封装在构造函数中，像这样：

```js
let user = new function() {
    this.name = "John";
    this.isAdmin = false;
    // ……用于用户创建的其他代码
    // 也许是复杂的逻辑和语句
    // 局部变量等
};
```

构造器不能被再次调用，因为它不保存在任何地方，只是被创建和调用。因此，这个技巧旨在封装构建单个对象的代码，而无需将来重用。



### 构造器模式测试：new.target

在一个函数内部，我们可以使用 new.target 属性来检查它是否被使用 new 进行调用了。对于常规调用，它为空，对于使用 new 的调用，则等于该函数。



### 构造器的 return

通常，构造器没有 return 语句。它们的任务是将所有必要的东西写入 this ，并自动转换为结果。

但是，如果这有一个 return 语句，那么规则就简单了：

-   如果 return 返回的是一个对象，则返回这个对象，而不是 this 。
-   如果 return 返回的是一个原始类型，则忽略。

例如：

```js
function BigUser() {
    this.name = "John";
    return { name: "Godzilla" };
    // <-- 返回这个对象
}

alert( new BigUser().name );
// Godzilla，得到了那个对象
```



### 构造器中的方法

我们不仅可以将属性添加到 this 中，还可以添加方法。

```js
function User(name) {
    this.name = name;
    this.sayHi = function() {
        console.log( "My name is: " + this.name );
    };
}
```



## 可选链 "?."

如果可选链 ?. 前面的部分是 undefined 或者 null ，它会停止运算并返回该部分。

```js
let user = {}; // user 没有 address 属性
alert( user?.address?.street ); // undefined（不报错）
```



### ?. 前的变量必须已声明

?. 前的变量必须已声明（例如 let/const/var user 或作为一个函数参数）。可选链仅适用于已声明的变量。



### 短路效应

正如前面所说的，如果 ?. 左边部分不存在，就会立即停止运算（“短路效应”）。

所以，如果后面有任何函数调用或者副作用，它们均不会执行。



### 其它变体：?.()，?.[]

可选链 ?. 不是一个运算符，而是一个特殊的语法结构。它还可以与函数和方括号一起使用。

例如，将 ?.() 用于调用一个可能不存在的函数。

如果我们想使用方括号 [] 而不是点符号 . 来访问属性，语法 ?.[] 也可以使用。跟前面的例子类似，它允许从一个可能不存在的对象上安全地读取属性。



### 我们可以使用 ?. 来安全地读取或删除，但不能写入

可选链 ?. 不能用在赋值语句的左侧。



## Symbol 类型

根据规范，对象的属性键只能是字符串类型或者 Symbol 类型。不是 Number，也不是 Boolean，只有字符串或 Symbol 这两种类型。

“Symbol” 值表示唯一的标识符。可以使用 Symbol() 来创建这种类型的值：

```js
// id 是 symbol 的一个实例化对象
let id = Symbol();
```

创建时，我们可以给 Symbol 一个描述（也称为 Symbol 名），这在代码调试时非常有用：

```js
// id 是描述为 "id" 的 Symbol
let id = Symbol("id");
```

Symbol 保证是唯一的。即使我们创建了许多具有相同描述的 Symbol，它们的值也是不同。描述只是一个标签，不影响任何东西。

例如，这里有两个描述相同的 Symbol —— 它们不相等：

```js
let id1 = Symbol("id");
let id2 = Symbol("id");

alert(id1 == id2); // false
```



### “隐藏”属性

Symbol 允许我们创建对象的“隐藏”属性，代码的任何其他部分都不能意外访问或重写这些属性。

例如，如果我们使用的是**属于第三方代码的** user 对象，我们想要给它们添加一些标识符。我们可以给它们使用 Symbol 键：

```js
let user = {
    name: "John"
};

let id = Symbol("id");
user[id] = 1;

console.log(user[id]);
```

因为 user 对象属于其他的代码，那些代码也会使用这个对象，所以我们不应该在它上面直接添加任何字段，这样很不安全。但是你添加的 Symbol 属性不会被意外访问到，第三方代码根本不会看到它，所以使用 Symbol 基本上不会有问题。



### 对象字面量中的 Symbol

果我们要在对象字面量 {...} 中使用 Symbol，则需要使用方括号把它括起来。

```js
let id = Symbol("id");
let user = {
    name: "John",
    [id]: 123 // 而不是 "id"：123
};
```



### Symbol 在 for…in 中会被跳过

Symbol 属性不参与 for..in 循环。

Object.keys(user) 也会忽略它们。这是一般“隐藏符号属性”原则的一部分。如果另一个脚本或库遍历我们的对象，它不会意外地访问到符号属性。

相反，Object.assign会同时复制字符串和 symbol 属性，这里并不矛盾，就是这样设计的。这里的想法是当我们克隆或者合并一个 object 时，通常希望所有属性被复制（包括像 id 这样的 Symbol）。



### 全局 symbol

正如我们所看到的，通常所有的 Symbol 都是不同的，即使它们有相同的名字。但有时我们想要名字相同的 Symbol 具有相同的实体。例如，应用程序的不同部分想要访问的 Symbol "id" 指的是完全相同的属性。

为了实现这一点，这里有一个 **全局 Symbol 注册表**。我们可以在其中创建 Symbol 并在稍后访问它们，它可以确保每次访问相同名字的 Symbol 时，返回的都是相同的 Symbol。

要从注册表中读取（不存在则创建）Symbol，请使用 Symbol.for(key) 。

该调用会检查全局注册表，如果有一个描述为 key 的 Symbol，则返回该 Symbol，否则将创建一个新 Symbol（ Symbol(key) ），并通过给定的 key 将其存储在注册表中。

```js
let id = Symbol.for("id");

let idAgain = Symbol.for("id");

console.log(id == idAgain);//true
```



### Symbol.keyFor

对于全局 Symbol，不仅有 Symbol.for(key) 按名字返回一个 Symbol，还有一个反向调用：Symbol.keyFor(sym) ，它的作用完全反过来：通过全局 Symbol 返回一个名字。

```js
let sym = Symbol.for("name");
let sym2 = Symbol.for("id");

console.log(Symbol.keyFor(sym));
console.log(Symbol.keyFor(sym2));
```

Symbol.keyFor 内部使用全局 Symbol 注册表来查找 Symbol 的键。所以它不适用于非全局Symbol。如果 Symbol 不是全局的，它将无法找到它并返回 undefined 。

```js
let globalSymbol = Symbol.for("name");
let localSymbol = Symbol("name");
alert( Symbol.keyFor(globalSymbol) ); // name，全局 Symbol
alert( Symbol.keyFor(localSymbol) ); // undefined，非全局
alert( localSymbol.description ); // name
```



### 系统 Symbol

JavaScript 内部有很多“系统” Symbol，我们可以使用它们来微调对象的各个方面。



## 对象 — 原始值转换

1. 所有的对象在布尔上下文（context）中均为 true 。所以对于对象，不存在 to-boolean 转换，只有字符串和数值转换。
2. 数值转换发生在对象相减或应用数学函数时。例如， Date 对象（将在 日期和时间 一章中介绍）可以相减， date1 - date2 的结果是两个日期之间的差值。
3. 至于字符串转换 —— 通常发生在我们像 alert(obj) 这样输出一个对象和类似的上下文中。



### ToPrimitive

我们可以使用特殊的对象方法，对字符串和数值转换进行微调。

下面是三个类型转换的变体，被称为 “hint”，在 规范中有详细介绍（译注：当一个对象被用在需要原始值的上下文中时，例如，在 alert 或数学运算中，对象会被转换为原始值）：

**"string"**

对象到字符串的转换，当我们对期望一个字符串的对象执行操作时，如 “alert”：

```js
// 输出
alert(obj);
// 将对象作为属性键
anotherObj[obj] = 123;
```

**"number"**

对象到数字的转换，例如当我们进行数学运算时：

```js
// 显式转换
let num = Number(obj);

// 数学运算（除了二进制加法）
let n = +obj; // 一元加法
let delta = date1 - date2;

// 小于/大于的比较
let greater = user1 > user2;
```

**"default"**

在少数情况下发生，当运算符“不确定”期望值的类型时。

例如，二进制加法 + 可用于字符串（连接），也可以用于数字（相加），所以字符串和数字这两种类型都可以。因此，当二元加法得到对象类型的参数时，它将依据 "default" hint 来对其进行转换。

此外，如果对象被用于与字符串、数字或 symbol 进行 == 比较，这时到底应该进行哪种转换也不是很明确，因此使用 "default" hint。

```js
// 二元加法使用默认 hint
let total = obj1 + obj2;

// obj == number 使用默认 hint
if (user == 1) { ... };
```



**为了进行转换，JavaScript 尝试查找并调用三个对象方法：**

1. 调用 `obj[Symbol.toPrimitive](hint)` —— 带有 symbol 键Symbol.toPrimitive （系统 symbol）的方法，如果这个方法存在的话，
2. 否则，如果 hint 是 "string" —— 尝试 obj.toString() 和 obj.valueOf() ，无论哪个存在。
3. 否则，如果 hint 是 "number" 或 "default" —— 尝试 obj.valueOf() 和obj.toString() ，无论哪个存在。



### Symbol.toPrimitive

我们从第一个方法开始。有一个名为 Symbol.toPrimitive 的内建 symbol，它被用来给转换方法命名，像这样：

```js
obj[Symbol.toPrimitive] = function(hint) {
    // 返回一个原始值
    // hint = "string"、"number" 和 "default" 中的一个
}
```

在user对象中实现它：

```js
let user = {
    name: "John",
    money: 1000,
    [Symbol.toPrimitive](hint) {
        alert(`hint: ${hint}`);
        return hint == "string" ? `{name: "${this.name}"}` : this.money;
    }
};

// 转换演示：
alert(user); // hint: string -> {name: "John"}
alert(+user); // hint: number -> 1000
alert(user + 500); // hint: default -> 1500
```



### toString/valueOf

方法 toString 和 valueOf 来自上古时代。它们不是 symbol（那时候还没有 symbol 这个概念），而是“常规的”字符串命名的方法。它们提供了一种可选的“老派”的实现转换的方法。

如果没有 Symbol.toPrimitive ，那么 JavaScript 将尝试找到它们，并且按照下面的顺序进行尝试：

- 对于 “string” hint， toString -> valueOf 。
- 其他情况， valueOf -> toString 。

这些方法必须返回一个原始值。如果 toString 或 valueOf 返回了一个对象，那么返回值会忽略（和这里没有方法的时候相同）。

默认情况下，普通对象具有 toString 和 valueOf 方法：

- toString 方法返回一个字符串 "[object Object]" 。
- valueOf 方法返回对象自身。









