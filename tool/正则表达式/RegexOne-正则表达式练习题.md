## 问题 1: 匹配一个十进制数

乍一看，写一个正则表达式来匹配一个数字应该很容易吧？

我们有 \d 特殊字符来匹配任何数字，我们需要做的就是匹配小数点对吗？对于简单的数字，这可能是正确的，但在处理科学或金融数字时，您通常必须处理正数和负数、有效数字、指数，甚至不同的表示（例如用于分隔千和百万的逗号）。

以下是您可能会遇到的几种不同格式的数字。请注意您将如何使用点元字符匹配小数点本身而不是任意字符。如果您在跳过最后一个数字时遇到问题，请注意该数字与其余数字相比如何结束该行。

```
Task	Text	 
Match	3.14529	
Match	-255.34	
Match	128	
Match	1.9e10	
Match	123,340.00	
Skip	720p

^-?\d+(,\d+)*(\.\d+(e\d+)?)?$
```

## 问题 2: 匹配电话号码

验证电话号码是另一项棘手的任务，具体取决于您获得的输入类型。拥有需要区号的州外电话号码或需要前缀的国际号码会增加正则表达式的复杂性，就像人们输入电话号码的个人偏好一样（有些人输入破折号或空格，而其他人则这样做）不是例如）。

以下是您在使用真实数据时可能会遇到的一些电话号码，请编写一个与该号码匹配并捕获正确区号的正则表达式。

```
Task	    Text	        Capture Groups	 
Capture	    415-555-1234	415	
Capture	    650-555-2345	650	
Capture	    (416)555-3456	416	
Capture	    202 555 4567	202	
Capture	    4035555678	    403	
Capture	    1 416 555 9292	416

1?[\s-]?\(?(\d{3})\)?[\s-]?\d{3}[\s-]?\d{4}
```

## 问题 3: 匹配电子邮件

当您处理 HTML 表单时，根据正则表达式验证表单输入通常很有用。特别是，由于规范的复杂性，电子邮件很难正确匹配，我建议使用内置语言或框架功能。但是，您可以使用我们迄今为止所学的知识构建一个非常强大的正则表达式，该表达式可以非常轻松地匹配大量常见电子邮件。

需要注意的一件事是，很多人使用加号寻址，例如“名称+过滤器@gmail.com”。它直接指向“名称@gmail.com”，但可以使用额外信息进行过滤。此外，有些域名有多个部分，例如，您可以在“hellokitty.hk.com”注册一个域名，并有一个格式为“ilove@hellokitty.hk.com”的电子邮件，因此您必须匹配电子邮件的域部分时要小心。

下面是一些常见的电子邮件，在这个例子中，尝试捕获电子邮件的名称，不包括过滤器（+ 字符及之后）和域（@ 字符及之后）。

```
Task	    Text	                            Capture Groups	 
Capture	    tom@hogwarts.com	                tom	
Capture	    tom.riddle@hogwarts.com	            tom.riddle	
Capture	    tom.riddle+regexone@hogwarts.com	tom.riddle	
Capture	    tom@hogwarts.eu.com	                tom	
Capture	    potter@hogwarts.com	                potter	
Capture	    harry@hogwarts.com	                harry	
Capture	    hermione+regexone@hogwarts.com	    hermione	

^([\w\.]*)
```

## 问题 4: 匹配 HTML

如果您正在寻找一种强大的方式来解析 HTML，由于当今互联网上 html 页面的脆弱性，正则表达式通常不是答案——常见的错误，如缺少结束标记、不匹配的标记、忘记关闭属性引用，会所有这些都破坏了一个完美的正则表达式。相反，您可以使用 Beautiful Soup 或 html5lib（都是 Python）或 phpQuery (PHP) 等库，它们不仅可以解析 HTML，还可以让您快速轻松地访问 DOM。

也就是说，有时您希望在编辑器中快速匹配标签和标签内容，如果您可以保证输入，正则表达式是一个很好的工具。正如您在下面的示例中看到的那样，您可能需要注意具有额外转义引号和嵌套标签的奇数属性的一些事情。

