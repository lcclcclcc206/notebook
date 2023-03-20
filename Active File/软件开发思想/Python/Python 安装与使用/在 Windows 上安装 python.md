与大多数UNIX系统和服务不同，Windows系统没有预安装Python。多年来CPython 团队已经编译了每一个 [发行版](https://www.python.org/download/releases/) 的Windows安装程序（MSI 包），已便Windows 用户下载和安装。这些安装程序主要用于每个用户单独安装Python时，添加核心解释器和库。安装程序还可以为一台机器的所有用户安装，并且可以为应用程序本地分发提供单独的zip文件。

Windows提供了许多不同的安装程序，每个安装程序都有一定的优点和缺点。

[完整安装程序](https://docs.python.org/zh-cn/3/using/windows.html#windows-full) 内含所有组件，对于使用Python 进行任何类型项目的开发人员而言，它是最佳选择。

[Microsoft Store包](https://docs.python.org/zh-cn/3/using/windows.html#windows-store) is a simple installation of Python that is suitable for running scripts and packages, and using IDLE or other development environments. It requires Windows 10 and above, but can be safely installed without corrupting other programs. It also provides many convenient commands for launching Python and its tools.

[nuget.org 安装包](https://docs.python.org/zh-cn/3/using/windows.html#windows-nuget) 是用于持续集成系统的轻量级安装。它可用于构建Python包或运行脚本，但不可更新且没有用户界面工具。

[可嵌入的包](https://docs.python.org/zh-cn/3/using/windows.html#windows-embeddable) 是Python的最小安装包，适合嵌入到更大的应用程序中。

## 完整安装程序[¶](https://docs.python.org/zh-cn/3/using/windows.html#the-full-installer)

### 安装步骤[¶](https://docs.python.org/zh-cn/3/using/windows.html#installation-steps)

略

### 删除 MAX_PATH 限制

历史上Windows的路径长度限制为260个字符。这意味着长于此的路径将无法解决并导致错误。

在最新版本的 Windows 中，此限制可被扩展到大约 32,000 个字符。 但需要让管理员激活“启用 Win32 长路径”组策略，或在注册表键 `HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\FileSystem` 中设置 `LongPathsEnabled` 为 `1`。

这允许 [`open()`](https://docs.python.org/zh-cn/3/library/functions.html#open) 函数，[`os`](https://docs.python.org/zh-cn/3/library/os.html#module-os) 模块和大多数其他路径功能接受并返回长度超过 260 个字符的路径。

更改上述选项后，无需进一步配置。

*在 3.6 版更改:* Python中启用了对长路径的支持。

### 免下载安装

由于下载的初始安装包中未包含Python的某些可选功能，如果选择安装这些功能可能需要Internet连接。为了避免这种需要，可以按需下载所有可能的组件，以创建一个完整的布局，该布局将不再需要internet连接，而不管所选择的特性是什么。请注意，此下载可能比要求的要大，但是如果要执行大量安装，则拥有本地缓存的副本非常有用。

从命令提示符执行以下命令以下载所有可能的必需文件。 请记得要将 `python-3.9.0.exe` 替换为安装程序的实际名称，并在单独的目录中创建子目录以避免同名文件间的冲突。

```
python-3.9.0.exe /layout [optional target directory]
```

您也可以指定 `/quiet` 选项来隐藏进度显示。

## 配置Python

要从命令提示符方便地运行Python，您可以考虑在Windows中更改一些默认环境变量。虽然安装程序提供了为您配置PATH和PATHEXT变量的选项，但这仅适用于单版本、全局安装。如果您经常使用多个版本的Python，请考虑使用 [适用于Windows的Python启动器](https://docs.python.org/zh-cn/3/using/windows.html#launcher) 。

### 附录：设置环境变量

Windows允许在用户级别和系统级别永久配置环境变量，或临时在命令提示符中配置环境变量。

要临时设置环境变量，请打开命令提示符并使用 **set** 命令：

```
C:\>set PATH=C:\Program Files\Python 3.9;%PATH%
C:\>set PYTHONPATH=%PYTHONPATH%;C:\My_python_lib
C:\>python
```

这些环境变量的更改将应用于在该控制台中执行的任何其他命令，并且，由该控制台启动的任何应用程序都继承设这些设置。

在百分号中包含的变量名将被现有值替换，允许在开始或结束时添加新值。通过将包含 **python.exe** 的目录添加到开头来修改 `PATH` 是确保启动正确版本的Python的常用方法。

要永久修改默认环境变量，请单击“开始”并搜索“编辑环境变量”，或打开系统属性的 高级系统设置 ，然后单击 环境变量 按钮。在此对话框中，您可以添加或修改用户和系统变量。要更改系统变量，您需要对计算机进行无限制访问（即管理员权限）。

> 备注
>
> Windows会将用户变量串联在系统变量 *之后* ，这可能会在修改 `PATH` 时导致意外结果。
>
> [`PYTHONPATH`](https://docs.python.org/zh-cn/3/using/cmdline.html#envvar-PYTHONPATH) 变量被 Python 的所有版本使用，因此除非它列出的路径只包含与所有已安装的 Python 版本兼容的代码，否则不要永久配置此变量。

> 参见
>
> - https://docs.microsoft.com/en-us/windows/win32/procthread/environment-variables
>
>   Windows 中的环境变量概述
>
> - https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/set_1
>
>   用于临时修改环境变量的 `set` 命令
>
> - https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/setx
>
>   用于永久修改环境变量的 `setx` 命令

### 查找Python可执行文件

*在 3.5 版更改.*

除了使用自动创建的Python解释器的开始菜单项之外，您可能还想在命令提示符下启动Python。安装程序有一个选项可以为您设置。

在安装程序的第一页上，可以选择标记为“将Python添加到环境变量”的选项，以使安装程序将安装位置添加到 `PATH` 。还添加了 `Scripts\` 文件夹的位置。这允许你输入 **python** 来运行解释器，并且 **pip** 用于包安装程序。因此，您还可以使用命令行选项执行脚本，请参阅 [命令行](https://docs.python.org/zh-cn/3/using/cmdline.html#using-on-cmdline) 文档。

如果在安装时未启用此选项，则始终可以重新运行安装程序，选择“修改”并启用它。或者，您可以使用 [附录：设置环境变量](https://docs.python.org/zh-cn/3/using/windows.html#setting-envvars) 的方法手动修改 `PATH` 。您需要将Python安装目录添加到 `PATH` 环境变量中，该内容与其他条目用分号分隔。示例变量可能如下所示（假设前两个条目已经存在）:

```
C:\WINDOWS\system32;C:\WINDOWS;C:\Program Files\Python 3.9
```

## 适用于Windows的Python启动器

*3.3 新版功能.*

用于Windows的Python启动器是一个实用程序，可帮助定位和执行不同的Python版本。它允许脚本（或命令行）指示特定Python版本的首选项，并将定位并执行该版本。

与 `PATH` 变量不同，启动器将正确选择最合适的Python版本。它更倾向于按用户安装而不是系统安装，并按语言版本排序，而不是使用最新安装的版本。

启动器最初是在 [**PEP 397**](https://peps.python.org/pep-0397/) 中指定的。

### 入门

#### 从命令行

*在 3.6 版更改.*

全局安装Python 3.3及更高版本将把启动器放在你的 `PATH` 上。启动程序与所有可用的Python版本兼容，因此安装哪个版本无关紧要。要检查启动程序是否可用，请在命令提示符中执行以下命令：

```
py
```

您应该会发现已安装的最新版本的Python已启动 - 它可以正常退出，并且将指定的任何其他命令行参数直接发送到Python。

如果您安装了多个版本的Python（例如，3.7和 3.11 ），您会注意到Python 3.11 启动 - 如果要启动 Python 3.7，尝试命令：

```
py -3.7
```

如果您想使用已安装的 Python 2 的最新版本，请尝试以下命令：

```
py -2
```

如果您看到以下错误，则表明您没有安装启动器：

```
'py' is not recognized as an internal or external command,
operable program or batch file.
```

Tix 命令：

```
py --list
```

显示当前已安装的Python版本。

The `-x.y` argument is the short form of the `-V:Company/Tag` argument, which allows selecting a specific Python runtime, including those that may have come from somewhere other than python.org. Any runtime registered by following [**PEP 514**](https://peps.python.org/pep-0514/) will be discoverable. The `--list` command lists all available runtimes using the `-V:` format.

When using the `-V:` argument, specifying the Company will limit selection to runtimes from that provider, while specifying only the Tag will select from all providers. Note that omitting the slash implies a tag:

```
# Select any '3.*' tagged runtime
py -V:3

# Select any 'PythonCore' released runtime
py -V:PythonCore/

# Select PythonCore's latest Python 3 runtime
py -V:PythonCore/3
```

The short form of the argument (`-3`) only ever selects from core Python releases, and not other distributions. However, the longer form (`-V:3`) will select from any.

The Company is matched on the full string, case-insenitive. The Tag is matched oneither the full string, or a prefix, provided the next character is a dot or a hyphen. This allows `-V:3.1` to match `3.1-32`, but not `3.10`. Tags are sorted using numerical ordering (`3.10` is newer than `3.1`), but are compared using text (`-V:3.01` does not match `3.1`).

#### 从虚拟环境

*3.5 新版功能.*

如果启动程序运行时没有明确的Python版本，并且虚拟环境（使用标准库创建 [`venv`](https://docs.python.org/zh-cn/3/library/venv.html#module-venv) 模块或外部 `virtualenv` 工具）处于活动状态，则启动程序将运行虚拟环境的解释器而不是全局的。要运行全局解释器，请停用虚拟环境，或显式指定全局Python版本。

#### 从脚本

让我们创建一个测试Python脚本 - 创建一个名为``hello.py``的文件，其中包含以下内容

```py
#! python
import sys
sys.stdout.write("hello from Python %s\n" % (sys.version,))
```

从hello.py所在的目录中，执行以下命令：

```
py hello.py
```

您应该注意到最新的Python 2.x安装的版本号已打印出来。现在尝试将第一行更改为：

```
#! python3
```

Re-executing the command should now print the latest Python 3.x information. As with the above command-line examples, you can specify a more explicit version qualifier. Assuming you have Python 3.7 installed, try changing the first line to `#! python3.7` and you should find the 3.7 version information printed.

请注意，与交互式使用不同，裸“python”将使用您已安装的Python 2.x的最新版本。这是为了向后兼容及兼容Unix，其中命令 `python` 通常是指Python 2。

### Shebang Lines

如果脚本文件的第一行以 `#!` 开头，则称为 "shebang" 行。Linux和其他类Unix操作系统都有对这些行的本机支持，它们通常在此类系统上用来指示应该如何执行脚本。这个启动器允许在Windows上对Python脚本使用相同的工具，上面的示例演示了它们的使用。

为了允许Python脚本中的shebang行在Unix和Windows之间移植，该启动器支持许多“虚拟”命令来指定要使用的解释器。支持的虚拟命令是：

- `/usr/bin/env`
- `/usr/bin/python`
- `/usr/local/bin/python`
- `python`

例如，如果脚本开始的第一行

```
#! /usr/bin/python
```

将找到并使用默认的Python。因为在Unix上编写的许多Python脚本已经有了这一行，你应该发现这些脚本可以由启动器使用而无需修改。如果您在Windows上编写一个新脚本，希望在Unix上有用，那么您应该使用以 `/usr` 开头的一个shebang行。

任何上述虚拟命令都可以显式指定版本（可以仅为主要版本，也可以为主要版本加次要版本）作为后缀。 此外，可以通过在次要版本之后添加 “-32” 来请求 32 位版本。 例如 `/usr/bin/python3.7-32` 将请求使用 32 位 python 3.7。

*3.7 新版功能:* 从python启动程序3.7开始，可以通过“-64”后缀调用64位版本。此外，可以指定没有次要的主要和架构（即 `/usr/bin/python3-64` ）。

*在 3.11 版更改:* The "-64" suffix is deprecated, and now implies "any architecture that is not provably i386/32-bit". To request a specific environment, use the new `-V:<TAG>` argument with the complete tag.

###  shebang lines 的参数

shebang lines 还可以指定要传递给Python解释器的其他选项。例如，如果你有一个shebang lines ：

```
#! /usr/bin/python -v
```

然后Python将以 `-v` 选项启动