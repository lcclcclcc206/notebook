## 数组、集合和 LINQ

C# 和 .NET 提供了许多不同的集合类型。 数组包含由语言定义的语法。 泛型集合类型列在 [System.Collections.Generic](https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic) 命名空间中。 专用集合包括 [System.Span](https://learn.microsoft.com/zh-cn/dotnet/api/system.span-1)（用于访问堆栈帧上的连续内存），以及 [System.Memory](https://learn.microsoft.com/zh-cn/dotnet/api/system.memory-1)（用于访问托管堆上的连续内存）。 所有集合（包括数组、[Span](https://learn.microsoft.com/zh-cn/dotnet/api/system.span-1) 和 [Memory](https://learn.microsoft.com/zh-cn/dotnet/api/system.memory-1)）都遵循一种统一的迭代原则。 使用 [System.Collections.Generic.IEnumerable](https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.ienumerable-1) 接口。 这种统一的原则意味着任何集合类型都可以与 LINQ 查询或其他算法一起使用。 你可以使用 [IEnumerable](https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.ienumerable-1) 编写方法，这些算法适用于任何集合。

### 数组

[数组](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/arrays/)是一种数据结构，其中包含许多通过计算索引访问的变量。 数组中的变量（亦称为数组的“元素”）均为同一种类型。 我们将这种类型称为数组的“元素类型”。

数组类型是引用类型，声明数组变量只是为引用数组实例预留空间。 实际的数组实例是在运行时使用 `new` 运算符动态创建而成。 `new` 运算指定了新数组实例的长度，然后在此实例的生存期内固定使用这个长度。 数组元素的索引介于 `0` 到 `Length - 1` 之间。 `new` 运算符自动将数组元素初始化为其默认值（例如，所有数值类型的默认值为 0，所有引用类型的默认值为 `null`）。

以下示例创建 `int` 元素数组，初始化此数组，然后打印此数组的内容。

```cs
int[] a = new int[10];
for (int i = 0; i < a.Length; i++)
{
    a[i] = i * i;
}
for (int i = 0; i < a.Length; i++)
{
    Console.WriteLine($"a[{i}] = {a[i]}");
}
```

此示例创建并在“一维数组”上进行操作。 C# 还支持多维数组。 数组类型的维数（亦称为数组类型的秩）是 1 与数组类型方括号内的逗号数量相加的结果。 以下示例分别分配一维、二维、三维数组。

```csharp
int[] a1 = new int[10];
int[,] a2 = new int[10, 5];
int[,,] a3 = new int[10, 5, 2];
```

通过 `new` 运算符，可以使用“数组初始值设定项”（在分隔符 `{` 和 `}` 内编写的表达式列表）指定数组元素的初始值。 以下示例分配 `int[]`，并将其初始化为包含三个元素。

```csharp
int[] a = new int[] { 1, 2, 3 };
```

可从 `{` 和 `}` 内的表达式数量推断出数组的长度。 数组初始化可以进一步缩短，这样就不用重新声明数组类型了。

```csharp
int[] a = { 1, 2, 3 };
```

以上两个示例等同于以下代码：

```csharp
int[] t = new int[3];
t[0] = 1;
t[1] = 2;
t[2] = 3;
int[] a = t;
```

`foreach` 语句可用于枚举任何集合的元素。 以下代码从前一个示例中枚举数组：

```csharp
foreach (int item in a)
{
    Console.WriteLine(item);
}
```

`foreach` 语句使用 [IEnumerable](https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.ienumerable-1) 接口，因此适用于任何集合。

## 字符串内插

C# [字符串内插](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/tokens/interpolated)使你能够通过定义表达式（其结果放置在格式字符串中）来设置字符串格式。 例如，以下示例从一组天气数据显示给定日期的温度：

```csharp
Console.WriteLine($"The low and high temperature on {weatherData.Date:MM-DD-YYYY}");
Console.WriteLine($"    was {weatherData.LowTemp} and {weatherData.HighTemp}.");
// Output (similar to):
// The low and high temperature on 08-11-2020
//     was 5 and 30.
```

内插字符串通过 `$` 标记来声明。 字符串插内插计算 `{` 和 `}` 之间的表达式，然后将结果转换为 `string`，并将括号内的文本替换为表达式的字符串结果。 第一个表达式 (`{weatherData.Date:MM-DD-YYYY}`) 中的 `:` 指定格式字符串。 在前一个示例中，这指定日期应以“MM-DD-YYYY”格式显示。

## 模式匹配

C# 语言提供[模式匹配](https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/functional/pattern-matching)表达式来查询对象的状态并基于该状态执行代码。 你可以检查属性和字段的类型和值，以确定要执行的操作。 还可以检查列表或数组的元素。 `switch` 表达式是模式匹配的主要表达式。

## 委托和 Lambda 表达式

