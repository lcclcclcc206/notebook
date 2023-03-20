HTTP 日志记录是一种中间件，用于记录传入 HTTP 请求和 HTTP 响应的相关信息。 HTTP 日志记录可以记录：

- HTTP 请求信息
- 公共属性
- 标头
- 正文
- HTTP 响应信息

在以下几种方案中，HTTP 日志记录很有价值：

- 记录传入请求和响应的相关信息。
- 筛选请求和响应的哪些部分被记录。
- 筛选要记录的头。

HTTP 日志记录可能会降低应用的性能，尤其是在记录请求和响应正文时。 在选择要记录的字段时请考虑性能影响。 测试所选日志记录属性的性能影响。

> HTTP 日志记录可能会记录个人身份信息 (PII)。 请考虑风险，并避免记录敏感信息。

## 启用 HTTP 日志记录

HTTP 日志记录是通过 [UseHttpLogging](https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.aspnetcore.builder.httploggingbuilderextensions.usehttplogging) 启用，它添加了 HTTP 日志记录中间件。

```csharp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpLogging();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");

app.Run();
```