完成此模块后，你将能够：

- 介绍 Azure 中可用的核心网络资源。
- 介绍 Azure 虚拟网络、Azure VPN 网关和 Azure ExpressRoute 的优势和使用。



## 什么是 Azure 虚拟网络？

Azure 虚拟网络允许 Azure 资源（例如 VM、Web 应用和数据库）相互通信、与 Internet 上的用户通信，以及与本地客户端计算机通信。 可将 Azure 网络视为一组资源，它们与其他 Azure 资源进行链接。

Azure 虚拟网络提供以下重要的网络功能：

- 隔离和分段
- Internet 通信
- Azure 资源之间的通信
- 与本地资源通信
- 路由网络流量
- 筛选网络流量
- 连接虚拟网络

### 隔离和细分

通过该虚拟网络，可以创建多个隔离的虚拟网络。 设置虚拟网络时，请使用公共或专用 IP 地址范围定义一个专用 Internet 协议 (IP) 地址空间。 可将该 IP 地址空间划分为子网，并将部分已定义的地址空间分配给每个命名的子网。

可以使用 Azure 中内置的名称解析服务进行名称解析。 也可以将虚拟网络配置为使用内部或外部 DNS 服务器。

### Internet 通信

Azure 中的 VM 可以默认连接到 Internet。 可以通过定义公共 IP 地址或公共负载均衡器来启用从 Internet 传入的连接。 若要管理 VM，可通过 Azure CLI、远程桌面协议或安全外壳实现连接。

### Azure 资源之间的通信

需要让 Azure 资源能够安全地进行相互通信。 为此，可使用下列任一方式：

- 虚拟网络：虚拟网络不仅可以连接 VM，还可以连接其他 Azure 资源，如用于 Power Apps 的应用服务环境、Azure Kubernetes 服务和 Azure 虚拟机规模集。
- **服务终结点**：可以使用服务终结点连接到其他 Azure 资源类型，例如 Azure SQL 数据库和存储帐户。 此方法可以将多个 Azure 资源连接到虚拟网络，从而提高安全性并在资源之间提供最佳路由。

### 与本地资源通信

可以通过 Azure 虚拟网络将本地环境中的和 Azure 订阅中的资源链接到一起。 实际上就是可以创建一个横跨本地环境和云环境的网络。 可以通过三种机制实现此连接：

- 点到站点虚拟专用网络：实现虚拟专用网络 (VPN) 连接的典型方法是从组织外部的计算机返回到企业网络。 在这种情况下，客户端计算机会启动加密 VPN 连接，以便将该计算机连接到 Azure 虚拟网络。
- 站点到站点虚拟专用网络：站点到站点 VPN 将本地 VPN 设备或网关链接到虚拟网络中的 Azure VPN 网关。 实际上，Azure 中的设备看起来可能就像在本地网络中一样。 连接经过加密，是通过 Internet 进行的。
- **Azure ExpressRoute**：对于需要更大带宽甚至更高级别安全性的环境，Azure ExpressRoute 是最好的方法。 ExpressRoute 提供到 Azure 的专用连接，该连接不经过 Internet。 （你将在本模块后面的独立单元中了解更多有关 ExpressRoute 的信息。）



## Azure VPN 网关基础知识

VPN 在另一网络内使用加密隧道。 通常，部署 VPN 的目的是，通过不受信任的网络（通常是公共 Internet）将两个或更多个受信任的专用网络相互连接。 通过不受信任的网络传输时会加密流量，用于防止窃听或其他攻击。

### VPN 网关

VPN 网关是一种虚拟网络网关。 Azure VPN 网关实例部署在 Azure 虚拟网络实例中，可实现以下连接：

- 通过站点到站点连接将本地数据中心连接到虚拟网络。
- 通过点到站点连接将各个设备连接虚拟网络。
- 通过网络到网络连接将虚拟网络连接到其他虚拟网络。

![可视化 VPN 与 Azure 的连接。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-networking-fundamentals/media/vpngateway-site-to-site-connection-diagram-0e1e7db2.png)

所有传输的数据在通过 Internet 时都会在一个专用隧道中进行加密。 每个虚拟网络中只能部署一个 VPN 网关，但可使用一个网关连接到多个位置，包括其他虚拟网络或本地数据中心。

部署 VPN 网关时，可以指定 VPN 类型：基于策略或基于路由。 这两种类型的 VPN 的主要区别在于如何指定要加密的流量。 在 Azure 中，两种类型的 VPN 网关都使用预共享密钥作为唯一的身份验证方法。 这两种类型还依赖于版本 1 或版本 2 的 Internet 密钥交换 (IKE) 和 Internet 协议安全性 (IPSec)。 IKE 用于在两个终结点之间建立安全关联（加密协议）。 然后将此关联传递给 IPSec 套件，该套件对封装在 VPN 隧道中的数据包进行加密和解密。

### 基于策略的 VPN

基于策略的 VPN 网关通过静态方式指定应通过每个隧道加密的数据包的 IP 地址。 这种类型的设备根据这些 IP 地址集评估每个数据包，以选择将用于发送该数据包的隧道。

### 基于路由的 VPN

如果定义每个隧道后面的 IP 地址过于麻烦，可以使用基于路由的网关。 通过基于路由的网关，将 IPSec 隧道建模为网络接口或虚拟隧道接口。 IP 路由（静态路由或动态路由协议）决定在发送每个数据包时使用哪一个隧道接口。 基于路由的 VPN 是本地设备的首选连接方法。 它们具有更高的复原能力，能够适应拓扑更改，例如创建的新子网。



## 部署 VPN 网关

VPN 网关资源要求的可视化效果

![VPN 网关资源要求的可视化效果。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-networking-fundamentals/media/resource-requirements-for-vpn-gateway-2518703e.png)



## Azure ExpressRoute 基础知识

使用 ExpressRoute 可通过连接服务提供商所提供的专用连接，将本地网络扩展到 Microsoft 云。 使用 ExpressRoute 可与 Microsoft Azure 和 Microsoft 365 等 Microsoft 云服务建立连接。

可以从任意位置之间的 (IP VPN) 网络、点到点以太网或在场地租用设施上通过连接服务提供商的虚拟交叉连接来建立这种连接。 ExpressRoute 连接不经过公共 Internet。 与通过 Internet 的典型连接相比，ExpressRoute 连接提供更高的可靠性、更快的速度、一致的延迟和更高的安全性。 要了解如何使用 ExpressRoute 将网络连接到 Microsoft，请参阅 ExpressRoute 连接模型。

![显示 Azure ExpressRoute 服务高级概述的可视化效果。](https://docs.microsoft.com/zh-cn/learn/azure-fundamentals/azure-networking-fundamentals/media/azure-expressroute-overview-5520731d.png)

### ExpressRoute 的功能和优势

使用 ExpressRoute 作为 Azure 和本地网络之间的连接服务有几个好处。

- 通过连接服务提供商在本地网络与 Microsoft 云之间建立第 3 层连接。 可以从任意位置之间的 (IPVPN) 网络、点到点以太网，或通过以太网交换经由虚拟交叉连接来建立这种连接。
- 跨地缘政治区域中的所有区域连接到 Microsoft 云服务。
- 通过 ExpressRoute 高级版附加组件从全球连接到所有区域的 Microsoft 服务。
- 通过 BGP 在网络与 Microsoft 之间进行动态路由。
- 在每个对等位置提供内置冗余以提高可靠性。
- 连接运行时间 SLA。
- Skype for Business 的 QoS 支持。