[委托类型](https://learn.microsoft.com/zh-cn/dotnet/csharp/delegates-overview)表示对具有特定参数列表和返回类型的方法的引用。 通过委托，可以将方法视为可分配给变量并可作为参数传递的实体。 委托还类似于其他一些语言中存在的“函数指针”概念。 与函数指针不同，委托是面向对象且类型安全的。

下面的示例声明并使用 `Function` 委托类型。

```csharp
delegate double Function(double x);

class Multiplier
{
    double _factor;

    public Multiplier(double factor) => _factor = factor;

    public double Multiply(double x) => x * _factor;
}

class DelegateExample
{
    static double[] Apply(double[] a, Function f)
    {
        var result = new double[a.Length];
        for (int i = 0; i < a.Length; i++) result[i] = f(a[i]);
        return result;
    }

    public static void Main()
    {
        double[] a = { 0.0, 0.5, 1.0 };
        double[] squares = Apply(a, (x) => x * x);
        double[] sines = Apply(a, Math.Sin);
        Multiplier m = new(2.0);
        double[] doubles = Apply(a, m.Multiply);
    }
}
```

## async/await

C# 支持含两个关键字的异步程序：`async` 和 `await`。 将 `async` 修饰符添加到方法声明中，以声明这是异步方法。 `await` 运算符通知编译器异步等待结果完成。 控件返回给调用方，该方法返回一个管理异步工作状态的结构。 结构通常是 [System.Threading.Tasks.Task](https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.tasks.task-1)，但可以是任何支持 awaiter 模式的类型。 这些功能使你能够编写这样的代码：以其同步对应项的形式读取，但以异步方式执行。 例如，以下代码会下载 [Microsoft Docs](https://learn.microsoft.com/zh-cn/) 的主页：

```csharp
public async Task<int> RetrieveDocsHomePage()
{
    var client = new HttpClient();
    byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/");

    Console.WriteLine($"{nameof(RetrieveDocsHomePage)}: Finished downloading.");
    return content.Length;
}
```

这一小型示例显示了异步编程的主要功能：

- 方法声明包含 `async` 修饰符。
- 方法 `await` 的主体是 `GetByteArrayAsync` 方法的返回。
- `return` 语句中指定的类型与方法的 `Task<T>` 声明中的类型参数匹配。 （返回 `Task` 的方法将使用不带任何参数的 `return` 语句）。

## 特性

C# 程序中的类型、成员和其他实体支持使用修饰符来控制其行为的某些方面。 例如，方法的可访问性是由 `public`、`protected`、`internal` 和 `private` 修饰符控制。 C# 整合了这种能力，以便可以将用户定义类型的声明性信息附加到程序实体，并在运行时检索此类信息。 程序通过定义和使用[特性](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/attributes/)来指定此声明性信息。

以下示例声明了 `HelpAttribute` 特性，可将其附加到程序实体，以提供指向关联文档的链接。

```csharp
public class HelpAttribute : Attribute
{
    string _url;
    string _topic;

    public HelpAttribute(string url) => _url = url;

    public string Url => _url;

    public string Topic
    {
        get => _topic;
        set => _topic = value;
    }
}
```

所有特性类都派生自 .NET 库提供的 [Attribute](https://learn.microsoft.com/zh-cn/dotnet/api/system.attribute) 基类。 特性的应用方式为，在相关声明前的方括号内指定特性的名称以及任意自变量。 如果特性的名称以 `Attribute` 结尾，那么可以在引用特性时省略这部分名称。 例如，可按如下方法使用 `HelpAttribute`。

```csharp
[Help("https://docs.microsoft.com/dotnet/csharp/tour-of-csharp/features")]
public class Widget
{
    [Help("https://docs.microsoft.com/dotnet/csharp/tour-of-csharp/features",
    Topic = "Display")]
    public void Display(string text) { }
}
```

此示例将 `HelpAttribute` 附加到 `Widget` 类。 还向此类中的 `Display` 方法附加了另一个 `HelpAttribute`。 特性类的公共构造函数控制了将特性附加到程序实体时必须提供的信息。 可以通过引用特性类的公共读写属性（如上面示例对 `Topic` 属性的引用），提供其他信息。

可以在运行时使用反射来读取和操纵特性定义的元数据。 如果使用这种方法请求获取特定特性，便会调用特性类的构造函数（在程序源中提供信息）。 返回生成的特性实例。 如果是通过属性提供其他信息，那么在特性实例返回前，这些属性会设置为给定值。

下面的代码示例展示了如何获取与 `Widget` 类及其 `Display` 方法相关联的 `HelpAttribute` 实例。

```csharp
Type widgetType = typeof(Widget);

object[] widgetClassAttributes = widgetType.GetCustomAttributes(typeof(HelpAttribute), false);

if (widgetClassAttributes.Length > 0)
{
    HelpAttribute attr = (HelpAttribute)widgetClassAttributes[0];
    Console.WriteLine($"Widget class help URL : {attr.Url} - Related topic : {attr.Topic}");
}

System.Reflection.MethodInfo displayMethod = widgetType.GetMethod(nameof(Widget.Display));

object[] displayMethodAttributes = displayMethod.GetCustomAttributes(typeof(HelpAttribute), false);

if (displayMethodAttributes.Length > 0)
{
    HelpAttribute attr = (HelpAttribute)displayMethodAttributes[0];
    Console.WriteLine($"Display method help URL : {attr.Url} - Related topic : {attr.Topic}");
}
```