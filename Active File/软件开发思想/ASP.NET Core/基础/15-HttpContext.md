[HttpContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext) encapsulates all information about an individual HTTP request and response. An `HttpContext` instance is initialized when an HTTP request is received. The `HttpContext` instance is accessible by middleware and app frameworks such as Web API controllers, Razor Pages, SignalR, gRPC, and more.

For more information about accessing the `HttpContext`, see [Access HttpContext in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-context?view=aspnetcore-7.0).

## `HttpRequest`

[HttpContext.Request](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext.request#microsoft-aspnetcore-http-httpcontext-request) provides access to [HttpRequest](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequest). `HttpRequest` has information about the incoming HTTP request, and it's initialized when an HTTP request is received by the server. `HttpRequest` isn't read-only, and middleware can change request values in the middleware pipeline.

Commonly used members on `HttpRequest` include:

| Property                                                     | Description                                                  | Example                                      |
| :----------------------------------------------------------- | :----------------------------------------------------------- | :------------------------------------------- |
| [HttpRequest.Path](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequest.path#microsoft-aspnetcore-http-httprequest-path) | The request path.                                            | `/en/article/getstarted`                     |
| [HttpRequest.Method](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequest.method#microsoft-aspnetcore-http-httprequest-method) | The request method.                                          | `GET`                                        |
| [HttpRequest.Headers](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequest.headers#microsoft-aspnetcore-http-httprequest-headers) | A collection of request headers.                             | `user-agent=Edge` `x-custom-header=MyValue`  |
| [HttpRequest.RouteValues](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequest.routevalues#microsoft-aspnetcore-http-httprequest-routevalues) | A collection of route values. The collection is set when the request is matched to a route. | `language=en` `article=getstarted`           |
| [HttpRequest.Query](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequest.query#microsoft-aspnetcore-http-httprequest-query) | A collection of query values parsed from [QueryString](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequest.querystring#microsoft-aspnetcore-http-httprequest-querystring). | `filter=hello` `page=1`                      |
| [HttpRequest.ReadFormAsync()](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequest.readformasync#microsoft-aspnetcore-http-httprequest-readformasync(system-threading-cancellationtoken)) | A method that reads the request body as a form and returns a form values collection. For information about why `ReadFormAsync` should be used to access form data, see [Prefer ReadFormAsync over Request.Form](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-7.0#prefer-readformasync-over-requestform). | `email=user@contoso.com` `password=TNkt4taM` |
| [HttpRequest.Body](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequest.body#microsoft-aspnetcore-http-httprequest-body) | A [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) for reading the request body. | UTF-8 JSON payload                           |

### Get request headers

[HttpRequest.Headers](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequest.headers#microsoft-aspnetcore-http-httprequest-headers) provides access to the request headers sent with the HTTP request. There are two ways to access headers using this collection:

- Provide the header name to the indexer on the header collection. The header name isn't case-sensitive. The indexer can access any header value.
- The header collection also has properties for getting and setting commonly used HTTP headers. The properties provide a fast, IntelliSense driven way to access headers.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpRequest request) =>
{
    var userAgent = request.Headers.UserAgent;
    var customHeader = request.Headers["x-custom-header"];

    return Results.Ok(new { userAgent = userAgent, customHeader = customHeader });
});

app.Run();
```

### Read request body

An HTTP request can include a request body. The request body is data associated with the request, such as the content of an HTML form, UTF-8 JSON payload, or a file.

[HttpRequest.Body](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequest.body#microsoft-aspnetcore-http-httprequest-body) allows the request body to be read with [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/uploadstream", async (IConfiguration config, HttpContext context) =>
{
    var filePath = Path.Combine(config["StoredFilesPath"], Path.GetRandomFileName());

    await using var writeStream = File.Create(filePath);
    await context.Request.Body.CopyToAsync(writeStream);
});

app.Run();
```

`HttpRequest.Body` can be read directly or used with other APIs that accept stream.

#### Enable request body buffering

The request body can only be read once, from beginning to end. Forward-only reading of the request body avoids the overhead of buffering the entire request body and reduces memory usage. However, in some scenarios, there's a need to read the request body multiple times. For example, middleware might need to read the request body and then rewind it so it's available for the endpoint.

The [EnableBuffering](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httprequestrewindextensions.enablebuffering) extension method enables buffering of the HTTP request body and is the recommended way to enable multiple reads. Because a request can be any size, `EnableBuffering` supports options for buffering large request bodies to disk, or rejecting them entirely.

The middleware in the following example:

- Enables multiple reads with `EnableBuffering`. It must be called before reading the request body.
- Reads the request body.
- Rewinds the request body to the start so other middleware or the endpoint can read it.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Request.EnableBuffering();
    await ReadRequestBody(context.Request.Body);
    context.Request.Body.Position = 0;
    
    await next.Invoke();
});

app.Run();
```

## `HttpResponse`

[HttpContext.Response](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext.response#microsoft-aspnetcore-http-httpcontext-response) provides access to [HttpResponse](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresponse). `HttpResponse` is used to set information on the HTTP response sent back to the client.

Commonly used members on `HttpResponse` include:

| Property                                                     | Description                                                  | Example                                    |
| :----------------------------------------------------------- | :----------------------------------------------------------- | :----------------------------------------- |
| [HttpResponse.StatusCode](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresponse.statuscode#microsoft-aspnetcore-http-httpresponse-statuscode) | The response code. Must be set before writing to the response body. | `200`                                      |
| [HttpResponse.ContentType](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresponse.contenttype#microsoft-aspnetcore-http-httpresponse-contenttype) | The response `content-type` header. Must be set before writing to the response body. | `application/json`                         |
| [HttpResponse.Headers](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresponse.headers#microsoft-aspnetcore-http-httpresponse-headers) | A collection of response headers. Must be set before writing to the response body. | `server=Kestrel` `x-custom-header=MyValue` |
| [HttpResponse.Body](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresponse.body#microsoft-aspnetcore-http-httpresponse-body) | A [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) for writing the response body. | Generated web page                         |

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpResponse response) =>
{
    response.Headers.CacheControl = "no-cache";
    response.Headers["x-custom-header"] = "Custom value";

    return Results.File(File.OpenRead("helloworld.txt"));
});

app.Run();
```

An app can't modify headers after the response has started. Once the response starts, the headers are sent to the client. A response is started by flushing the response body or calling [HttpResponse.StartAsync(CancellationToken)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresponse.startasync#microsoft-aspnetcore-http-httpresponse-startasync(system-threading-cancellationtoken)). The [HttpResponse.HasStarted](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresponse.hasstarted#microsoft-aspnetcore-http-httpresponse-hasstarted) property indicates whether the response has started. An error is thrown when attempting to modify headers after the response has started:

> System.InvalidOperationException: Headers are read-only, response has already started.

### Write response body

An HTTP response can include a response body. The response body is data associated with the response, such as generated web page content, UTF-8 JSON payload, or a file.

[HttpResponse.Body](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresponse.body#microsoft-aspnetcore-http-httpresponse-body) allows the response body to be written with [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

C#Copy

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/downloadfile", async (IConfiguration config, HttpContext context) =>
{
    var filePath = Path.Combine(config["StoredFilesPath"], "helloworld.txt");

    await using var fileStream = File.OpenRead(filePath);
    await fileStream.CopyToAsync(context.Response.Body);
});

app.Run();
```

`HttpResponse.Body` can be written directly or used with other APIs that write to a stream.

### Set response trailers

HTTP/2 and HTTP/3 support response trailers. Trailers are headers sent with the response after the response body is complete. Because trailers are sent after the response body, trailers can be added to the response at any time.

The following code sets trailers using [AppendTrailer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.responsetrailerextensions.appendtrailer):

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpResponse response) =>
{
    // Write body
    response.WriteAsync("Hello world");

    if (response.SupportsTrailers())
    {
        response.AppendTrailer("trailername", "TrailerValue");
    }
});

app.Run();
```

## `RequestAborted`

The [HttpContext.RequestAborted](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext.requestaborted#microsoft-aspnetcore-http-httpcontext-requestaborted) cancellation token can be used to notify that the HTTP request has been aborted by the client or server. The cancellation token should be passed to long-running tasks so they can be canceled if the request is aborted. For example, aborting a database query or HTTP request to get data to return in the response.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var httpClient = new HttpClient();
app.MapPost("/books/{bookId}", async (int bookId, HttpContext context) =>
{
    var stream = await httpClient.GetStreamAsync(
        $"http://consoto/books/{bookId}.json", context.RequestAborted);

    // Proxy the response as JSON
    return Results.Stream(stream, "application/json");
});

app.Run();
```

The `RequestAborted` cancellation token doesn't need to be used for request body read operations because reads always throw immediately when the request is aborted. The `RequestAborted` token is also usually unnecessary when writing response bodies, because writes immediately no-op when the request is aborted.

In some cases, passing the `RequestAborted` token to write operations can be a convenient way to force a write loop to exit early with an [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception). However, it's typically better to pass the `RequestAborted` token into any asynchronous operations responsible for retrieving the response body content instead.

## `Abort()`

The [HttpContext.Abort()](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext.abort#microsoft-aspnetcore-http-httpcontext-abort) method can be used to abort an HTTP request from the server. Aborting the HTTP request immediately triggers the [HttpContext.RequestAborted](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext.requestaborted#microsoft-aspnetcore-http-httpcontext-requestaborted) cancellation token and sends a notification to the client that the server has aborted the request.

The middleware in the following example:

- Adds a custom check for malicious requests.
- Aborts the HTTP request if the request is malicious.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    if (RequestAppearsMalicious(context.Request))
    {
        // Malicious requests don't even deserve an error response (e.g. 400).
        context.Abort();
        return;
    }

    await next.Invoke();
});

app.Run();
```