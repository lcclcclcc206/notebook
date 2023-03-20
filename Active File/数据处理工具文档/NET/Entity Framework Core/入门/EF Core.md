# Entity Framework Core

Entity Framework (EF) Core 是轻量化、可扩展、[开源](https://github.com/dotnet/efcore)和跨平台版的常用 Entity Framework 数据访问技术。

EF Core 可用作对象关系映射程序 (O/RM)，这可以实现以下两点：

- 使 .NET 开发人员能够使用 .NET 对象处理数据库。
- 无需再像通常那样编写大部分数据访问代码。

EF Core 支持多个数据库引擎，请参阅[数据库提供程序](https://learn.microsoft.com/zh-cn/ef/core/providers/)了解详细信息。

## 模型

对于 EF Core，使用模型执行数据访问。 模型由实体类和表示数据库会话的上下文对象构成。 上下文对象允许查询并保存数据。 有关详细信息，请参阅[创建模型](https://learn.microsoft.com/zh-cn/ef/core/modeling/)。

EF 支持以下模型开发方法：

- 从现有数据库生成模型。
- 对模型手动编码，使其符合数据库。
- 创建模型后，使用 [EF 迁移](https://learn.microsoft.com/zh-cn/ef/core/managing-schemas/migrations/)从模型创建数据库。 模型发生变化时，迁移可让数据库不断演进。

```csharp
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Intro;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
    }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public int Rating { get; set; }
    public List<Post> Posts { get; set; }
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}
```

## 查询

使用[语言集成查询 (LINQ)](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/linq/) 从数据库检索实体类的实例。 有关详细信息，请参阅[查询数据](https://learn.microsoft.com/zh-cn/ef/core/querying/)。

```csharp
using (var db = new BloggingContext())
{
    var blogs = db.Blogs
        .Where(b => b.Rating > 3)
        .OrderBy(b => b.Url)
        .ToList();
}
```

## 保存数据

使用实体类的实例在数据库中创建、删除和修改数据。 有关详细信息，请参阅[保存数据](https://learn.microsoft.com/zh-cn/ef/core/saving/)。

```csharp
using (var db = new BloggingContext())
{
    var blog = new Blog { Url = "http://sample.com" };
    db.Blogs.Add(blog);
    db.SaveChanges();
}
```

## EF O/RM 注意事项

虽然 EF Core 善长提取许多编程详细信息，但还是有一些适用于任何 O/RM 的最佳做法，可帮助避免生产应用中的常见陷阱：

- 若要在高性能生产应用中构建、调试、分析和迁移数据，必须具备基础数据库服务器的中级知识或更高级别的知识。 例如，有关主键和外键、约束、索引、标准化、DML 和 DDL 语句、数据类型、分析等方面的知识。
- 功能和集成测试：请务必尽可能严密地复制生产环境，以便：
  - 查找仅在使用特定版本的数据库服务器时应用才出现的问题。
  - 在升级 EF Core 和其他依赖项时捕获中断性变更。 例如，添加或升级 ASP.NET Core、OData 或 AutoMapper 等框架。 这些依赖项可能以多种意外方式影响 EF Core。
- 通过代表性负载进行性能和压力测试。 某些功能的不成熟用法缩放性不佳。 例如，多项集合包含内容、大量使用延迟加载、对未编制索引的列执行条件查询、对存储生成的值进行大规模更新和插入、缺乏并发处理、大型模型、缓存策略不充分。
- 安全评审：例如，连接字符串和其他机密处理、非部署操作的数据库权限、原始 SQL 的输入验证、敏感数据加密。
- 确保日志记录和诊断充足且可用。 例如，适当的日志记录配置、查询标记和 Application Insights。
- 错误恢复。 为常见故障场景（如版本回退、回退服务器、横向扩展和负载平衡、DoS 缓解和数据备份）准备应急计划。
- 应用程序部署和迁移。 规划如何在部署过程中应用迁移；在应用程序启动时执行此操作可能会导致并发问题，并且对于常规操作，这所需的权限比必要权限更高。 在迁移期间，使用暂存来辅助从错误中恢复。 有关详细信息，请参阅[应用迁移](https://learn.microsoft.com/zh-cn/ef/core/managing-schemas/migrations/applying)。
- 生成的迁移的详细检查和测试。 将迁移应用于生产数据前，应对其进行全面测试。 若表中包含生产数据，架构的形状和列类型就不能轻易更改。 例如，在 SQL Server 上，对于映射到字符串和十进制属性的列，`nvarchar(max)` 和 `decimal(18, 2)` 极少成为最佳类型，但这些是 EF 使用的默认值，因为 EF 不了解你的具体情况。