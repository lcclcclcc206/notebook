[使用内置调试程序和 Visual Studio Code 调试程序以交互方式调试 Node.js JavaScript 应用 - Training | Microsoft Learn](https://learn.microsoft.com/zh-cn/training/modules/debug-nodejs/)

## Node.js 检查模式

由于调试器拥有对执行环境的完全访问权限，恶意行动者还可以使用它在你的 Node.js 进程中注入任意代码。 因此，Node.js 默认不允许调试正在运行的程序。 必须启用一种称为检查器模式的特殊模式才能允许调试。

需使用 `--inspect` 选项来允许 Node.js 进程侦听调试器客户端，该调试器将自己附加到进程并控制程序执行。

默认情况下，使用 `--inspect` 选项启动 Node.js 时，它将在端口 9229 上侦听主机 127.0.0.1。 还可以使用语法 `--inspect=<HOST>:<PORT>` 指定自定义主机和端口。

作为替代方法，可以使用 `--inspect-brk` 选项。 该选项的工作方式与 `--inspect` 相同，但会在代码开始之前中断代码执行。

在启用了检查模式的情况下启动 Node.js 后，可以使用任何兼容的调试器客户端连接到 Node.js 进程。

## 内置调试器

例如，可以使用 [node-inspect](https://github.com/nodejs/node-inspect)。 此命令行调试器与 Node.js 捆绑在一起。 可以通过按如下所述运行程序来使用它：

```bash
node inspect <YOUR_SCRIPT>.js
```

node-inspect 调试器将在启用检查模式的情况下运行 Node.js，同时启动集成的交互式调试器。 它将在代码开始之前暂停执行。 应会看到调试器提示，指出它已成功启动。

```bash
node inspect myscript.js
< Debugger listening on ws://127.0.0.1:9229/ce3689fa-4433-41ee-9d5d-98b5bc5dfa27
< For help, see: https://nodejs.org/en/docs/inspector
< Debugger attached.
Break on start in myscript.js:1
> 1 const express = require('express');
  2
  3 const app = express();
debug>
```

你现在可以使用多个命令来控制程序的执行：

- `cont` 或 `c`：继续。 继续执行到下一个断点或程序末尾。
- `next` 或 `n`：执行下一行。 执行当前上下文中的下一行代码。
- `step` 或 `s`：单步执行。 与 `next` 相同，不同之处在于如果下一行代码是函数调用，则转到此函数代码的第一行。
- `out` 或 `o`：单步跳出。如果当前执行上下文在函数的代码内，请执行该函数的其余代码，然后跳回到最初调用该函数的代码行。
- `restart` 或 `r`：重启。 重启程序，并在代码开始之前暂停执行。

若要在代码中设置或清除断点，使用以下命令：

- `setBreakpoint()` 或 `sb()`：在当前行上添加断点。
- `setBreakpoint(<N>)` 或 `sb(<N>)`：在行号 N 上添加一个断点。
- `clearBreakpoint('myscript.js', <N>)` 或 `cb('myscript.js', <N>)`：清除行号 N 处文件 `myscript.js` 中的断点。

若要获取有关当前执行点的信息，运行以下命令：

- `list(<N>)`：列出包含当前执行点之前和之后 N 行的源代码。
- `exec <EXPR>`：在当前执行上下文中计算表达式。 此命令有助于获取有关当前状态的信息。 例如，可以通过使用 `exec i` 获取名为 `i` 的变量的值。

要记住的命令很多。 值得庆幸的是，还可以使用 `help` 命令显示可用命令的完整列表。 若要随时退出调试器，请按 Ctrl+D 或选择命令 `.exit`。