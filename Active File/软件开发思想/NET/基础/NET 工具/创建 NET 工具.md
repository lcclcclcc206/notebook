[教程：创建 .NET 工具 - .NET CLI | Microsoft Learn](https://learn.microsoft.com/zh-cn/dotnet/core/tools/global-tools-how-to-create)

本教程介绍如何创建和打包 .NET 工具。 使用 .NET CLI，你可以创建一个控制台应用程序作为工具，便于其他人安装并运行。 .NET 工具是从 .NET CLI 安装的 NuGet 包。 有关工具的详细信息，请参阅 [.NET 工具概述](https://learn.microsoft.com/zh-cn/dotnet/core/tools/global-tools)。

## 创建项目

1. 打开命令提示符，创建一个名为“repository” 的文件夹。

2. 导航到“repository”文件夹并输入以下命令 ：

   ```dotnetcli
   dotnet new console -n microsoft.botsay -f net6.0
   ```

   此命令将在“repository”文件夹下创建一个名为“microsoft.botsay”的新文件夹 。

3. 导航到“microsoft.botsay”文件夹 。

   ```console
   cd microsoft.botsay
   ```

## 添加代码

使用代码编辑器打开 Program.cs 文件。

```cs
using System.Reflection;

namespace TeleprompterConsole;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            var versionString = Assembly.GetEntryAssembly()?
                                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                                    .InformationalVersion
                                    .ToString();

            Console.WriteLine($"botsay v{versionString}");
            Console.WriteLine("-------------");
            Console.WriteLine("\nUsage:");
            Console.WriteLine("  botsay <message>");
            return;
        }

        ShowBot(string.Join(' ', args));
    }

    static void ShowBot(string message)
    {
        string bot = $"\n        {message}";
        bot += @"
    __________________
                      \
                       \
                          ....
                          ....'
                           ....
                        ..........
                    .............'..'..
                 ................'..'.....
               .......'..........'..'..'....
              ........'..........'..'..'.....
             .'....'..'..........'..'.......'.
             .'..................'...   ......
             .  ......'.........         .....
             .    _            __        ......
            ..    #            ##        ......
           ....       .                 .......
           ......  .......          ............
            ................  ......................
            ........................'................
           ......................'..'......    .......
        .........................'..'.....       .......
     ........    ..'.............'..'....      ..........
   ..'..'...      ...............'.......      ..........
  ...'......     ...... ..........  ......         .......
 ...........   .......              ........        ......
.......        '...'.'.              '.'.'.'         ....
.......       .....'..               ..'.....
   ..       ..........               ..'........
          ............               ..............
         .............               '..............
        ...........'..              .'.'............
       ...............              .'.'.............
      .............'..               ..'..'...........
      ...............                 .'..............
       .........                        ..............
        .....
";
        Console.WriteLine(bot);
    }
}
```

## 测试应用程序

运行项目并观察输出。 尝试使用命令行处的这些变体来查看不同的结果：

```dotnetcli
dotnet run
dotnet run -- "Hello from the bot"
dotnet run -- Hello from the bot
```

位于 `--` 分隔符后的所有参数均会传递给应用程序。

## 打包工具

在将应用程序作为工具打包并分发之前，你需要修改项目文件。

1. 打开“microsoft.botsay.csproj”文件，然后将三个新的 XML 节点添加到 `<PropertyGroup>` 节点的末尾 ：

   ```xml
   <PackAsTool>true</PackAsTool>
   <ToolCommandName>botsay</ToolCommandName>
   <PackageOutputPath>./nupkg</PackageOutputPath>
   ```

   `<ToolCommandName>` 是一个可选元素，用于指定在安装工具后将调用该工具的命令。 如果未提供此元素，则该工具的命令名称为没有“.csproj” 扩展名的项目文件名。

   `<PackageOutputPath>` 是一个可选元素，用于确定将在何处生成 NuGet 包。 NuGet 包是 .NET CLI 用于安装你的工具的包。

   项目文件现在类似于以下示例：

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">
   
     <PropertyGroup>
   
       <OutputType>Exe</OutputType>
       <TargetFramework>net6.0</TargetFramework>
   
       <PackAsTool>true</PackAsTool>
       <ToolCommandName>botsay</ToolCommandName>
       <PackageOutputPath>./nupkg</PackageOutputPath>
   
     </PropertyGroup>
   
   </Project>
   ```

2. 通过运行 [dotnet pack](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-pack) 命令创建 NuGet 包：

   ```dotnetcli
   dotnet pack
   ```

   “microsoft.botsay.1.0.0.nupkg”文件在由 microsoft.botsay.csproj 文件的 `<PackageOutputPath>` 值标识的文件夹中创建，在本示例中为“./nupkg”文件夹 。

   如果想要公开发布一个工具，你可以将其上传到 `https://www.nuget.org`。 该工具在 NuGet 上可用后，开发人员就可以使用 [dotnet tool install](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-tool-install) 命令安装该工具。 在本教程中，你将直接从本地“nupkg” 文件夹安装包，因此无需将包上传到 NuGet。