## [概览](https://developer.mozilla.org/zh-CN/docs/Learn/Server-side/First_steps/Web_frameworks#概览)

服务器端框架 (亦称 "web 应用框架") 使编写、维护和扩展 web 应用更加容易。它们提供工具和库来实现简单、常见的开发任务，包括 路由处理，数据库交互，会话支持和用户验证，格式化输出 (e.g. HTML, JSON, XML), 提高安全性应对网络攻击。

下一节将详细介绍 web 框架如何简化 web 应用程序开发。然后，我将阐述一些选择 web 框架的标准，并给你列出一些选项。

## [web 框架可以为你做什么？](https://developer.mozilla.org/zh-CN/docs/Learn/Server-side/First_steps/Web_frameworks#web_框架可以为你做什么？)

你并不是必须得使用一个服务器端的 web 框架，但是我们强烈建议你使用框架——框架会使得你的生活更美好。

这个部分我们讲一下 web 框架通常会提供的功能（并不是说每一个框架一定会提供下面的所有功能！）

### [直接处理 HTTP 请求和响应](https://developer.mozilla.org/zh-CN/docs/Learn/Server-side/First_steps/Web_frameworks#直接处理_http_请求和响应)

从上一篇文章中我们知道，web 服务器和浏览器通过 HTTP 协议进行通信——服务器等待来自浏览器的 HTTP 请求然后在 HTTP 回应中返回相关信息。web 框架允许你编写简单语法的代码，即可生成处理这些请求和回应的代码。这意味着你的工作变得简单、交互变得简单、并且使用抽象程度高的代码而不是底层代码。

每一个“view”函数（请求的处理者）接受一个包含请求信息的`HttpRequest`对象，并且被要求返回一个包含格式化输出的`HttpResponse`（在下面的例子中是一个字符串）。

```py
# Django view function
from django.http import HttpResponse

def index(request):
    # Get an HttpRequest (request)
    # perform operations using information from the request.
    # Return HttpResponse
    return HttpResponse('Output string to return')
```

### [将请求路由到相关的 handler 中](https://developer.mozilla.org/zh-CN/docs/Learn/Server-side/First_steps/Web_frameworks#将请求路由到相关的_handler_中)

大多数的站点会提供一系列不同资源，通过特定的 URL 来访问。如果都放在一个函数里面，网站会变得很难维护。所以 web 框架提供一个简单机制来匹配 URL 和特定处理函数。这种方式对网站维护也有好处，因为你只需要改变用来传输特定功能的 URL 而不用改变任何底层代码。

不同的框架使用不同机制进行匹配。比如 Flask（Python）框架通过使用装饰器来增加视图的路由。

```py
@app.route("/")
def hello():
    return "Hello World!"
```

然而，Django 则期望开发者们定义一张 URL pattern 和视图函数 URL 的匹配列表。

```py
urlpatterns = [
    url(r'^$', views.index),
    # example: /best/myteamname/5/
    url(r'^(?P<team_name>\w.+?)/(?P<team_number>[0-9]+)/$', views.best),
]
```

### [使从请求中获得数据变得简单](https://developer.mozilla.org/zh-CN/docs/Learn/Server-side/First_steps/Web_frameworks#使从请求中获得数据变得简单)

数据在 HTTP 请求中的编码方式有很多种。一个从服务器获得文件或者数据的 HTTP `GET`请求可能会按照 URL 参数中要求的或者 URL 结构中的方式进行编码。一个更新服务器上数据的 HTTP `POST`请求则会在请求主体中包含像“POST data”这样的更新信息。HTTP 请求也可能包含客户端 cookie 中的即时会话和用户信息。

web 框架提供一个获得这些信息的适合编程语言的机制。比如，Django 传递给视图函数的`HttpRequest`对象包含着获得目标 URL 的方式和属性、请求的类型（比如一个 HTTP `GET`）、`GET`或者`POST`参数、cookie 或者 session 数据等等。Django 也可以通过在 URL 匹配表中定义“抓取模式”来在 URL 结构中传递编码了的信息（如上面的编码片段中的最后一行）。

### [抽象和简化数据库接口](https://developer.mozilla.org/zh-CN/docs/Learn/Server-side/First_steps/Web_frameworks#抽象和简化数据库接口)

网站使用数据库来存储与用户分享的信息和用户个人信息。web 框架通常会提供一个数据库层来抽象数据库的读、写、查询和删除操作。这一个抽象层被称作对象关系映射器（ORM）。

