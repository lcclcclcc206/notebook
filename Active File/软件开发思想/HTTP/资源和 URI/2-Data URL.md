**Data URL**，即前缀为 `data:` 协议的 URL，其允许内容创建者向文档中嵌入小文件。它们之前被称作“data URI”，直到这个名字被 WHATWG 弃用。

## [语法](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/Data_URLs#语法)

Data URL 由四个部分组成：前缀（`data:`）、指示数据类型的 MIME 类型、如果非文本则为可选的 `base64` 标记、数据本身：

```
data:[<mediatype>][;base64],<data>
```

`mediatype` 是个 [MIME 类型](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_types)的字符串，例如 `'image/jpeg'` 表示 JPEG 图像文件。如果被省略，则默认值为 `text/plain;charset=US-ASCII`。

如果数据包含 [RFC 3986 中定义为保留字符](https://datatracker.ietf.org/doc/html/rfc3986#section-2.2)的字符或包含空格符、换行符或者其他非打印字符，这些字符必须进行[百分号编码](https://developer.mozilla.org/zh-CN/docs/Glossary/percent-encoding)（又名“URL 编码”）。

如果数据是文本类型，你可以直接将文本嵌入（根据文档类型，使用合适的实体字符或转义字符）。否则，你可以指定 `base64` 来嵌入 base64 编码的二进制数据。你可以在[这里](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_types)和[这里](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Common_types)找到更多关于 MIME 类型的信息。

下面是一些示例：

- `data:,Hello%2C%20World!`

  简单的 text/plain 类型数据。注意逗号如何[百分号编码](https://developer.mozilla.org/zh-CN/docs/Glossary/percent-encoding)为 `%2C`，空格字符如何编码为 `%20`。

- `data:text/plain;base64,SGVsbG8sIFdvcmxkIQ%3D%3D`

  上一条示例的 base64 编码版本

- `data:text/html,%3Ch1%3EHello%2C%20World!%3C%2Fh1%3E`

  一个 HTML 文档源代码 `<h1>Hello, World</h1>`

- `data:text/html,%3Cscript%3Ealert%28%27hi%27%29%3B%3C%2Fscript%3E`

  带有`<script>alert('hi');</script>` 的 HTML 文档，用于执行 JavaScript 警告。注意，需要闭合的 script 标签。

## 请参考

[Data URL - HTTP | MDN (mozilla.org)](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/Data_URLs)