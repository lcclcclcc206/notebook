`DbContext` 的生存期从创建实例时开始，并在[释放](https://learn.microsoft.com/zh-cn/dotnet/standard/garbage-collection/unmanaged)实例时结束。 `DbContext` 实例旨在用于单个[工作单元](https://www.martinfowler.com/eaaCatalog/unitOfWork.html)。 这意味着 `DbContext` 实例的生存期通常很短。

> 引用上述链接中 Martin Fowler 的话，“工作单元将持续跟踪在可能影响数据库的业务事务中执行的所有操作。 当你完成操作后，它将找出更改数据库作为工作结果时需要执行的所有操作。”

使用 Entity Framework Core (EF Core) 时的典型工作单元包括：

- 创建 `DbContext` 实例
- 根据上下文跟踪实体实例。 实体将在以下情况下被跟踪
  - 正在[从查询返回结果](https://learn.microsoft.com/zh-cn/ef/core/querying/tracking)
  - 正在[添加或附加到上下文](https://learn.microsoft.com/zh-cn/ef/core/saving/disconnected-entities)
- 根据需要对所跟踪的实体进行更改以实现业务规则
- 调用 [SaveChanges](https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.entityframeworkcore.dbcontext.savechanges) 或 [SaveChangesAsync](https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.entityframeworkcore.dbcontext.savechangesasync)。 EF Core 检测所做的更改，并将这些更改写入数据库。
- 释放 `DbContext` 实例

**注意**

- 使用后释放 [DbContext](https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.entityframeworkcore.dbcontext) 非常重要。 这可确保释放所有非托管资源，并注销任何事件或其他挂钩，以防止在实例保持引用时出现内存泄漏。
- [DbContext 不是线程安全的](https://learn.microsoft.com/zh-cn/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues)。 不要在线程之间共享上下文。 请确保在继续使用上下文实例之前，[等待](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/await)所有异步调用。
- EF Core 代码引发的 [InvalidOperationException](https://learn.microsoft.com/zh-cn/dotnet/api/system.invalidoperationexception) 可以使上下文进入不可恢复的状态。 此类异常指示程序错误，并且不旨在从其中恢复。

## 使用“new”的简单的 DbContext 初始化

可以按照常规的 .NET 方式构造 `DbContext` 实例，例如，使用 C# 中的 `new`。 可以通过重写 `OnConfiguring` 方法或通过将选项传递给构造函数来执行配置。 例如：

```csharp
public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
    }
}
```

通过此模式，还可以轻松地通过 `DbContext` 构造函数传递配置（如连接字符串）。 例如：

```csharp
public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;

    public ApplicationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}
```

或者，可以使用 `DbContextOptionsBuilder` 创建 `DbContextOptions` 对象，然后将该对象传递到 `DbContext` 构造函数。 这使得为依赖关系注入配置的 `DbContext` 也能显式构造。 例如，使用上述为 ASP.NET Core 的 Web 应用定义的 `ApplicationDbContext` 时：

```csharp
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
```

可以创建 `DbContextOptions`，并可以显式调用构造函数：

```csharp
var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test")
    .Options;

using var context = new ApplicationDbContext(contextOptions);
```

## DbContextOptions

所有 `DbContext` 配置的起始点都是 [DbContextOptionsBuilder](https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder)。 可以通过三种方式获取此生成器：

- 在 `AddDbContext` 和相关方法中
- 在 `OnConfiguring` 中
- 使用 `new` 显式构造

上述各节显示了其中每个示例。 无论生成器来自何处，都可以应用相同的配置。 此外，无论如何构造上下文，都将始终调用 `OnConfiguring`。 这意味着即使使用 `AddDbContext`，`OnConfiguring` 也可用于执行其他配置。

### `DbContextOptions` 与 `DbContextOptions<TContext>`

大多数接受 `DbContextOptions` 的 `DbContext` 子类应使用 [泛型](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/generics/)`DbContextOptions<TContext>`变体。 例如：

```csharp
public sealed class SealedApplicationDbContext : DbContext
{
    public SealedApplicationDbContext(DbContextOptions<SealedApplicationDbContext> contextOptions)
        : base(contextOptions)
    {
    }
}
```

这可确保从依赖关系注入中解析特定 `DbContext` 子类型的正确选项，即使注册了多个 `DbContext` 子类型也是如此。

> 你的 DbContext 不需要密封，但对于没有被设计为继承的类，密封是最佳做法。

但是，如果 `DbContext` 子类型本身旨在继承，则它应公开采用非泛型 `DbContextOptions` 的受保护构造函数。 例如：

```csharp
public abstract class ApplicationDbContextBase : DbContext
{
    protected ApplicationDbContextBase(DbContextOptions contextOptions)
        : base(contextOptions)
    {
    }
}
```

这允许多个具体子类使用其不同的泛型 `DbContextOptions<TContext>` 实例来调用此基构造函数。 例如：

```csharp
public sealed class ApplicationDbContext1 : ApplicationDbContextBase
{
    public ApplicationDbContext1(DbContextOptions<ApplicationDbContext1> contextOptions)
        : base(contextOptions)
    {
    }
}

public sealed class ApplicationDbContext2 : ApplicationDbContextBase
{
    public ApplicationDbContext2(DbContextOptions<ApplicationDbContext2> contextOptions)
        : base(contextOptions)
    {
    }
}
```

请注意，这与直接从 `DbContext` 继承的模式完全相同。 也就是说，出于此原因，`DbContext` 构造函数本身将接受非泛型 `DbContextOptions`。

旨在同时进行实例化和继承的 `DbContext` 子类应公开构造函数的两种形式。 例如：

```csharp
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
        : base(contextOptions)
    {
    }

    protected ApplicationDbContext(DbContextOptions contextOptions)
        : base(contextOptions)
    {
    }
}
```