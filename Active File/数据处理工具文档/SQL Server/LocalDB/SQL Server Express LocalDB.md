[SQL Server Express LocalDB - SQL Server | Microsoft Learn](https://learn.microsoft.com/zh-cn/sql/database-engine/configure-windows/sql-server-express-localdb)

Microsoft SQL Server Express LocalDB 是一种面向开发人员的 [SQL Server Express](https://learn.microsoft.com/zh-cn/sql/sql-server/editions-and-components-of-sql-server-2019?view=sql-server-ver16) 功能。 它在具有高级服务的 SQL Server Express 上可用。

LocalDB 安装将复制启动 SQL Server 数据库引擎 所需的最少的文件集。 安装 LocalDB 后，你可以使用特定连接字符串来启动连接。 连接时，将自动创建并启动所需的 SQL Server 基础结构，从而使应用程序无需执行复杂的配置任务即可使用数据库。 开发人员工具可以向开发人员提供 SQL Server 数据库引擎 ，使其不必管理 SQL Server 的完整服务器实例即可撰写和测试 Transact-SQL 代码。

## 安装媒体

LocalDB 是在 SQL Server Express 安装过程中选择的功能，可以在下载安装介质后使用。 如果下载介质，则选择 **“Express Advanced”** 或 **“LocalDB”** 包。

- [SQL Server Express 2019](https://go.microsoft.com/fwlink/?LinkID=866658)
- [SQL Server Express 2017](https://go.microsoft.com/fwlink/?LinkID=853017)
- [SQL Server Express 2016](https://go.microsoft.com/fwlink/?LinkID=799012)

LocalDB 安装程序 — `SqlLocalDB.msi` — 在安装介质中可供所有版本（Express Core 除外）使用。 它位于 `<installation_media_root>\<LCID>_ENU_LP\x64\Setup\x64` 文件夹中。 LCID 是区域设置标识符或语言代码。 例如，LCID 值 1033 表示 en-US 区域设置。

LocalDB 也可以通过 [Visual Studio 安装程序](https://visualstudio.microsoft.com/downloads/)、“数据存储和处理”工作负荷和“ASP.NET 和 Web 开发”工作负荷安装，或作为单独组件安装。

## 安装 LocalDB

通过安装向导或使用 `SqlLocalDB.msi` 程序安装 LocalDB。 LocalDB 是安装 SQL Server Express LocalDB 时的一个选项。

在安装过程中，在“功能选择/共享功能”页上选择 LocalDB。 对于每个主要 SQL Server 数据库引擎 版本，只能存在一个 LocalDB 二进制文件的安装。 可以启动多个 数据库引擎 进程，并且这些进程都将使用相同的二进制文件。 作为 LocalDB 启动的 SQL Server 数据库引擎 实例与 SQL Server Express 具有相同限制。

SQL Server Express LocalDB 的实例通过 `SqlLocalDB.exe` 实用工具进行托管。 SQL Server Express LocalDB 应该用于代替已弃用的 SQL Server Express 用户实例功能。

##  说明

LocalDB 安装程序使用 `SqlLocalDB.msi` 程序在计算机上安装所需文件。 安装后，LocalDB 是可以创建和打开 SQL Server 数据库的 SQL Server Express 的实例。 数据库的系统数据库文件存储于本地 AppData 路径中，这个路径通常是隐藏的。 例如，`C:\Users\<user>\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\LocalDBApp1\`。 用户数据库文件存储在用户指定的位置，通常为 `C:\Users\<user>\Documents\` 文件夹中的某个位置。

有关将 LocalDB 包括在应用程序中的详细信息，请参阅 Visual Studio [本地数据概述](https://learn.microsoft.com/zh-cn/previous-versions/visualstudio/visual-studio-2012/ms233817(v=vs.110))和[在 Visual Studio 中创建一个数据库并添加表](https://learn.microsoft.com/zh-cn/visualstudio/data-tools/create-a-sql-database-by-using-a-designer)。

有关 LocalDB API 的详细信息，请参阅 [SQL Server Express LocalDB 参考](https://learn.microsoft.com/zh-cn/sql/relational-databases/sql-server-express-localdb-reference?view=sql-server-ver16)。

`SqlLocalDB` 实用工具可以创建 LocalDB 的新实例，启动和停止 LocalDB 的实例，并且包含可帮助你管理 LocalDB 的选项。 如需详细了解 `SqlLocalDB` 实用工具，请参阅 [SqlLocalDB 实用工具](https://learn.microsoft.com/zh-cn/sql/tools/sqllocaldb-utility?view=sql-server-ver16)。

将 LocalDB 的实例排序规则设置为 `SQL_Latin1_General_CP1_CI_AS`，并且不能更改。 一般支持数据库级、列级和表达式级排序规则。 包含的数据库遵循[包含数据库的排序规则](https://learn.microsoft.com/zh-cn/sql/relational-databases/databases/contained-database-collations?view=sql-server-ver16)所定义的元数据和 `tempdb` 排序规则。

## 限制

- LocalDB 不能通过 SQL Management Studio 远程管理。
- LocalDB 不能是合并复制订阅服务器。
- LocalDB 不支持 FILESTREAM。
- LocalDB 仅允许 Service Broker 的本地队列。
- 由于 Windows 文件系统重定向，`NT AUTHORITY\SYSTEM` 等内置帐户拥有的 LocalDB 的一个实例可能具有管理性问题。 请改用常规 Windows 帐户作为所有者。

## 自动实例和命名实例

LocalDB 支持两种类型的实例：自动实例和命名实例。

- LocalDB 的自动实例是公共的。 系统自动为用户创建和管理此类实例，并可由任何应用程序使用。 安装在用户计算机上的每个 LocalDB 版本都存在一个自动 LocalDB 实例。 自动 LocalDB 实例提供无缝的实例管理。 无需创建实例；它可以自动执行工作。 此功能使得应用程序可以轻松地安装和迁移到另一台计算机。 如果目标计算机已安装指定版本的 LocalDB，则目标计算机也提供此版本的自动 LocalDB 实例。 自动 LocalDB 实例具有属于保留命名空间的特殊实例名称模式。 自动实例可以防止名称与 LocalDB 的命名实例发生冲突。 自动实例的名称为 **MSSQLLocalDB**。
- LocalDB 的命名实例是专用的。 这些命名实例由负责创建和管理该实例的单个应用程序所拥有。 命名实例提供与其他实例的隔离，并可以通过减少与其他数据库用户的资源争用来提高性能。 命名实例必须由用户通过 LocalDB 管理 API 显式创建，或者通过托管应用程序的 app.config 文件隐式创建（尽管托管应用程序也会在需要时使用 API）。 LocalDB 的每个命名实例都具有关联的 LocalDB 版本，指向相应的 LocalDB 二进制文件集。 LocalDB 的命名实例为 sysname 数据类型并且可具有最多 128 个字符。 （这不同于常规的 SQL Server 命名实例，此类命名实例将名称限制为 16 个 ASCII 字符的常规 NetBIOS 名称。）LocalDB 实例名称可包含任何在文件名内合法的 Unicode 字符。使用自动实例名称的命名实例将成为自动实例。

不同的计算机用户可具有同名的实例。 每个实例都是以不同的用户身份运行的不同的进程。

## 启动 LocalDB 并连接到 LocalDB

### 连接到自动实例

使用 LocalDB 的最简单方法是通过使用连接字符串 `Server=(localdb)\MSSQLLocalDB;Integrated Security=true` 连接到当前用户拥有的自动实例。 若要通过使用文件名连接到特定数据库，请使用类似于 `Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=D:\Data\MyDB1.mdf` 的连接字符串进行连接。

### 创建并连接到命名实例

除了自动实例之外，LocalDB 还支持命名实例。 使用 SqlLocalDB.exe 程序可以创建、启动和停止 LocalDB 的命名实例。 有关 SqlLocalDB.exe 的详细信息，请参阅 [SqlLocalDB 实用工具](https://learn.microsoft.com/zh-cn/sql/tools/sqllocaldb-utility?view=sql-server-ver16)。