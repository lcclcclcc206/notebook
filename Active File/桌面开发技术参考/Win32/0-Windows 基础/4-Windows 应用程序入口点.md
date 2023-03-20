每个Windows程序都包含一个名为 **WinMain** 或 **wWinMain** 的入口点函数。 下面是 **wWinMain** 的签名。

```C++
int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PWSTR pCmdLine, int nCmdShow);
```

这四个参数为：

- *hInstance* 称为“实例句柄”或“模块句柄”。操作系统使用此值在内存中加载可执行文件时标识可执行文件 (EXE) 。 某些Windows函数需要实例句柄，例如加载图标或位图。
- *hPrevInstance* 没有意义。 它在 16 位Windows中使用，但现在始终为零。
- *pCmdLine* 包含命令行参数作为 Unicode 字符串。
- *nCmdShow* 是一个标志，指示主应用程序窗口是最小化、最大化还是正常显示。

该函数返回 **int** 值。 操作系统不使用返回值，但可以使用返回值将状态代码传达给你编写的其他程序。

**WINAPI** 是调用约定。 *调用约定*定义函数如何从调用方接收参数。 例如，它定义参数在堆栈上显示的顺序。 只需确保声明 **wWinMain** 函数，如下所示。

**WinMain** 函数与 **wWinMain** 相同，但命令行参数作为 ANSI 字符串传递。 首选 Unicode 版本。 即使将程序编译为 Unicode，也可以使用 ANSI **WinMain** 函数。 若要获取命令行参数的 Unicode 副本，请调用 [**GetCommandLine**](https://docs.microsoft.com/zh-CN/windows/desktop/api/processenv/nf-processenv-getcommandlinea) 函数。 此函数返回单个字符串中的所有参数。 如果要将参数作为 *argv* 样式数组，请将此字符串传递给 [**CommandLineToArgvW**](https://docs.microsoft.com/zh-CN/windows/desktop/api/shellapi/nf-shellapi-commandlinetoargvw)。

下面是一个空 **的 WinMain** 函数。

```C++
INT WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
    PSTR lpCmdLine, INT nCmdShow)
{
    return 0;
}
```

有了入口点并了解一些基本术语和编码约定后，即可创建完整的 Window 程序。