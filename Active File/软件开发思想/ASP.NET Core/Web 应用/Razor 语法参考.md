Razor 是一种标记语法，用于将基于 .NET 的代码嵌入网页中。 Razor 语法由 Razor 标记、C# 和 HTML 组成。 包含 Razor 的文件通常具有 `.cshtml` 文件扩展名。 Razor也可以在组件文件中找到[Razor](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/?view=aspnetcore-7.0) (`.razor`) 。 Razor 语法类似于各种 JavaScript 单页应用程序 (SPA) 框架（如 Angular、React、VueJs 和 Svelte）的模板化引擎。 有关详细信息，请参阅[使用 JavaScript 服务在 ASP.NET Core 中创建单页应用程序](https://learn.microsoft.com/zh-cn/aspnet/core/client-side/spa-services?view=aspnetcore-7.0)。

## Razor 语法

Razor 支持 C#，并使用 `@` 符号从 HTML 转换为 C#。 Razor 计算 C# 表达式，并将它们呈现在 HTML 输出中。

`@`当符号后跟[Razor保留关键字](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#razor-reserved-keywords)时，它将转换为Razor特定的标记。 否则会转换为纯 HTML。

若要对 Razor 标记中的 `@` 符号进行转义，请使用另一个 `@` 符号：

```cshtml
<p>@@Username</p>
```

该代码在 HTML 中使用单个 `@` 符号呈现：

```html
<p>@Username</p>
```

包含电子邮件地址的 HTML 属性和内容不将 `@` 符号视为转换字符。 Razor 分析不会处理以下示例中的电子邮件地址：

```cshtml
<a href="mailto:Support@contoso.com">Support@contoso.com</a>
```

## 隐式 Razor 表达式

隐式 Razor 表达式以 `@` 开头，后跟 C# 代码：

```cshtml
<p>@DateTime.Now</p>
<p>@DateTime.IsLeapYear(2016)</p>
```

隐式表达式不能包含空格，但 C# `await` 关键字除外。 如果该 C# 语句具有明确的结束标记，则可以混用空格：

```cshtml
<p>@await DoSomething("hello", "world")</p>
```

隐式表达式**不能**包含 C# 泛型，因为括号 (`<>`) 内的字符会被解释为 HTML 标记。 以下代码**无**效：

```cshtml
<p>@GenericMethod<int>()</p>
```

上述代码生成与以下错误之一类似的编译器错误：

- "int" 元素未结束。 所有元素都必须自结束或具有匹配的结束标记。
- 无法将方法组 "GenericMethod" 转换为非委托类型 "object"。 是否希望调用此方法?`

泛型方法调用必须包装在 [显式 Razor 表达式](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#explicit-razor-expressions) 或 [Razor 代码块](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#razor-code-blocks)中。

## 显式 Razor 表达式

显式 Razor 表达式由 `@` 符号和平衡圆括号组成。 若要呈现上一周的时间，可使用以下 Razor 标记：

```cshtml
<p>Last week this time: @(DateTime.Now - TimeSpan.FromDays(7))</p>
```

将计算 `@()` 括号中的所有内容，并将其呈现到输出中。

前面部分中所述的隐式表达式通常不能包含空格。 在下面的代码中，不会从当前时间减去一周：

```cshtml
<p>Last week: @DateTime.Now - TimeSpan.FromDays(7)</p>
```

该代码呈现以下 HTML：

```html
<p>Last week: 7/7/2016 4:39:52 PM - TimeSpan.FromDays(7)</p>
```

可以使用显式表达式将文本与表达式结果串联起来：

```cshtml
@{
    var joe = new Person("Joe", 33);
}

<p>Age@(joe.Age)</p>
```

如果不使用显式表达式，`<p>Age@joe.Age</p>` 会被视为电子邮件地址，因此会呈现 `<p>Age@joe.Age</p>`。 如果编写为显式表达式，则呈现 `<p>Age33</p>`。

显式表达式可用于呈现 `.cshtml` 文件中泛型方法的输出。 以下标记显示了如何更正之前出现的由 C# 泛型的括号引起的错误。 此代码以显式表达式的形式编写：

```cshtml
<p>@(GenericMethod<int>())</p>
```

## 表达式编码

计算结果为字符串的 C# 表达式采用 HTML 编码。 计算结果为 `IHtmlContent` 的 C# 表达式直接通过 `IHtmlContent.WriteTo` 呈现。 计算结果不为 `IHtmlContent` 的 C# 表达式通过 `ToString` 转换为字符串，并在呈现前进行编码。

```cshtml
@("<span>Hello World</span>")
```

上述代码呈现以下 HTML：

```html
&lt;span&gt;Hello World&lt;/span&gt;
```

HTML 在浏览器中显示为纯文本：

`<span>Hello World</span>`

`HtmlHelper.Raw` 输出不进行编码，但呈现为 HTML 标记。

```cshtml
@Html.Raw("<span>Hello World</span>")
```

该代码呈现以下 HTML：

```html
<span>Hello World</span>
```

## Razor 代码块

Razor 代码块以 `@` 开始，并括在 `{}` 中。 代码块内的 C# 代码不会呈现，这点与表达式不同。 一个视图中的代码块和表达式共享相同的作用域并按顺序进行定义：

```cshtml
@{
    var quote = "The future depends on what you do today. - Mahatma Gandhi";
}

<p>@quote</p>

@{
    quote = "Hate cannot drive out hate, only love can do that. - Martin Luther King, Jr.";
}

<p>@quote</p>
```

该代码呈现以下 HTML：

```html
<p>The future depends on what you do today. - Mahatma Gandhi</p>
<p>Hate cannot drive out hate, only love can do that. - Martin Luther King, Jr.</p>
```

在代码块中，使用标记将[本地函数](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/local-functions)声明为用作模板化方法：

```cshtml
@{
    void RenderName(string name)
    {
        <p>Name: <strong>@name</strong></p>
    }

    RenderName("Mahatma Gandhi");
    RenderName("Martin Luther King, Jr.");
}
```

该代码呈现以下 HTML：

```html
<p>Name: <strong>Mahatma Gandhi</strong></p>
<p>Name: <strong>Martin Luther King, Jr.</strong></p>
```

### 隐式转换

代码块中的默认语言是 C#，但 Razor 页面可以转换回 HTML：

```cshtml
@{
    var inCSharp = true;
    <p>Now in HTML, was in C# @inCSharp</p>
}
```

### 带分隔符的显式转换

若要定义应呈现 HTML 的代码块子节，请使用 Razor`<text>` 标记将要呈现的字符括起来：

```
@for (var i = 0; i < people.Length; i++)
{
    var person = people[i];
    <text>Name: @person.Name</text>
}
```

使用此方法可呈现未被 HTML 标记括起来的 HTML。 如果没有 HTML 或 Razor 标记，则会发生 Razor 运行时错误。

`<text>` 标记可用于在呈现内容时控制空格：

- 仅呈现 `<text>` 标记之间的内容。
- `<text>` 标记之前或之后的空格不会显示在 HTML 输出中。

### 显式行转换

要在代码块内以 HTML 形式呈现整个行的其余内容，请使用 `@:` 语法：

```cshtml
@for (var i = 0; i < people.Length; i++)
{
    var person = people[i];
    @:Name: @person.Name
}
```

如果代码中没有 `@:`，会生成 Razor 运行时错误。

Razor 文件中多余的 `@` 字符可能会导致代码块中后面的语句发生编译器错误。 这些编译器错误可能难以理解，因为实际错误发生在报告的错误之前。 将多个隐式/显式表达式合并到单个代码块以后，经常会发生此错误。

## 控制结构

控制结构是对代码块的扩展。 代码块的各个方面（转换为标记、内联 C#）同样适用于以下结构：

### 条件 `@if, else if, else, and @switch`

`@if` 控制何时运行代码：

```cshtml
@if (value % 2 == 0)
{
    <p>The value was even.</p>
}
```

`else` 和 `else if` 不需要 `@` 符号：

```cshtml
@if (value % 2 == 0)
{
    <p>The value was even.</p>
}
else if (value >= 1337)
{
    <p>The value is large.</p>
}
else
{
    <p>The value is odd and small.</p>
}
```

以下标记展示如何使用 switch 语句：

```cshtml
@switch (value)
{
    case 1:
        <p>The value is 1!</p>
        break;
    case 1337:
        <p>Your number is 1337!</p>
        break;
    default:
        <p>Your number wasn't 1 or 1337.</p>
        break;
}
```

### 循环 `@for, @foreach, @while, and @do while`

可以使用循环控制语句呈现模板化 HTML。 若要呈现一组人员：

```cshtml
@{
    var people = new Person[]
    {
          new Person("Weston", 33),
          new Person("Johnathon", 41),
          ...
    };
}
```

支持以下循环语句：

`@for`

```cshtml
@for (var i = 0; i < people.Length; i++)
{
    var person = people[i];
    <p>Name: @person.Name</p>
    <p>Age: @person.Age</p>
}
```

`@foreach`

```cshtml
@foreach (var person in people)
{
    <p>Name: @person.Name</p>
    <p>Age: @person.Age</p>
}
```

`@while`

```cshtml
@{ var i = 0; }
@while (i < people.Length)
{
    var person = people[i];
    <p>Name: @person.Name</p>
    <p>Age: @person.Age</p>

    i++;
}

```

`@do while`

```cshtml
@{ var i = 0; }
@do
{
    var person = people[i];
    <p>Name: @person.Name</p>
    <p>Age: @person.Age</p>

    i++;
} while (i < people.Length);
```

### 复合语句 `@using`

在 C# 中，`using` 语句用于确保释放对象。 在 Razor 中，可使用相同的机制来创建包含附加内容的 HTML 帮助程序。 在下面的代码中，HTML 帮助程序使用 `@using` 语句呈现 `<form>` 标记：

```cshtml
@using (Html.BeginForm())
{
    <div>
        Email: <input type="email" id="Email" value="">
        <button>Register</button>
    </div>
}
```

### `@try, catch, finally`

异常处理与 C# 类似：

```cshtml
@try
{
    throw new InvalidOperationException("You did something invalid.");
}
catch (Exception ex)
{
    <p>The exception message: @ex.Message</p>
}
finally
{
    <p>The finally statement.</p>
}
```

### `@lock`

Razor 可以使用 lock 语句来保护关键节：

```cshtml
@lock (SomeLock)
{
    // Do critical section work
}
```

### 注释

Razor 支持 C# 和 HTML 注释：

```cshtml
@{
    /* C# comment */
    // Another C# comment
}
<!-- HTML comment -->
```

该代码呈现以下 HTML：

```html
<!-- HTML comment -->
```

在呈现网页之前，服务器会删除 Razor 注释。 Razor 使用 `@* *@` 来分隔注释。 以下代码已被注释禁止，因此服务器不呈现任何标记：

```cshtml
@*
    @{
        /* C# comment */
        // Another C# comment
    }
    <!-- HTML comment -->
*@
```

## 指令

Razor 指令由隐式表达式表示：`@` 符号后跟保留关键字。 指令通常用于更改视图分析方式或启用不同的功能。

通过了解 Razor 如何为视图生成代码，更易理解指令的工作原理。

```cshtml
@{
    var quote = "Getting old ain't for wimps! - Anonymous";
}

<div>Quote of the Day: @quote</div>
```

该代码生成与下面类似的类：

```csharp
public class _Views_Something_cshtml : RazorPage<dynamic>
{
    public override async Task ExecuteAsync()
    {
        var output = "Getting old ain't for wimps! - Anonymous";

        WriteLiteral("/r/n<div>Quote of the Day: ");
        Write(output);
        WriteLiteral("</div>");
    }
}
```

本文的后面部分， [检查 Razor 为视图生成的 C# 类](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#inspect-the-razor-c-class-generated-for-a-view) 介绍了如何查看此生成的类。

[ASP.NET Core 的 Razor 语法参考 | Microsoft Learn](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/razor#directives)