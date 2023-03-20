[System.IO](https://learn.microsoft.com/zh-cn/dotnet/api/system.io) 命名空间中很多类型的成员都包括 `path` 参数，让你可以指定指向某个文件系统资源的绝对路径或相对路径。 此路径随后会传递至 [Windows 文件系统 API](https://learn.microsoft.com/zh-cn/windows/desktop/fileio/file-systems)。 本主题讨论可在 Windows 系统上使用的文件路径格式。

## 传统 DOS 路径

标准的 DOS 路径可由以下三部分组成：

- 卷号或驱动器号，后跟卷分隔符 (`:`)。
- 目录名称。 [目录分隔符](https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path.directoryseparatorchar)用来分隔嵌套目录层次结构中的子目录。
- 可选的文件名。 [目录分隔符](https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path.directoryseparatorchar)用来分隔文件路径和文件名。

如果以上三项都存在，则为绝对路径。 如未指定卷号或驱动器号，且目录名称的开头是[目录分隔符](https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path.directoryseparatorchar)，则路径属于当前驱动器根路径上的相对路径。 否则路径相对于当前目录。 下表显示了一些可能出现的目录和文件路径。

| 路径                                               | 描述                                         |
| :------------------------------------------------- | :------------------------------------------- |
| `C:\Documents\Newsletters\Summer2018.pdf`          | `C:` 驱动器的根目录中的绝对文件路径。        |
| `\Program Files\Custom Utilities\StringFinder.exe` | 当前驱动器根路径上的绝对路径。               |
| `2018\January.xlsx`                                | 指向当前目录的子目录中的文件的相对路径。     |
| `..\Publications\TravelBrochure.pdf`               | 指向从当前目录开始的目录中的文件的相对路径。 |
| `C:\Projects\apilibrary\apilibrary.sln`            | `C:` 驱动器的根目录中的文件的绝对路径。      |
| `C:Projects\apilibrary\apilibrary.sln`             | `C:` 驱动器的当前目录中的相对路径。          |

可以通过调用 [Path.IsPathFullyQualified](https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path.ispathfullyqualified) 方法来确定文件路径是否完全限定（即是说，该路径是否独立于当前目录，且在当前目录更改时不发生变化）。 请注意，如果解析的路径始终指向同样的位置，那么此类路径可以包括相对目录段（`.` 和 `..`），而同时依然是完全限定的。

## UNC 路径

通用命名约定 (UNC) 路径，用于访问网络资源，具有以下格式：

- 一个以 `\\` 开头的服务器名或主机名。 服务器名称可以为 NetBIOS 计算机名称或者 IP/FQDN 地址（支持 IPv4 和 IPv6）。
- 共享名，使用 `\` 将其与主机名分隔开。 服务器名和共享名共同组成了卷。
- 目录名称。 [目录分隔符](https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path.directoryseparatorchar)用来分隔嵌套目录层次结构中的子目录。
- 可选的文件名。 [目录分隔符](https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path.directoryseparatorchar)用来分隔文件路径和文件名。

以下是一些 UNC 路径的示例：

| 路径                           | 描述                                                |
| :----------------------------- | :-------------------------------------------------- |
| `\\system07\C$\`               | `system07` 上 `C:` 驱动器的根目录。                 |
| `\\Server2\Share\Test\Foo.txt` | `\\Server2\Share` 卷的测试目录中的 `Foo.txt` 文件。 |

UNC 路径必须始终是完全限定的。 它们可以包括相对目录段（`.` 和 `..`），但是这些目录段必须是完全限定的路径的一部分。 只能通过将 UNC 路径映射至驱动器号来使用相对路径。

## DOS 设备路径

Windows 操作系统有一个指向所有资源（包括文件）的统一对象模型。 可从控制台窗口访问这些对象路径；并通过旧版 DOS 和 UNC 路径映射到的符号链接的特殊文件，将这些对象路径公开至 Win32 层。 此特殊文件夹可通过 DOS 设备路径语法（以下任一）进行访问：

```
\\.\C:\Test\Foo.txt` `\\?\C:\Test\Foo.txt
```

除了通过驱动器号识别驱动器以外，还可以使用卷 GUID 来识别卷。 它采用以下形式：

```
\\.\Volume{b75e2c83-0000-0000-0000-602f00000000}\Test\Foo.txt` `\\?\Volume{b75e2c83-0000-0000-0000-602f00000000}\Test\Foo.txt
```

https://learn.microsoft.com/zh-cn/dotnet/standard/io/file-path-formats#dos-device-paths

## 路径规范化

几乎所有传递至 Windows API 的路径都经过规范化。 规范化过程中，Windows 执行了以下步骤：

- 识别路径。
- 将当前目录应用于部分限定（相对）路径。
- 规范化组件和目录分隔符。
- 评估相对目录组件（当前目录是 `.`，父目录是 `..`）。
- 剪裁特定字符。

这种规范化隐式进行，若想显式进行规范化，可以调用 [Path.GetFullPath](https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path.getfullpath) 方法，这会包装对 [GetFullPathName() 函数](https://learn.microsoft.com/zh-cn/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea)的调用。 还可以使用 P/Invoke 直接调用 Windows [GetFullPathName() 函数](https://learn.microsoft.com/zh-cn/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea)。

### 标识路径

路径规范化的第一步就是识别路径类型。 路径归为以下几个类别之一：

- 它们是设备路径；就是说，它们的开头是两个分隔符和一个问号或句点（`\\?` 或 `\\.`）。
- 它们是 UNC 路径；就是说，它们的开头是两个分隔符，没有问号或句点。
- 它们是完全限定的 DOS 路径；就是说，它们的开头是驱动器号、卷分隔符和组件分隔符 (`C:\`)。
- 它们指定旧设备（`CON`、`LPT1`）。
- 它们相对于当前驱动器的根路径；就是说，它们的开头是单个组件分隔符 (`\`)。
- 它们相对于指定驱动器的当前目录；就是说，它们的开头是驱动器号和卷分隔符，而没有组件分隔符 (`C:`)。
- 它们相对于当前目录；就是说，它们的开头是上述情况以外的任何内容 (`temp\testfile.txt`)。

路径的类型决定是否以某种方式应用当前目录。 还决定该路径的“根”是什么。

### 应用当前目录

如果路径非完全限定，Windows 会向其应用当前目录。 不会向 UNC 和设备路径应用当前目录。 带有分隔符的 `C:\` 完整驱动器也不会应用当前目录。

如果路径的开头是单个组件分隔符，则会应用当前目录中的驱动器。 例如，如果文件路径是 `\utilities` 且当前目录为 `C:\temp\`，规范化后路径则为 `C:\utilities`。

如果路径开头是驱动器号和卷分隔符，而没有组件分隔符，则应用从命令行界面为指定驱动器设置的最新当前目录。 如未设置最新当前目录，则只应用驱动器。 例如，如果文件路径为 `D:sources`，当前目录为 `C:\Documents\`，且 D: 盘上的最新当前目录为 `D:\sources\`，则结果为 `D:\sources\sources`。 这些“驱动器相对”路径是导致程序和脚本逻辑错误的常见原因。 假设以字母和冒号开头的路径不是相对路径，显然是不正确的。

如果路径不是以分隔符开头的，则应用当前驱动器和当前目录。 例如，如果路径是 `filecompare` 且当前目录是 `C:\utilities\`，则结果为 `C:\utilities\filecompare\`。

> 相对路径在多线程应用程序（也就是大多数应用程序）中很危险，因为当前目录是分进程的设置。 任何线程都能在任何时候更改当前目录。 从 .NET Core 2.1 开始，可以调用 [Path.GetFullPath(String, String)](https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path.getfullpath#system-io-path-getfullpath(system-string-system-string)) 方法，从想要据此解析绝对路径的相对路径和基础路径（当前目录）获取绝对路径。

### 规范化分隔符

将所有正斜杠 (`/`) 转换为标准的 Windows 分隔符，也就是反斜杠 (`\`)。 如果存在斜杠，前两个斜杠后面的一系列斜杠都将折叠为一个斜杠。

### 剪裁字符

随着分隔符的运行和相对段先遭删除，一些其他字符在规范化过程中也删除了：

- 如果某段以单个句点结尾，则删除此句点。 （单个或两个句点的段在之前的步骤中已规范化。三个或更多句点的段未规范化，并且实际上是有效的文件/目录名称。）

- 如果路径的结尾不是分隔符，则删除所有尾随句点和空格 (U+0020)。 如果最后的段只是单个或两个句点，则按上述相对组件规则处理。

  此规则意味着可以创建以空格结尾的目录名称，方法是在空格后添加结尾分隔符。

## 跳过规范化过程

一般来说，任何传递到 Windows API 的路径都会（有效地）传递到 [GetFullPathName 函数](https://learn.microsoft.com/zh-cn/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea)并进行规范化。 但是有一种很重要的例外情况：以问号（而不是句点）开头的设备路径。 除非路径确切地以 `\\?\` 开头（注意使用的是规范的反斜杠），否则会对它进行规范化。

为什么要跳过规范化过程？ 主要有三方面的原因：

1. 为了访问那些通常无法访问但合法的路径。 例如名为 `hidden.` 的文件或目录，这是能访问它的唯一方式。
2. 为了在已规范化的情况下通过跳过规范化过程来提升性能。
3. 为了跳过路径长度的 `MAX_PATH` 检查以允许多于 259 个字符的路径（仅在 .NET Framework 上）。 大多数 API 都允许这一点，也有一些例外情况。

跳过规范化和路径上限检查是两种设备路径语法之间唯一的区别；除此以外它们是完全相同的。 请谨慎地选择跳过规范化，因为很容易就会创建出“一般”应用程序难以处理的路径。

如果将开头为 `\\?\` 的路径显式地传递至 [GetFullPathName 函数](https://learn.microsoft.com/zh-cn/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea)，则依然会对它们进行规范化。

可将超过 `MAX_PATH` 字符数的路径传递至 [GetFullPathName](https://learn.microsoft.com/zh-cn/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea)，前提是该路径不含 `\\?\`。 支持任意长度的路径，只要其字符串大小在 Windows 能处理的范围内。