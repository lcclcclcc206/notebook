Windows 本机支持 UI 元素、文件名等的 Unicode 字符串。 Unicode 是首选字符编码，因为它支持所有字符集和语言。 Windows 使用 UTF-16 编码表示 Unicode 字符，其中每个字符编码为一个或两个 16 位值。 UTF-16 字符称为 *宽* 字符，以将它们与 8 位 ANSI 字符区分开来。 Visual C++ 编译器支持宽字符的内置数据类型 **wchar_t** 。 头文件 WinNT.h 还定义了以下 **typedef**。

```C++
typedef wchar_t WCHAR;
```

MSDN 示例代码中将看到这两个版本。 若要声明宽字符文本或宽字符字符串文本，请将 **L** 置于文本前面。

```C++
wchar_t a = L'a';
wchar_t *str = L"hello";
```

下面是一些其他与字符串相关的 typedefs，你将看到：

| Typedef                   | 定义             |
| :------------------------ | :--------------- |
| **CHAR**                  | `char`           |
| **PSTR** 或 **LPSTR**     | `char*`          |
| **PCSTR** 或 **LPCSTR**   | `const char*`    |
| **PWSTR** 或 **LPWSTR**   | `wchar_t*`       |
| **PCWSTR** 或 **LPCWSTR** | `const wchar_t*` |

## Unicode 和 ANSI 函数

当 Microsoft 向 Windows 引入 Unicode 支持时，它通过提供两组并行 API（一个用于 ANSI 字符串，另一个用于 Unicode 字符串）来缓解转换。 例如，有两个函数用于设置窗口标题栏的文本：

- **SetWindowTextA** 采用 ANSI 字符串。
- **SetWindowTextW** 采用 Unicode 字符串。

在内部，ANSI 版本将字符串转换为 Unicode。 Windows 标头还定义了一个宏，该宏在定义预处理器符号 `UNICODE` 或 ANSI 版本时解析为 Unicode 版本。

```C++
#ifdef UNICODE
#define SetWindowText  SetWindowTextW
#else
#define SetWindowText  SetWindowTextA
#endif 
```

在 MSDN 中，函数记录在 [**SetWindowText**](https://docs.microsoft.com/zh-cn/windows/desktop/api/winuser/nf-winuser-setwindowtexta) 名称下，即使这确实是宏名称，而不是实际函数名称。

**新应用程序应始终调用 Unicode 版本。** 许多世界语言都需要 Unicode。 如果使用 ANSI 字符串，则无法本地化应用程序。 ANSI 版本效率也较低，因为操作系统必须在运行时将 ANSI 字符串转换为 Unicode。 根据偏好，可以显式调用 Unicode 函数，例如 **SetWindowTextW** 或使用宏。 MSDN 上的示例代码通常调用宏，但两种形式完全相同。 Windows 中的大多数较新的 API 只有 Unicode 版本，没有相应的 ANSI 版本。

## TCHAR

在应用程序需要同时支持Windows NT以及 Windows 95、Windows 98 和 Windows Me 时，根据目标平台，为 ANSI 或 Unicode 字符串编译相同的代码非常有用。 为此，Windows SDK 提供将字符串映射到 Unicode 或 ANSI 的宏，具体取决于平台。

| 宏                       | Unicode   | ANSI   |
| :----------------------- | :-------- | :----- |
| TCHAR                    | `wchar_t` | `char` |
| `TEXT("x")` 或 `_T("x")` | `L"x"`    | `"x"`  |

例如，以下代码：

```C++
SetWindowText(TEXT("My Application"));
```

解析为以下项之一：

```C++
SetWindowTextW(L"My Application"); // Unicode function with wide-character string.

SetWindowTextA("My Application");  // ANSI function.
```

**TEXT**和 **TCHAR** 宏目前不太有用，因为所有应用程序都应使用 Unicode。 但是，你可能会在较旧的代码和某些 MSDN 代码示例中看到它们。

Microsoft C 运行时库的标头定义了一组类似的宏。 例如，如果未定义，**_tcslen**解析为 **strlen**`_UNICODE`;否则会解析为 **wcslen**，这是 **strlen** 的宽字符版本。

```C++
#ifdef _UNICODE
#define _tcslen     wcslen
#else
#define _tcslen     strlen
#endif 
```

请注意：某些标头使用预处理器符号 `UNICODE`，另一些标头使用 `_UNICODE` 下划线前缀。 **始终定义这两个符号。** 默认情况下，Visual C++ 会在创建新项目时设置它们。