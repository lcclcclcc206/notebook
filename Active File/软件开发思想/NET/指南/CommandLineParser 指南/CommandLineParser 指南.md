https://github.com/commandlineparser/commandline/wiki/Home

## 入门案例

在 CommandLineParser 中，你需要理解一些关键词才能编写正确好用的命令行程序：

- **Options** 类：选项，在 Options 类中包含了命令所包含的所有值和选项
- **Value**：值，就像函数的参数一样，会被程序所捕获和使用，值是通过索引进行分区的
- **Option**：选项，与 Value 不同，是通过名字进行分区的
- **Verbs**：动词，可以在单个程序中帮助描述和分离单个应用程序中的选项和值，一个众所周知的例子就是 git 中的命令： `git add`、`git push`、`git pull` 中的第二次命令就是动词

以下是一个入门案例：

Options.cs

```cs
using CommandLine;

namespace GetStartSample;
internal class Options
{
    [Value(0)]
    public int IntValue { get; set; }

    [Value(1, Min = 1, Max = 3)]
    public IEnumerable<string> StringSeq { get; set; }

    [Value(2)]
    public double DoubleValue { get; set; }
}
```

Program.cs

```cs
using CommandLine;
using GetStartSample;

var result = Parser.Default.ParseArguments<Options>(args);
result.WithParsed(options =>
{
    Console.WriteLine(options.IntValue);
    options.StringSeq.ToList().ForEach(s => Console.WriteLine(s));
    Console.WriteLine(options.DoubleValue);
});
```

调用程序以及得到的结果如下：

```
dotnet run -- 10 str1 str2 str3 1.1

10
str1
str2
str3
1.1
```

在 Options 类中，我声明了成员来映射我要捕获的参数，在 Program.cs 中，我通过 `Parser.Default.ParseArguments<Options>(args)` 来将命令行参数转化为 Options 类，随后调用 ParserResult 的 `WithParsed` 来使用 Options 类中的值，将其输出到控制台界面。

## 解析值（Value）

以上个案例为例，在 Options 类中使用了 Value 特性来标注成员：

Options.cs

```cs
using CommandLine;

namespace GetStartSample;
internal class Options
{
    [Value(0)]
    public int IntValue { get; set; }

    [Value(1, Min = 1, Max = 3)]
    public IEnumerable<string> StringSeq { get; set; }

    [Value(2)]
    public double DoubleValue { get; set; }
}
```

其中，第二个成员是 string 类型的集合，表明它包含有1到3个数量的值。

## 解析选项（Options）

以下是选项的例子，如果你省略了选项的名称，那么 CommandLineParser 会根据成员名称推断出长名称

```cs
class Options {
  [Option]
  public string UserId { get; set; }
}
```

这允许你可以这样使用程序

```
$ app --userid=root
```

## 关于解析

以下是一个基本的使用场景（没有动词），使用默认的与构建实例来解析使用 Options 类中指定规则输入的参数：

```
var result = Parser.Default.ParseArguments<Options>(args);
```

返回的对象 result 的类型为 `ParserResult<T>` ，其中 T 的类型就是我们定义的 Options 类。

如果解析成功，我们将得到一个从 `ParserResult<T>` 派生的 `Parsed<T>` 实例， 通过 Value 属性公开了 T 类型的实例。

如果解析失败，我们将得到一个从 `ParserResult<T>` 派生的 `NotParsed<T>` 实例， 错误在 Errors 序列中。

我们可以通过 Tag 属性来检查收到的派生类型，它是一个枚举值，分为 Parsed 和 NotParsed.

有两种便捷的拓展方法可以帮助我们访问 Options 类中的值：

**方法一**

``` cs
var result = Parser.Default.ParseArguments<Options>(args)
  .WithParsed(options => ...) // options is an instance of Options type
  .WithNotParsed(errors => ...) // errors is a sequence of type IEnumerable<Error>
```