继续为以下示例编写正则表达式。

```
Task	Text	                                    Capture Groups	 
Capture	<a>This is a link</a>	                    a	
Capture	<a href='https://regexone.com'>Link</a>	    a	
Capture	<div class='test_style'>Test</div>	        div	
Capture	<div>Hello <span>world</span></div>	        div
```

## 问题 5: 匹配特定文件名

如果您经常使用 Linux 或命令行，则经常要处理文件列表。大多数文件都有一个文件名组件和一个扩展名，但在 Linux 中，隐藏文件没有文件名也是很常见的。

在这个简单的例子中，只提取图像文件的文件名和扩展名类型（不包括当前正在编辑的图像的临时文件）。图像文件定义为 .jpg、.png 和 .gif。

```
Task	    Text	                Capture Groups	 
Skip	    .bash_profile		
Skip	    workspace.doc		
Capture	    img0912.jpg	            img0912 jpg	
Capture	    updated_img0912.png	    updated_img0912 png	
Skip	    documentation.html		
Capture	    favicon.gif	            favicon gif	
Skip	    img0912.jpg.tmp		
Skip	    access.lock	

```

## 问题 6: 从行首和行尾修剪空白

有时，您会发现自己的日志文件中包含格式错误的空白，其中的行缩进过多或不足。解决此问题的一种方法是使用编辑器的搜索、替换和正则表达式来提取行的内容，而无需额外的空格。

我们之前已经看到如何分别使用帽子 ^ 和美元符号 $ 匹配整行文本。当与空格 \s 结合使用时，您可以轻松跳过所有前后空格。

编写一个简单的正则表达式来捕获每一行的内容，没有多余的空格。

```
Task	Text	                            Capture Groups	 
Capture				The quick brown fox...	The quick brown fox...	
Capture	   jumps over the lazy dog.	        jumps over the lazy dog.
```

## 问题 7: 从日志文件提取信息

在本例中，我们将使用 Android adb 调试会话的实际输出。您的目标是使用我们迄今为止学到的任何正则表达式技术来提取堆栈跟踪的文件名、方法名和行号（它们遵循“at package.class.methodname(filename:linenumber)”形式） ）。

```
Task	    Text	                                                    Capture Groups	 
Skip	    W/dalvikvm( 1553): threadid=1: uncaught exception		
Skip	    E/( 1553): FATAL EXCEPTION: main		
Skip	    E/( 1553): java.lang.StringIndexOutOfBoundsException		
Capture	    E/( 1553):   at widget.List.makeView(ListView.java:1727)	makeView 
                                                                        ListView.java 1727	
Capture	    E/( 1553):   at widget.List.fillDown(ListView.java:652)	    fillDown 
                                                                        ListView.java 652	
Capture	    E/( 1553):   at widget.List.fillFrom(ListView.java:709)	    fillFrom 
                                                                        ListView.java 709
```

## 问题 8: 从 URL 解析和提取数据

通过网络处理文件和资源时，您经常会遇到可以直接解析和使用的 URI 和 URL。大多数标准库都会有类来解析和构造这些类型的标识符，但是如果您需要在日志或更大的文本语料库中匹配它们，您可以使用正则表达式很容易地从它们的结构化格式中提取信息。

URI，或统一资源标识符，是一种资源的表示，通常由scheme、host、port（可选）和resource path组成，分别在下面突出显示。

http://regexone.com:80/page

该方案描述了与之通信的协议，主机和端口描述了资源的来源，完整路径描述了资源在来源处的位置。

在下面的练习中，尝试提取列出的所有资源的协议、主机和端口。

```
Task	    Text	                                                            Capture Groups	 
Capture	    ftp://file_server.com:21/top_secret/life_changing_plans.pdf	        ftp file_server.com 21	
Capture	    https://regexone.com/lesson/introduction#section	                https regexone.com	
Capture	    file://localhost:4040/zip_file	                                    file localhost 4040	
Capture	    https://s3cur3-server.com:9999/	                                    https s3cur3-server.com 9999	
Capture	    market://search/angry%20birds	                                    market search
```


