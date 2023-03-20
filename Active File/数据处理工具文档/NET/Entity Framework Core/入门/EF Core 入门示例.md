在本教程中，将创建一个 .NET Core 控制台应用，该应用使用 Entity Framework Core 对 SQLite 数据库执行数据访问。

## 创建新项目

```dotnetcli
dotnet new console -o EFGetStarted
cd EFGetStarted
```

## 安装 Entity Framework Core

要安装 EF Core，请为要作为目标对象的 EF Core 数据库提供程序安装程序包。 本教程使用 SQLite 的原因是，它可在 .NET Core 支持的所有平台上运行。 有关可用提供程序的列表，请参阅[数据库提供程序](https://learn.microsoft.com/zh-cn/ef/core/providers/)。

```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

## 创建模型

在项目文件夹中，使用以下代码创建 Model.cs

```sql
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public List<Post> Posts { get; } = new();
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

EF Core 还可以从现有数据库对模型进行[反向工程](https://learn.microsoft.com/zh-cn/ef/core/managing-schemas/scaffolding/)。

提示:为清楚起见，有意简化了此应用程序。 [连接字符串](https://learn.microsoft.com/zh-cn/ef/core/miscellaneous/connection-strings)不应存储在生产应用程序的代码中。 可能还需要将每个 C# 类拆分为其自己的文件。

## 创建数据库

以下步骤使用[迁移](https://learn.microsoft.com/zh-cn/ef/core/managing-schemas/migrations/)创建数据库。

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```

这会安装 [dotnet ef](https://learn.microsoft.com/zh-cn/ef/core/cli/dotnet) 和设计包，这是对项目运行命令所必需的。 `migrations` 命令为迁移搭建基架，以便为模型创建一组初始表。 `database update` 命令创建数据库并向其应用新的迁移。

## 创建、读取、更新和删除

打开 Program.cs 并将内容替换为以下代码：

```C#
using System;
using System.Linq;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
db.SaveChanges();
```

## 运行应用

```
dotnet run
```