**方法二**

```cs
// you can directly turn the result into an exit code for example
static int Main(string[] args)
{
  return Parser.Default.ParseArguments<Options>(args)
  .MapResult(
    options => RunAndReturnExitCode(options),
    _ => 1);
}

static int RunAndReturnExitCode(Options options)
{
   options.Dump();
   return 0;
}
```

## 解析动词（Verbs）

[Verbs · commandlineparser/commandline Wiki (github.com)](https://github.com/commandlineparser/commandline/wiki/Verbs)

Verbs 特性可以在单个程序中帮助描述和分离单个应用程序中的选项和值。

要使用动词特性，可以使用 `[Verb]` 特性修饰 Options 类：

```cs
[Verb("add", HelpText = "Add file contents to the index.")]
class AddOptions { //normal options here
}
[Verb("commit", HelpText = "Record changes to the repository.")]
class CommitOptions { //normal options here
}
[Verb("clone", HelpText = "Clone a repository into a new directory.")]
class CloneOptions { //normal options here
}
```

同时，我们在解析参数时也要使用接受多个类型的，正确的 ParserArguments 重载方法：

```cs
static int Main(string[] args) {
    var result = Parser.Default.ParseArguments<AddOptions, CommitOptions, CloneOptions>(args);
}
```

在这种情况下，返回值 result 属于 `ParserResult<T>` 类型，它的属性 `Value` 在解析成功的情况下将是正确的实例，如果解析失败则是 null 为空。

当解析成功时，对于使用不同动词的命令行参数来调用程序，返回的 Options 实例也会不同。CommandLineParser 提供一个辅助拓展方法来简化这个判断的任务：

```cs
static int Main(string[] args) {
    Parser.Default.ParseArguments<AddOptions, CommitOptions, CloneOptions>(args)
    .WithParsed<AddOptions>(options => ...)
    .WithParsed<CommitOptions>(options => ...)
    .WithParsed<CloneOptions>(options => ...)
    .WithNotParsed(errors => ...)
}
```

使用 MapResult 方法可以连续性的解析动词，并且它在解析完动词后返回一个退出代码：

```cs
static int Main(string[] args) =>
  Parser.Default.ParseArguments<AddOptions, CommitOptions, CloneOptions>(args)
    .MapResult(
      (AddOptions options) => RunAddAndReturnExitCode(opts),
      (CommitOptions options) => RunCommitAndReturnExitCode(opts),
      (CloneOptions options) => RunCloneAndReturnExitCode(opts),
      errors => 1);
```

## 帮助文本配置

[HelpText Configuration · commandlineparser/commandline Wiki (github.com)](https://github.com/commandlineparser/commandline/wiki/HelpText-Configuration)

CommandLineParser 提供的帮助文本布局如下图所示：

![alt text](https://github.com/commandlineparser/commandline/wiki/media/layout.png)

它由以下几部分组成：

- Heading

  : is formated as:

  ```
  <title> <version>
  ```

  > Example: ConsoleApp2 1.0.0

- Copyright

  : is formatted as

  ```
  Copyright (C) `<year> <Company>`
  ```

  or in case of Copyright attribute available:

  ```
  <copyrightAssemblyAttribute>
  ```

  > Example: Copyright (C) 2019 ConsoleApp2

- **Examples**: Syntax of command use.

- **Options_section**: series of `<Shortname, longName>` with its help.

- **Pre_options**: is optional block before options.

- **Post_options**: is optional block after options.

通过以下几个案例来了解帮助文本的使用

**示例1**

为了使用自定义的帮助文档，请通过配置 `Parser.HelpWriter = null`。使用 `AutoBuild` 方法来自动构建帮助。

在下面的这个示例中，配置了 `AdditionNewLineAfterOption` 属性，每条选项后面不会有换行符：

```cs
static void Main(string[] args)
{
  var parser = new CommandLine.Parser(with => with.HelpWriter = null);
  var parserResult = parser.ParseArguments<Options>(args);
  parserResult
    .WithParsed<Options>(options => Run(options))
    .WithNotParsed(errs => DisplayHelp(parserResult, errs));
}

static void DisplayHelp<T>(ParserResult<T> result)
{  
  var helpText = HelpText.AutoBuild(result, h =>
  {
    h.AdditionalNewLineAfterOption = false;
    h.Heading = "Myapp 2.0.0-beta"; //change header
    h.Copyright = "Copyright (c) 2019 Global.com"; //change copyright text
    return HelpText.DefaultParsingErrorsHandler(result, h);
  }, e => e);
  Console.WriteLine(helpText);
}
private static void Run(Options options)
{
  //do stuff
}
```

生成的帮助文本在选项和设置标题和版权文本之间没有换行符，如下所示：

```
Myapp 2.0.0-beta
Copyright (c) 2019 Global.com

  -r, --read         Input files to be processed.
  --verbose          (Default: false) Prints all messages to standard output.
  --stdin            (Default: false) Read from stdin  
  --help             Display this help screen.
  --version          Display version information.
  offset (pos. 0)    File offset.
```

在解析错误的情况下，帮助文本包括一个错误部分：

```
Myapp 2.0.0-beta
Copyright (c) 2019 Global.com

ERROR(S):
  Option 'zz' is unknown.

  -r, --read         Input files to be processed.
  --verbose          (Default: false) Prints all messages to standard output.
  --stdin            (Default: false) Read from stdin
  --help             Display this help screen.
  --version          Display version information.
  offset (pos. 0)    File offset.
```

**示例2**

使用扩展方法根据错误类型控制显示帮助、版本和错误：

```cs
static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
{
  HelpText helpText = null;
  if (errs.IsVersion())  //check if error is version request
    helpText = HelpText.AutoBuild(result);
  else
  {
    helpText = HelpText.AutoBuild(result, h =>
    {
      //configure help
      h.AdditionalNewLineAfterOption = false;
      h.Heading = "Myapp 2.0.0-beta"; //change header
      h.Copyright = "Copyright (c) 2019 Global.com"; //change copyright text
      return HelpText.DefaultParsingErrorsHandler(result, h);
    }, e => e);
  }
  Console.WriteLine(helpText);
}
```

**示例3**

添加运行时计算的动态内容。

```cs
//get environment variable
static Func<string> dynamicData = () => {
  var header = "-------Environment Variables----------";
  var windir = Environment.GetEnvironmentVariable("windir");
  return $"{header}\nwindir={windir}";
};

static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
{
  var helpText = HelpText.AutoBuild(result, h =>
  {
    h.AddPostOptionsLine(dynamicData());
    return h;
  }, e => e);
  Console.WriteLine(helpText);
}
```

输出如下

```
Myapp 2.0.0-beta
Copyright (c) 2019 Global.com

  -r, --read         Input files to be processed.
  --verbose          (Default: false) Prints all messages to standard output.
  --stdin            (Default: false) Read from stdin
  --help             Display this help screen.
  --version          Display version information.
  offset (pos. 0)    File offset.

-------Environment Variables----------
windir=C:\Windows
```

完整的代码案例请参考链接：[HelpText Configuration · commandlineparser/commandline Wiki (github.com)](https://github.com/commandlineparser/commandline/wiki/HelpText-Configuration#complete-help-demo-example)

### 程序集信息

帮助文本会检索程序集属性值以在帮助文本中显示标题和版权。

应设置程序集属性：

```xml
<PropertyGroup>
...
  <Copyright>Copyright_text</Copyright>
  <Company>Company_text</Company>
  <Version>1.2.3-beta</Version>
  <AssemblyTitle>title_text</AssemblyTitle>

</PropertyGroup>
```

用于 msbuild 的新 SDK 在构建期间自动生成一个程序集信息文件，包括上述程序集属性。