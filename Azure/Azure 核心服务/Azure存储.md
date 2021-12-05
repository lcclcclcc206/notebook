## 磁盘存储基础知识

磁盘存储为 Azure 虚拟机提供磁盘。 应用程序和其他服务可根据需要访问和使用这些磁盘，就像在本地场景下一样。 磁盘存储允许通过附加的虚拟硬盘永久地存储和访问数据。

![磁盘存储图标。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-storage-fundamentals/media/icon-azure-standard-storage-083e0065.png)

磁盘有许多不同的大小和性能级别，从固态硬盘 (SSD) 到传统的旋转硬盘驱动器 (HDD)，各自具有不同的性能层。 可以将标准 SSD 和 HDD 磁盘用于关键性更低的工作负载、将高级 SSD 磁盘用于任务关键型生产应用程序，并将超级磁盘用于 SAP HANA、顶层数据库等数据密集型工作负载和事务密集型工作负载。 Azure 为基础结构即服务 (Iaas) 磁盘持续提供企业级持久性，年化故障率为 0%，达到行业领先水平。

下图显示使用单独磁盘来存储不同数据的 Azure 虚拟机。



## Azure Blob 存储基础知识

Azure Blob 存储是适用于云的对象存储解决方案。 它可以存储海量数据，例如文本或二进制数据。 Azure Blob 存储是非结构化的，这意味着它可保存各种类型的数据。 Blob 存储可以管理数千个同步上传、大量视频数据以及不断增长的日志文件，并且你可以通过 Internet 连接从任意位置访问它。

![Blob 存储图标。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-storage-fundamentals/media/icon-azure-blob-storage-055dde79.png)

Blob 并不限于常见的文件格式。 Blob 可能包含从科学仪器流式传输的千兆字节二进制数据、另一个应用程序的加密消息，或者正在开发的应用的自定义格式的数据。 磁盘存储上 blob 存储的一个优点是不需要开发人员考虑或管理磁盘；数据以 blob 的形式上传，Azure 负责解决物理存储需求。

Blob 存储最适合用于：

- 直接向浏览器提供图像或文档。
- 存储文件以供分布式访问。
- 对视频和音频进行流式处理。
- 存储用于备份和还原、灾难恢复及存档的数据。
- 存储数据以供本地或 Azure 托管服务执行分析。
- 为虚拟机存储多达 8 TB 的数据。

Blob 存储在容器中，可以帮助你根据业务需求来组织 blob。

下图演示了如何使用 Azure 帐户、容器和 blob。

![存储帐户的层次结构图。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-storage-fundamentals/media/account-container-blob-4da0ac47.png)



## Azure 文件存储基础知识

Azure 文件存储在云端提供完全托管的文件共享，这些共享可通过行业标准的服务器消息块和网络文件系统（预览）协议进行访问。 Azure 文件共享可由云或者 Windows、Linux 和 macOS 的本地部署同时装载。 在 Azure 虚拟机或云服务中运行的应用程序可以装载文件存储共享以访问文件数据，就像桌面应用程序可以装载典型 SMB 共享一样。 任意数量的 Azure 虚拟机或角色可以同时装载并访问文件存储共享。 其典型的使用场景包括在全球任意位置共享文件、诊断数据或应用程序数据共享。

![Azure 文件存储图标。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-storage-fundamentals/media/icon-azure-files-c53adf24.png)

在以下情况下使用 Azure 文件存储：

- 许多本地应用程序使用文件共享。 借助 Azure 文件存储可以更方便地迁移将数据共享到 Azure 的应用程序。 如果将 Azure 文件共享装载到本地应用程序使用的相同驱动器号，则访问该文件共享的应用程序部分应只需要进行最少的更改（如果有）。
- 将配置文件存储在文件共享上，并从多个 VM 进行访问。 可以将一个组中多个开发人员使用的工具和实用程序存储到文件共享中，确保每个人都能找到它们并使用同一版本。
- 将数据写入文件共享，稍后处理或分析数据。 例如，你可能希望对诊断日志、指标和故障转储执行此操作。

下图显示了用于在两个地理位置之间共享数据的 Azure 文件存储。 Azure 文件存储可确保数据在静止时处于加密状态，SMB 协议可确保数据在传输过程中处于加密状态。

![此图显示了 Azure 文件存储的文件共享功能，具体是在美国西部 Azure 文件共享和欧洲 Azure 文件共享之间进行，它们均有自己的 SMB 用户。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-storage-fundamentals/media/azure-files-5f942c3e.png)

Azure 文件存储与公司文件共享上的文件不同的一点是，你可以使用指向文件的 URL 从世界上的任何地方访问这些文件。 你还可以使用共享访问签名 (SAS) 令牌，允许特定时间段内对专用资产的访问。

下面是服务 SAS URI 的一个示例，其中显示了资源 URI 和 SAS 令牌：

![服务 SAS URI 组件的屏幕截图。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-storage-fundamentals/media/sas-storage-uri-037308fa.png)



## 了解 Blob 访问层

存储在云中的数据以指数速度增长。 要为扩展的存储需求管理成本，根据属性（如访问频率和计划保留期）整理数据将很有帮助。 存储在云中的数据可能根据其生成方式、处理方式以及在生存期内的访问方式而有所不同。 某些数据在其整个生存期中都会受到积极的访问和修改。 某些数据则在生存期早期会受到频繁访问，随着数据变旧，访问会极大地减少。 某些数据在云中保持空闲状态，并且在存储后很少（如果有）被访问。 为了满足这些不同的访问需求，Azure 提供了几个访问层，可以利用它们实现存储成本与访问需求的平衡。

![Azure 存储层图标。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-storage-fundamentals/media/icon-storage-tiers-a0322ad1.png)

Azure 存储为 blob 存储提供不同的访问层，有助于以最经济高效的方式存储对象数据。 可用的访问层包括：

- **热访问层**：针对存储经常访问的数据（例如网站图像）进行了优化。
- **冷访问层**：为不常访问且存储时间至少为 30 天的数据（例如客户发票）进行了优化。
- **存档访问层**：适用于极少访问、存储时间至少为 180 天且延迟要求不严格的数据（例如长期备份）。