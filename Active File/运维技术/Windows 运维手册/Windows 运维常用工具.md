## Windows 管理

| 工具名                           | 应用名                   | 备注                                                      |
| -------------------------------- | ------------------------ | --------------------------------------------------------- |
| 本地安全策略                     | secpol.msc               | 查看和修改本地安全策略，如用户权限和审核策略。            |
| 本地组策略编辑器                 | gpedit.msc               |                                                           |
| 服务                             | **services.msc**         | 启动、终止并设置 Windows 服务。                           |
| 高级安全 Windows Defender 防火墙 | **WF.msc**               | 配置为 Windows 计算机提供增强网络安全的策略。             |
| 计算机管理                       | **compmgmt.msc**         | 管理磁盘以及使用其他系统工具来管理本地或远程计算机。      |
| 任务计划程序                     | taskschd.msc             | 安排自动运行的计算机任务。                                |
| 系统配置                         | **msconfig.exe**         | 执行高级疑难解答和系统配置                                |
| 系统信息                         | msinfo32.exe             | 显示关于计算机的详细信息。                                |
| 注册表编辑器                     | regedit.exe              | 注册表编辑器                                              |
| 资源监视器                       | perfmon.exe              | 实时监视以下资源的使用情况和性能: CPU、磁盘、网络和内存。 |
| 任务管理器                       | taskmgr.exe              | 管理运行的应用并查看系统性能                              |
| Windows 功能                     | **OptionalFeatures.exe** |                                                           |
| Windows 管理控制台               | mmc.exe                  |                                                           |
| 事件管理器                       | eventvwr.exe             |                                                           |
| 本地用户和组                     | lusrmgr.msc              |                                                           |

## Windows 工具

| 工具名           | 应用名                           | 备注                                                         |
| ---------------- | -------------------------------- | ------------------------------------------------------------ |
| 步骤记录器       | psr.exe                          | 捕获要保存或共享的步骤，带屏幕截图。                         |
| 远程桌面连接     | **mstsc.exe**                    | 使用你的计算机连接至位于其他位置的计算机并运行程序或访问文件。 |
| 允许远程桌面连接 | **SystemPropertiesRemote.exe**   |                                                              |
| 系统高级属性     | **SystemPropertiesAdvanced.exe** | 设置环境变量                                                 |
| 字符映射表       | charmap.exe                      | 选择特殊字符并且复制到文档中。                               |
| 截图工具         | **snippingtool.exe**             |                                                              |

## Windows 控制台

[List of Commands to Open Control Panel Items in Windows 10 | Tutorials (tenforums.com)](https://www.tenforums.com/tutorials/86339-list-commands-open-control-panel-items-windows-10-a.html)

control 命令是控制『控制台』的一个接口。

| 命令参数                   | 平台                | 说明                                        |
| -------------------------- | ------------------- | ------------------------------------------- |
| control admintools         | 2000/XP             | 开启『系统管理工具』窗口。                  |
| control desktop            | 95/98/ME/NT/2000/XP | 开启『显示 内容』窗口。                     |
| control color              | 95/98/ME/NT/2000/XP | 开启『显示 内容』窗口，并显示『外观』项目。 |
| **control date/time**      | 95/98/ME/NT/2000/XP | 开启『时间和日期 内容』窗口。               |
| **control folders**        | XP                  | 开启『数据夹选项』窗口。                    |
| control fonts              | 95/98/ME/NT/2000/XP | 开启『字型』窗口。                          |
| control infrared           | 95/98/ME/NT/2000/XP | 开启『无线连结』窗口。                      |
| control international      | 95/98/ME/NT/2000/XP | 开启『地区及语言选项』窗口。                |
| control keyboard           | 95/98/ME/NT/2000/XP | 开启『键盘 内容』窗口。                     |
| control mouse              | 95/98/ME/NT/2000/XP | 开启『鼠标 内容』窗口。                     |
| **control netconnections** | 2000/XP             | 开启『网络联机』窗口。                      |
| control netware            | 2000/XP             | 开启『Netware』窗口。                       |
| control panel              | 2000/XP             | 开启『控制台』窗口。                        |
| **control printers**       | 95/98/ME/NT/2000/XP | 开启『打印机和传真』窗口。                  |
| control schedtasks         | 2000/XP             | 开启『排定的工作』窗口。                    |
| control telephony          | 2000/XP             | 开启『位置信息』窗口。                      |
| control userpasswords      | 2000/XP             | 开启『使用者账户』窗口。                    |
| **control userpasswords2** | 2000/XP             | 开启另一种『使用者账户』窗口。              |

此外，有一种扩展名为.cpl的档案。其实他就是各种在控制台内的工具。所以你可以透过 sysdm.cpl 将打开系统属性小程序。

control *xxx.cpl*

这样的方式来开启该画面。

Access.cpl:辅助功能选项

**Appwiz.cpl**:添加/删除程序

Desk.cpl:显示

Fax.cpl:传真向导

Hdwwiz.cpl:添加/删除硬件

Intl.cpl:区域语言选项

Joy.cpl:游戏控制器

Liccpa.cpl:许可

Main.cpl:鼠标

Mlcfg.cpl:邮件

**Mmsys.cpl**:声音和音频设备

Modem.cpl:电话和调制解调器选项

Ncpa.cpl:网络连接

Netcpl.cpl:网络和拨号连接

Nwc.cpl: Netware客户端连接

Odbccp32.cpl: ODBC数据源

**Powercfg.cpl**:电源管理

Sticpl.cpl:扫描仪和照相机

**Sysdm.cpl**:系统

Telephon.cpl:拨号规则和调制解调器

Timedate.cpl:日期和时间