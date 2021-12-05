## 了解 Azure Cosmos DB

Azure Cosmos DB 是一种全球分布式多模型数据库服务。 可跨任意数量的全球 Azure 区域弹性且独立地缩放吞吐量和存储。 可通过下面几个常用 API 中的任意一个来利用数据访问，且访问速度快至个位数毫秒级。 Azure Cosmos DB 为吞吐量、延迟、可用性和一致性提供综合服务级别协议。

Azure Cosmos DB 支持无架构数据，可用于生成高度响应的应用程序和“Always On”应用程序，为不断变化的数据提供支持。 此功能可用于存储全球用户更新和维护的数据。

![培训门户网站中的 Azure Cosmos DB 数据库示意图。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-database-fundamentals/media/azure-cosmos-db-1c115364.png)

Azure Cosmos DB 非常灵活。 在最低级别，Azure Cosmos DB 以 atom-record-sequence (ARS) 格式存储数据。 然后对数据进行抽象化，并将其投影为一个在创建数据库时指定的 API。 你的选择包括 SQL、MongoDB、Cassandra、Tables 和 Gremlin。 这一级别的灵活性意味着，当你将公司的数据库迁移到 Azure Cosmos DB 后，你的开发人员可继续使用自己最熟悉的 API。



## 探索 Azure SQL 数据库

Azure SQL 数据库是基于 Microsoft SQL Server 数据库引擎最新稳定版的关系数据库。 SQL 数据库是一种高性能、完全托管、可靠且安全的数据库。 你可用它以所选编程语言生成数据驱动的应用程序和网站，无需管理基础结构。

![图标。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-database-fundamentals/media/icon-service-sql-database-7c2a6248.png)

### 功能

Azure SQL 数据库是一种平台即服务 (PaaS) 数据库引擎。 它可处理大多数数据库管理功能（例如升级、修补、备份和监视），无需用户参与。 SQL 数据库提供 99.99% 的可用性。 通过 SQL 数据库中内置的 PaaS 功能，可专注于对业务至关重要的特定于域的数据库管理和优化活动。 SQL 数据库是完全托管型服务，提供内置的可用性、备份和其他常见维护操作。 Microsoft 可处理针对 SQL 和操作系统代码的所有更新。 你无需管理底层基础结构。

可为 Azure 中的应用程序和解决方案创建高度可用且高性能的数据存储层。 SQL 数据库可成为各种新式云应用程序的正确选择，因为它可让你处理关系数据和非关系结构（例如图形、JSON、空间和 XML）。

可使用高级查询处理功能，例如高性能内存中技术和智能查询处理。 事实上，SQL Server 的最新功能会先发布到 SQL 数据库，然后再发布到 SQL Server 本身。 无需投入任何更新或升级开销，即可获得 SQL Server 的最新功能，这些功能已在数百万个数据库中进行测试。



## 探索 Azure Database for MySQL

Azure Database for MySQL 是云中的关系数据库服务，基于 MySQL 社区版数据库引擎（版本 5.6、5.7 和 8.0）。 通过此服务，Azure 提供 99.99% 的可用性服务级别协议，该协议由 Microsoft 托管数据中心的全球网络提供支持。 这可帮助应用保持全天候运行。 对于每个用于 MySQL 服务器的 Azure 数据库，可以利用内置的安全性、容错和数据保护功能。使用其他产品时可能需要另外购买或设计、构建并管理这些功能。 使用用于 MySQL 的 Azure 数据库，可以使用时间点还原将服务器还原到以前的状态，最多可还原到 35 天前。

![Azure Database for MySQL 示意图。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-database-fundamentals/media/azure-db-for-mysql-conceptual-diagram-02e2a10a.png)

Azure Database for MySQL 提供多个服务层，每个层提供不同的性能和功能，可支持从轻型到重型等各种数据库工作负载。 可以在一个月内花费很少的费用基于小型数据库构建第一个应用，然后根据解决方案的需求调整缩放。 动态可伸缩性使得数据库能够以透明方式对不断变化的资源需求做出响应。 只需在需要资源时为所需的资源付费。



## 探索 Azure Database for PostgreSQL

Azure Database for PostgreSQL 是云中的关系数据库服务。 服务器软件基于开源 PostgreSQL 数据库引擎的社区版本。 使用 Azure Database for PostgreSQL 时，可熟悉 PostgreSQL 的工具和专业知识。



## 探索 Azure SQL 托管实例

Azure SQL 托管实例是一种可缩放的云数据服务，它提供最广泛的 SQL Server 数据库引擎兼容性，并具有完全托管的平台即服务的所有优点。 根据具体的方案，Azure SQL 托管实例可能为你的数据库需求提供更多选项。

