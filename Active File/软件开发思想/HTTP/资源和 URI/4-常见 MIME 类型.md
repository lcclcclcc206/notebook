[MIME 类型 - HTTP | MDN (mozilla.org)](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types)

**媒体类型**（通常称为 **Multipurpose Internet Mail Extensions** 或 **MIME** 类型）是一种标准，用来表示文档、文件或字节流的性质和格式。它在[IETF RFC 6838](https://tools.ietf.org/html/rfc6838)中进行了定义和标准化。

互联网号码分配机构（[IANA](https://www.iana.org/)）是负责跟踪所有官方 MIME 类型的官方机构，您可以在[媒体类型](https://www.iana.org/assignments/media-types/media-types.xhtml)页面中找到最新的完整列表。

## 常见 MIME 类型列表

这是一份 MIME 类型列表，以及各个类型的文档类别，按照它们的常见扩展名排序。

两种主要的 MIME 类型在默认类型中扮演了重要的角色：

- `text/plain` 表示文本文件的默认值。一个文本文件应当是人类可读的，并且不包含二进制数据。
- `application/octet-stream` 表示所有其他情况的默认值。一种未知的文件类型应当使用此类型。浏览器在处理这些文件时会特别小心，试图防止、避免用户的危险行为。

IANA 是 MIME 媒体类型的官方注册机构，并维护了 [list of all the official MIME types](https://www.iana.org/assignments/media-types/media-types.xhtml)。下面的表格列出了 Web 上的一些重要 MIME 类型：

| 扩展名         | 文档类型                                                     | MIME 类型                                                    |
| :------------- | :----------------------------------------------------------- | :----------------------------------------------------------- |
| `.aac`         | AAC audio                                                    | `audio/aac`                                                  |
| `.abw`         | [AbiWord](https://en.wikipedia.org/wiki/AbiWord) document    | `application/x-abiword`                                      |
| `.arc`         | Archive document (multiple files embedded)                   | `application/x-freearc`                                      |
| `.avi`         | AVI: Audio Video Interleave                                  | `video/x-msvideo`                                            |
| `.azw`         | Amazon Kindle eBook format                                   | `application/vnd.amazon.ebook`                               |
| `.bin`         | Any kind of binary data                                      | `application/octet-stream`                                   |
| `.bmp`         | Windows OS/2 Bitmap Graphics                                 | `image/bmp`                                                  |
| `.bz`          | BZip archive                                                 | `application/x-bzip`                                         |
| `.bz2`         | BZip2 archive                                                | `application/x-bzip2`                                        |
| `.csh`         | C-Shell script                                               | `application/x-csh`                                          |
| `.css`         | Cascading Style Sheets (CSS)                                 | `text/css`                                                   |
| `.csv`         | Comma-separated values (CSV)                                 | `text/csv`                                                   |
| `.doc`         | Microsoft Word                                               | `application/msword`                                         |
| `.docx`        | Microsoft Word (OpenXML)                                     | `application/vnd.openxmlformats-officedocument.wordprocessingml.document` |
| `.eot`         | MS Embedded OpenType fonts                                   | `application/vnd.ms-fontobject`                              |
| `.epub`        | Electronic publication (EPUB)                                | `application/epub+zip`                                       |
| `.gif`         | Graphics Interchange Format (GIF)                            | `image/gif`                                                  |
| `.htm .html`   | HyperText Markup Language (HTML)                             | `text/html`                                                  |
| `.ico`         | Icon format                                                  | `image/vnd.microsoft.icon`                                   |
| `.ics`         | iCalendar format                                             | `text/calendar`                                              |
| `.jar`         | Java Archive (JAR)                                           | `application/java-archive`                                   |
| `.jpeg` `.jpg` | JPEG images                                                  | `image/jpeg`                                                 |
| `.js`          | JavaScript                                                   | `text/javascript`                                            |
| `.json`        | JSON format                                                  | `application/json`                                           |
| `.jsonld`      | JSON-LD format                                               | `application/ld+json`                                        |
| `.mid` `.midi` | Musical Instrument Digital Interface (MIDI)                  | `audio/midi` `audio/x-midi`                                  |
| `.mjs`         | JavaScript module                                            | `text/javascript`                                            |
| `.mp3`         | MP3 audio                                                    | `audio/mpeg`                                                 |
| `.mpeg`        | MPEG Video                                                   | `video/mpeg`                                                 |
| `.mpkg`        | Apple Installer Package                                      | `application/vnd.apple.installer+xml`                        |
| `.odp`         | OpenDocument presentation document                           | `application/vnd.oasis.opendocument.presentation`            |
| `.ods`         | OpenDocument spreadsheet document                            | `application/vnd.oasis.opendocument.spreadsheet`             |
| `.odt`         | OpenDocument text document                                   | `application/vnd.oasis.opendocument.text`                    |
| `.oga`         | OGG audio                                                    | `audio/ogg`                                                  |
| `.ogv`         | OGG video                                                    | `video/ogg`                                                  |
| `.ogx`         | OGG                                                          | `application/ogg`                                            |
| `.otf`         | OpenType font                                                | `font/otf`                                                   |
| `.png`         | Portable Network Graphics                                    | `image/png`                                                  |
| `.pdf`         | Adobe [Portable Document Format](https://acrobat.adobe.com/us/en/why-adobe/about-adobe-pdf.html) (PDF) | `application/pdf`                                            |
| `.ppt`         | Microsoft PowerPoint                                         | `application/vnd.ms-powerpoint`                              |
| `.pptx`        | Microsoft PowerPoint (OpenXML)                               | `application/vnd.openxmlformats-officedocument.presentationml.presentation` |
| `.rar`         | RAR archive                                                  | `application/x-rar-compressed`                               |
| `.rtf`         | Rich Text Format (RTF)                                       | `application/rtf`                                            |
| `.sh`          | Bourne shell script                                          | `application/x-sh`                                           |
| `.svg`         | Scalable Vector Graphics (SVG)                               | `image/svg+xml`                                              |
| `.swf`         | [Small web format](https://en.wikipedia.org/wiki/SWF) (SWF) or Adobe Flash document | `application/x-shockwave-flash`                              |
| `.tar`         | Tape Archive (TAR)                                           | `application/x-tar`                                          |
| `.tif .tiff`   | Tagged Image File Format (TIFF)                              | `image/tiff`                                                 |
| `.ttf`         | TrueType Font                                                | `font/ttf`                                                   |
| `.txt`         | Text, (generally ASCII or ISO 8859-*n*)                      | `text/plain`                                                 |
| `.vsd`         | Microsoft Visio                                              | `application/vnd.visio`                                      |
| `.wav`         | Waveform Audio Format                                        | `audio/wav`                                                  |
| `.weba`        | WEBM audio                                                   | `audio/webm`                                                 |
| `.webm`        | WEBM video                                                   | `video/webm`                                                 |
| `.webp`        | WEBP image                                                   | `image/webp`                                                 |
| `.woff`        | Web Open Font Format (WOFF)                                  | `font/woff`                                                  |
| `.woff2`       | Web Open Font Format (WOFF)                                  | `font/woff2`                                                 |
| `.xhtml`       | XHTML                                                        | `application/xhtml+xml`                                      |
| `.xls`         | Microsoft Excel                                              | `application/vnd.ms-excel`                                   |
| `.xlsx`        | Microsoft Excel (OpenXML)                                    | `application/vnd.openxmlformats-officedocument.spreadsheetml.sheet` |
| `.xml`         | `XML`                                                        | `application/xml` 代码对普通用户来说不可读 ([RFC 3023](https://tools.ietf.org/html/rfc3023#section-3), section 3) `text/xml` 代码对普通用户来说可读 ([RFC 3023](https://tools.ietf.org/html/rfc3023#section-3), section 3) |
| `.xul`         | XUL                                                          | `application/vnd.mozilla.xul+xml`                            |
| `.zip`         | ZIP archive                                                  | `application/zip`                                            |
| `.3gp`         | [3GPP](https://en.wikipedia.org/wiki/3GP_and_3G2) audio/video container | `video/3gpp` `audio/3gpp`（若不含视频）                      |
| `.3g2`         | [3GPP2](https://en.wikipedia.org/wiki/3GP_and_3G2) audio/video container | `video/3gpp2` `audio/3gpp2`（若不含视频）                    |
| `.7z`          | [7-zip](https://en.wikipedia.org/wiki/7-Zip) archive         | `application/x-7z-compressed`                                |

## [语法](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#语法)

### [通用结构](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#通用结构)

```
type/subtype
```

MIME 的组成结构非常简单；由类型与子类型两个字符串中间用`'/'`分隔而组成。不允许空格存在。*type* 表示可以被分多个子类的独立类别。*subtype 表示细分后的每个类型。*

MIME 类型对大小写不敏感，但是传统写法都是小写。

### [独立类型](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#独立类型)

```
text/plain
text/html
image/jpeg
image/png
audio/mpeg
audio/ogg
audio/*
video/mp4
application/*
application/json
application/javascript
application/ecmascript
application/octet-stream
…
```

*独立*类型表明了对文件的分类，可以是如下之一：

| 类型          | 描述                                                         | 典型示例                                                     |
| :------------ | :----------------------------------------------------------- | :----------------------------------------------------------- |
| `text`        | 表明文件是普通文本，理论上是人类可读                         | `text/plain`, `text/html`, `text/css, text/javascript`       |
| `image`       | 表明是某种图像。不包括视频，但是动态图（比如动态 gif）也使用 image 类型 | `image/gif`, `image/png`, `image/jpeg`, `image/bmp`, `image/webp`, `image/x-icon`, `image/vnd.microsoft.icon` |
| `audio`       | 表明是某种音频文件                                           | `audio/midi`, `audio/mpeg, audio/webm, audio/ogg, audio/wav` |
| `video`       | 表明是某种视频文件                                           | `video/webm`, `video/ogg`                                    |
| `application` | 表明是某种二进制数据                                         | `application/octet-stream`, `application/pkcs12`, `application/vnd.mspowerpoint`, `application/xhtml+xml`, `application/xml`, `application/pdf` |

对于 text 文件类型若没有特定的 subtype，就使用 `text/plain`。类似的，二进制文件没有特定或已知的 subtype，即使用 `application/octet-stream`。

### [Multipart 类型](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#multipart_类型)

```
multipart/form-data
multipart/byteranges
```

*Multipart* 类型表示细分领域的文件类型的种类，经常对应不同的 MIME 类型。这是*复合*文件的一种表现方式。`multipart/form-data` 可用于联系 [HTML Forms](https://developer.mozilla.org/zh-CN/docs/Learn/Forms) 和 [`POST`](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Methods/POST) 方法，此外 `multipart/byteranges`使用状态码[`206`](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Status/206) `Partial Content`来发送整个文件的子集，而 HTTP 对不能处理的复合文件使用特殊的方式：将信息直接传送给浏览器（这时可能会建立一个“另存为”窗口，但是却不知道如何去显示内联文件。）

## [重要的 MIME 类型](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#重要的_mime_类型)

### [application/octet-stream](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#applicationoctet-stream)

这是应用程序文件的默认值。意思是 *未知的应用程序文件，*浏览器一般不会自动执行或询问执行。浏览器会像对待 设置了 HTTP 头[`Content-Disposition`](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Headers/Content-Disposition) 值为 `attachment` 的文件一样来对待这类文件。

### [text/plain](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#textplain)

文本文件默认值。即使它*意味着未知的文本文件*，但浏览器认为是可以直接展示的。

**备注：** `text/plain`并不是意味着某种文本数据。如果浏览器想要一个文本文件的明确类型，浏览器并不会考虑他们是否匹配。比如说，如果通过一个表明是下载 CSS 文件的[``](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/link)链接下载了一个 `text/plain` 文件。如果提供的信息是 text/plain，浏览器并不会认出这是有效的 CSS 文件。CSS 类型需要使用 text/css。

### [text/css](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#textcss)

在网页中要被解析为 CSS 的任何 CSS 文件必须指定 MIME 为`text/css`。通常，服务器不识别以.css 为后缀的文件的 MIME 类型，而是将其以 MIME 为`text/plain` 或 `application/octet-stream` 来发送给浏览器：在这种情况下，大多数浏览器不识别其为 CSS 文件，直接忽略掉。特别要注意为 CSS 文件提供正确的 MIME 类型。

### [text/html](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#texthtml)

所有的 HTML 内容都应该使用这种类型。XHTML 的其他 MIME 类型（如`application/xml+html`）现在基本不再使用（HTML5 统一了这些格式）。

### [text/javascript](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#textjavascript)

据 HTML 标准，应该总是使用 MIME 类型 `text/javascript` 服务 JavaScript 文件。其他值不被认为有效，使用那些值可能会导致脚本不被载入或运行。

### [图片类型](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#图片类型)

只有一小部分图片类型是被广泛支持的，Web 安全的，可随时在 Web 页面中使用的：

| MIME 类型       | 图片类型                               |
| :-------------- | :------------------------------------- |
| `image/gif`     | GIF 图片 (无损耗压缩方面被 PNG 所替代) |
| `image/jpeg`    | JPEG 图片                              |
| `image/png`     | PNG 图片                               |
| `image/svg+xml` | SVG 图片 (矢量图)                      |

此处的类型划分有一定的争议，有人认为此处应该增加 WebP（`image/webp`），但是每个新增的图片类型都会增加代码的数量，这会带来一些新的安全问题，所以浏览器供应商对于添加类型非常小心。

另外的一些图片种类可以在 Web 文档中找到。比如很多浏览器支持 *icon 类型的图标作为* favicons 或者类似的图标，并且浏览器在 MIME 类型中的 `image/x-icon` 支持 ICO 图像。

### [音频与视频类型](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#音频与视频类型)

HTML 并没有明确定义被用于[``](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/audio)和[``](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/video)元素所支持的文件类型，所以在 web 上使用的只有相对较小的一组类型。文章 [Media formats supported by the HTML audio and video elements (en-US)](https://developer.mozilla.org/en-US/docs/Web/Media/Formats) 解释了可以被使用的解码器或视频文件格式。

在 web 环境最常用的视频文件的格式，是以下这些这些文件类型：

| MIME 类型                                               | 音频或视频类型                                               |
| :------------------------------------------------------ | :----------------------------------------------------------- |
| `audio/wave` `audio/wav` `audio/x-wav` `audio/x-pn-wav` | 音频流媒体文件。一般支持 PCM 音频编码 (WAVE codec "1") ，其他解码器有限支持（如果有的话）。 |
| `audio/webm`                                            | WebM 音频文件格式。Vorbis 和 Opus 是其最常用的解码器。       |
| `video/webm`                                            | 采用 WebM 视频文件格式的音视频文件。VP8 和 VP9 是其最常用的视频解码器。Vorbis 和 Opus 是其最常用的音频解码器。 |
| `audio/ogg`                                             | 采用 OGG 多媒体文件格式的音频文件。Vorbis 是这个多媒体文件格式最常用的音频解码器。 |
| `video/ogg`                                             | 采用 OGG 多媒体文件格式的音视频文件。常用的视频解码器是 Theora；音频解码器为 Vorbis。 |
| `application/ogg`                                       | 采用 OGG 多媒体文件格式的音视频文件。常用的视频解码器是 Theora；音频解码器为 Vorbis。 |
| `application/json`                                      | application/json (MIME_type) https://en.wikipedia.org/wiki/Media_type#Common_examples https://www.iana.org/assignments/media-types/application/json |

## [设置正确的 MIME 类型的重要性](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_Types#设置正确的_mime_类型的重要性)

很多 web 服务器使用默认的 `application/octet-stream` 来发送未知类型。出于一些安全原因，对于这些资源浏览器不允许设置一些自定义默认操作，导致用户必须存储到本地以使用。常见的导致服务器配置错误的文件类型如下所示：

- RAR 编码文件。在这种情况，理想状态是，设置真实的编码文件类型；但这通常不可能（可能是服务器所未知的类型或者这个文件包含许多其他的不同的文件类型）。这种情况服务器将发送 `application/x-rar-compressed` 作为 MIME 类型，用户不会将其定义为有用的默认操作。
- 音频或视频文件。只有正确设置了 MIME 类型的文件才能被 [``](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/video) 或[``](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Element/audio) 识别和播放。可参照 [use the correct type for audio and video](https://developer.mozilla.org/en-US/Media_formats_supported_by_the_audio_and_video_elements)。
- 专有文件类型。是专有文件时需要特别注意。使用 `application/octet-stream` 作为特殊处理是不被允许的：对于一般的 MIME 类型浏览器不允许定义默认行为（比如“在 Word 中打开”）