使用对象关系映射器有两个好处：

- 你不需要改变使用数据库的代码就可以替换底层数据库。这就允许开发者依据用途优化不同数据库的特点。
- 简单的数据的验证可以被植入到框架中。这会使得检查数据是否按照正确的方式存储在数据库字段中或者是否是特定的格式变得简单（比如邮箱地址），并且不是恶意的（黑客可以利用特定的编码模式来进行一些如删除数据库记录的非法操作）。

比如，Django 框架提供一个对象关系映射，并且将用来定义数据库记录的结构称作模型。模型制定被存储的字段类型，可能也会提供那些要被存储的信息的验证（比如，一个 email 字段只允许合法 email 地址）。字段可能也会指明最大信息量、默认值、选项列表、帮助文档、表单标签等。这个模型不会申明任何底层数据库的信息，因为这是一个只能被我们的代码改变的配置信息。

下面第一个代码片段展示了一个简单的为`Team`对象设计的 Django 模型。这个模型会使用字符字段来存储一个队伍的名字和级别，同时还指定了用来存储每一条记录的最大字符数量。`team_level`是一个枚举字段，所以我们也提供了一个被存储的数据和被展示出来的选项之间的匹配，同时指定了一个默认值。

```py
#best/models.py

from django.db import models

class Team(models.Model):
    team_name = models.CharField(max_length=40)

    TEAM_LEVELS = (
        ('U09', 'Under 09s'),
        ('U10', 'Under 10s'),
        ('U11, 'Under 11s'),
        ...  #list our other teams
    )
    team_level = models.CharField(max_length=3,choices=TEAM_LEVELS,default='U11')
```

Django 模型提供了简单的搜索数据库的查询 API。这可以通过使用不同标准来同时匹配一系列的字段（比如精确、不区分大小写、大于等等），并且支持一些复杂的陈述（比如，你可以指定在 U11 水平的队伍中搜索队伍名字中以“Fr”开头或者“al”结尾的队伍）。

第二个代码片段展示了一个视图函数（资源处理器），这个视图函数用来展示所有 U09 水平的队伍——通过指明过滤出所有`team_level`字段能准确匹配'U09'的队伍（注意过滤规则如何传递给`filter( )`，它被视为一个变量：`team_level__exact`，由字段名、匹配类型和分隔它们的双重下划线组成）。

```py
#best/views.py

from django.shortcuts import render
from .models import Team

def youngest(request):
    list_teams = Team.objects.filter(team_level__exact="U09")
    context = {'youngest_teams': list_teams}
    return render(request, 'best/index.html', context)
```

### [渲染数据](https://developer.mozilla.org/zh-CN/docs/Learn/Server-side/First_steps/Web_frameworks#渲染数据)

web 框架经常提供模板系统。这些允许你制定输出文档的结构，使用为那些数据准备的将在页面生成时添加进去的占位符。模板经常是用来生成 HTML 的，但是也可以用来生成一些其他的文档。

框架提供一个机制，使得从存储的数据中生成其他格式数据变得简单，包括[JSON](https://developer.mozilla.org/zh-CN/docs/Glossary/JSON)和[XML](https://developer.mozilla.org/zh-CN/docs/Glossary/XML)。

比如，Django 模板允许你通过使用“双重花括号”（如 `{{ variable_name }}`）来指定变量，当页面被渲染出来时，这些变量会被从视图函数传递过来的值代替。模板系统也会提供表达支持（通过语法 `{% expression %}` 来实现），这样就允许模板进行一些简单的操作比如迭代传递给模板的值列表。

**备注：** 很多其他的模板系统使用相似的语法，比如：Jinja2 (Python), handlebars (JavaScript), moustache (JavaScript), 等。

下面的代码片段展示了它们如何工作的。下面的内容接着从上一个部分而来的“youngest team”实例，HTML 模板通过视图函数传进一个叫做 youngest_teams 的值列表。在 HTML 骨架中我们有一个初步检查 youngest_teams 变量是否存在的表示，然后会在 for 循环里面进行迭代。在每一次迭代中模板会以列表元素的形式展示队伍的 team_name 值。

```html
#best/templates/best/index.html

<!DOCTYPE html>
<html lang="en">
<body>

 {% if youngest_teams %}
    <ul>
    {% for team in youngest_teams %}
        <li>{{ team.team_name }}</li>
    {% endfor %}
    </ul>
{% else %}
    <p>No teams are available.</p>
{% endif %}

</body>
</html>
```