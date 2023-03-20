绝大多数Windows API 由函数或组件对象模型 (COM) 接口组成。 很少Windows API 作为 C++ 类提供。 (一个值得注意的异常是GDI+，这是二维图形 API 之一。)

Windows标头包含大量 typedefs。 其中许多是在头文件 WinDef.h 中定义的。 以下是经常遇到的一些操作。

## 整数类型

| 数据类型      | 大小  | 签署？ |
| :------------ | :---- | :----- |
| **BYTE**      | 8 位  | 无符号 |
| **DWORD**     | 32 位 | 无符号 |
| **INT32**     | 32 位 | 有符号 |
| **INT64**     | 64 位 | 有符号 |
| **LONG**      | 32 位 | 有符号 |
| **LONGLONG**  | 64 位 | 有符号 |
| **UINT32**    | 32 位 | 无符号 |
| **UINT64**    | 64 位 | 无符号 |
| ULONG         | 32 位 | 无符号 |
| **ULONGLONG** | 64 位 | 无符号 |
| **WORD**      | 16 位 | 无符号 |

## 布尔类型

**BOOL** 是 **int** 的类型别名，不同于 C++ 的 **布尔值**，与表示 [布尔](https://en.wikipedia.org/wiki/Boolean_algebra) 值的其他类型不同。 头文件 `WinDef.h` 还定义了两个值，用于 **BOOL**。

```C++
#define FALSE    0 
#define TRUE     1
```

然而，尽管 **此定义为 TRUE**，但返回 **BOOL** 类型的大多数函数都可以返回任何**非零值**来指示布尔真理。

## 指针类型

Windows定义表单*指针到 X* 的许多数据类型。 这些前缀通常为名称中的 *P-* 或 *LP。* 例如， **LPRECT** 是指向 [**RECT**](https://docs.microsoft.com/zh-CN/previous-versions//dd162897(v=vs.85)) 的指针，其中 **RECT** 是描述矩形的结构。 以下变量声明等效。

```C++
RECT*  rect;  // Pointer to a RECT structure.
LPRECT rect;  // The same
PRECT  rect;  // Also the same.
```

在 16 位体系结构上， (16 位Windows) 有 2 种类型的指针，*P* 表示“指针”，*LP* 表示“长指针”。 长指针 (也称为 *远指针* ，) 用于处理当前段之外的内存范围。 保留 *LP* 前缀，以便更轻松地将 16 位代码移植到 32 位Windows。 今天没有区别，这些指针类型都是等效的。 避免使用这些前缀;或者，如果必须使用一个，请使用 *P*。