![图标。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-database-fundamentals/media/icon-service-managed-sql-instance-417013a9.png)

### 功能

与 Azure SQL 数据库相同，Azure SQL 托管实例是一个平台即服务 (PaaS) 数据库引擎，这意味着公司能够在一个完全托管的环境中充分利用将数据移动到云的最佳功能。 例如，你的公司将不再需要购买和管理昂贵的硬件，也不必维护管理本地基础结构的额外开销。 另一方面，你的公司将受益于 Azure 的快速预配和服务缩放功能，以及自动修补和版本升级。 此外，通过内置的高可用性功能和 99.99% 的运行时间服务级别协议 (SLA)，你能够确保数据在需要时始终可用。 你还可以使用自动备份和可配置的备份保持期来保护数据。

Azure SQL 数据库和 Azure SQL 托管实例提供多种相同的功能；但是，Azure SQL 托管实例提供了多个可能不适用于 Azure SQL 数据库的选项。 例如，Tailwind Traders 目前使用运行 SQL Server 的多个本地服务器，他们希望将现有数据库迁移到在云中运行的 SQL 数据库。 但是，他们的几个数据库使用西里尔字符进行排序。 在这种情况下，Tailwind Traders 应将其数据库迁移到 Azure SQL 托管实例，因为 Azure SQL 数据库仅使用默认的 `SQL_Latin1_General_CP1_CI_AS` 服务器排序规则。

> 有关 Azure SQL 数据库与 Azure SQL 托管实例之间差异的详细列表，请参阅[功能比较：Azure SQL 数据库和 Azure SQL 托管实例](https://docs.microsoft.com/zh-cn/azure/azure-sql/database/features-comparison/)。



## 探索大数据和分析服务

随着时间的推移，人们开发出开源群集技术来尝试处理这些大型数据集。 Microsoft Azure 支持广泛的技术和服务，可提供大数据和分析解决方案，包括 Azure Synapse Analytics、Azure HDInsight、Azure Databricks 和 Azure Data Lake Analytics。

**Azure Synapse Analytics**

[Azure Synapse Analytics](https://docs.microsoft.com/zh-cn/azure/sql-data-warehouse/)（前称为 Azure SQL 数据仓库）是一种无限制的分析服务，它将企业数据仓库和大数据分析相结合。 可通过大规模使用无服务器资源或预配资源根据自己的需求查询数据。 通过统一的体验引入、准备、管理和提供数据，以满足即时 BI 和机器学习需求。

**Azure HDInsight**

[Azure HDInsight](https://azure.microsoft.com/services/hdinsight/) 是面向企业的完全托管的开放源代码分析服务。 它是一种云服务，可让你更轻松、更快、更经济高效地处理大量数据。 你可运行常用开源框架并创建多种群集类型，例如 [Apache Spark](https://docs.microsoft.com/zh-cn/azure/hdinsight/spark/apache-spark-overview)、[Apache Hadoop](https://docs.microsoft.com/zh-cn/azure/hdinsight/hadoop/apache-hadoop-introduction)、[Apache Kafka](https://docs.microsoft.com/zh-cn/azure/hdinsight/kafka/apache-kafka-introduction)、[Apache HBase](https://docs.microsoft.com/zh-cn/azure/hdinsight/hbase/apache-hbase-overview)、[Apache Storm](https://docs.microsoft.com/zh-cn/azure/hdinsight/storm/apache-storm-overview) 和[机器学习服务](https://docs.microsoft.com/zh-cn/azure/hdinsight/r-server/r-server-overview)。 HDInsight 还支持多种方案，例如提取、转换和加载 (ETL)、数据仓库、机器学习和 IoT。

**Azure Databricks**

[Azure Databricks](https://azure.microsoft.com/services/databricks/) 可帮助你从所有数据中获取见解，并能够生成人工智能解决方案。 只需几分钟即可设置好 Apache Spark 环境，然后在交互式工作区中对共享项目进行自动缩放和协作。 Azure Databricks 支持 Python、Scala、R、Java 和 SQL 以及数据科学框架和库（包括 TensorFlow、PyTorch 和 scikit-learn）。

**Azure Data Lake Analytics**

[Azure Data Lake Analytics](https://azure.microsoft.com/services/data-lake-analytics/) 是一项按需分析作业服务，用于简化大数据。 无需部署、配置和调整硬件，只需编写查询即可转换数据并提取有价值的见解。 通过将表盘设置为所需值，该分析服务就可以立即处理任何规模的作业。 你只需为运行的作业付费，这让作业变得更为经济高效。