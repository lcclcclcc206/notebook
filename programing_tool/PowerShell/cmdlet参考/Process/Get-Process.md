[Get-Process (Microsoft.PowerShell.Management) - PowerShell | Microsoft Docs](https://docs.microsoft.com/zh-cn/powershell/module/microsoft.powershell.management/get-process?view=powershell-7.1)

获取在本地计算机上运行的进程。



## 语法

```powershell
Get-Process
   [[-Name] <String[]>]
   [-Module]
   [-FileVersionInfo]
   [<CommonParameters>]
```

```powershell
Get-Process
   [[-Name] <String[]>]
   -IncludeUserName
   [<CommonParameters>]
```

```powershell
Get-Process
   -Id <Int32[]>
   [-Module]
   [-FileVersionInfo]
   [<CommonParameters>]
```

```powershell
Get-Process
   -Id <Int32[]>
   -IncludeUserName
   [<CommonParameters>]
```

```powershell
Get-Process
   -InputObject <Process[]>
   [-Module]
   [-FileVersionInfo]
   [<CommonParameters>]
```

```powershell
Get-Process
   -InputObject <Process[]>
   -IncludeUserName
   [<CommonParameters>]
```



## 说明

`Get-Process` cmdlet 获取本地或远程计算机上的进程。

如果没有参数，这个 cmdlet 将获取本地计算机上的所有进程。您还可以通过进程名称或进程 ID (PID)指定特定的进程，或者通过管道将进程对象传递给这个 cmdlet。

默认情况下，此 cmdlet 返回一个具有流程详细信息的流程对象，并支持允许您启动和停止流程的方法。您还可以使用 `Get-Process` cmdlet 的参数来获取在进程中运行的程序的文件版本信息，并获取进程加载的模块。



## 例子



### 示例1: 获取本地计算机上所有活动进程的列表

```powershell
Get-Process
```

此命令获取本地计算机上运行的所有活动进程的列表。有关每列的定义，请参阅 **注释** 部分。



### 示例2: 获取一个或多个进程的所有可用数据

```powershell
Get-Process winword, explorer | Format-List *
```

此命令获取计算机上 Winword 和 Explorer 进程的所有可用数据。它使用 Name 参数指定进程，但省略了可选参数名。管道运算符 `|` 将数据传递给 `Format-List` cmdlet，它显示 Winword 和 Explorer 进程对象的所有可用属性 * 。



### 示例3: 获取工作集大于指定大小的所有进程

```powershell
Get-Process | Where-Object {$_.WorkingSet -gt 20000000}
```

此命令获取工作集大于20mb 的所有进程。它使用 `Get-Process` cmdlet 获取所有正在运行的进程。管道运算符 `|` 将流程对象传递给 `Where-Object` cmdlet，后者只选择值大于20,000,000字节的对象作为 **WorkingSet** 属性。

`WorkingSet` 是进程对象的许多属性之一。要查看所有属性，键入 `Get-Process | Get-Member`。默认情况下，所有属性的值以字节为单位，尽管默认显示以千字节和兆字节为单位列出它们。



### 示例4: 根据优先级将计算机上的进程按组列出

```powershell
$A = Get-Process
$A | Get-Process | Format-Table -View priority
```



### 示例5: 向标准的 Get-Process 输出显示添加一个属性

```powershell
Get-Process pwsh | Format-Table `
    @{Label = "NPM(K)"; Expression = {[int]($_.NPM / 1024)}},
    @{Label = "PM(K)"; Expression = {[int]($_.PM / 1024)}},
    @{Label = "WS(K)"; Expression = {[int]($_.WS / 1024)}},
    @{Label = "VM(M)"; Expression = {[int]($_.VM / 1MB)}},
    @{Label = "CPU(s)"; Expression = {if ($_.CPU) {$_.CPU.ToString("N")}}},
    Id, MachineName, ProcessName -AutoSize

NPM(K) PM(K) WS(K) VM(M) CPU(s)   Id MachineName ProcessName
------ ----- ----- ----- ------   -- ----------- -----------
     6 23500 31340   142 1.70   1980 .           pwsh
     6 23500 31348   142 2.75   4016 .           pwsh
    27 54572 54520   576 5.52   4428 .           pwsh
```



### 示例6: 获取进程的版本信息

```powershell
Get-Process pwsh -FileVersionInfo

ProductVersion   FileVersion      FileName
--------------   -----------      --------
6.1.2            6.1.2            C:\Program Files\PowerShell\6\pwsh.exe
```

该命令使用 `FileVersionInfo ` 参数获取 pwsh.exe 文件的版本信息，该文件是 PowerShell 进程的主要模块。

若要使用在 Windows Vista 和更高版本的 Windows 上没有的进程运行此命令，必须使用“以管理员身份运行”选项打开 PowerShell。



### 示例7: 通过指定的进程获得已加载的模块

```powershell
Get-Process SQL* -Module
```

此命令使用 **Module** 参数获取进程已加载的模块。该命令获取名称以 SQL 开头的进程的模块。

若要在 Windows Vista 和其他版本的 Windows 上运行此命令，其中包含您不拥有的进程，则必须使用“以管理员身份运行”选项启动 PowerShell。



### 示例8: 查找进程的所有者

```powershell
Get-Process pwsh -IncludeUserName

Handles      WS(K)   CPU(s)     Id UserName            ProcessName
-------      -----   ------     -- --------            -----------
    782     132080     2.08   2188 DOMAIN01\user01     pwsh
```

此命令演示如何查找进程的所有者。在 Windows 上，**IncludeUserName** 参数要求提高用户权限(以管理员身份运行)。输出显示所有者是 DOMAIN01\user01。



### 示例9: 使用自动变量标识托管当前会话的进程

```powershell
Get-Process pwsh

NPM(K)    PM(M)      WS(M)     CPU(s)      Id  SI ProcessName
------    -----      -----     ------      --  -- -----------
    83    96.21     105.95       4.33    1192  10 pwsh
    79    83.81     117.61       2.16   10580  10 pwsh

Get-Process -Id $PID

NPM(K)    PM(M)      WS(M)     CPU(s)      Id  SI ProcessName
------    -----      -----     ------      --  -- -----------
    83    96.21      77.53       4.39    1192  10 pwsh
```

这些命令展示了如何使用 `$PID` 自动变量来识别托管当前 PowerShell 会话的进程。可以使用此方法将主机进程与可能希望停止或关闭的其他 PowerShell 进程区分开来。



### 示例10: 获取所有具有主窗口标题的进程，并在表中显示它们

```powershell
Get-Process | Where-Object {$_.mainWindowTitle} | Format-Table Id, Name, mainWindowtitle -AutoSize
```

该命令获取具有主窗口标题的所有进程，并将它们显示在具有进程 ID 和进程名称的表中。

**mainWindowTitle** 属性只是 `Get-Process` 返回的 Process 对象的许多有用属性之一。若要查看所有属性，请将 `Get-Process` 命令的结果通过管道传递到 `Get-Member ` cmdlet。



## 注释

- 您还可以通过其内置的别名，ps 和 gps 来引用这个 cmdlet。[about_Aliases 关于别名](https://docs.microsoft.com/zh-cn/powershell/module/microsoft.powershell.core/about/about_aliases?view=powershell-7.1)。
- 在运行64位 Windows 版本的计算机上，64位版本的 PowerShell 只能获得64位进程模块，32位版本的 PowerShell 只能获得32位进程模块。
- 进程的默认显示是包含以下列的属性。有关进程对象的所有属性的说明，请参见 [Process Properties 进程属性](https://docs.microsoft.com/zh-cn/dotnet/api/system.diagnostics.process)。
  - Handles: 进程已打开的句柄数
  - NPM (k): 进程正在使用的非分页内存量（non-paged memory），单位为千字节
  - PM (k): 进程正在使用的可分页内存量（pageable memory），单位为千字节
  - WS (k): 进程工作集（working set）的大小，单位为千字节。工作集由进程最近引用的内存页组成
  - VM (m): 进程使用的虚拟内存量（virtual memory），以兆字节为单位。虚拟内存包括存储在磁盘上的分页文件中
  - CPU (s): 进程在所有处理器（Central Processing Unit）上使用的处理器时间量，以秒为单位
  - ID: 进程的 ID (PID-process ID)
  - ProcessName: 进程的名称。有关进程相关概念的解释，请参阅帮助和支持中心的术语表和任务管理器的帮助
- 您还可以使用 `Format-Table` 提供进程的内置备选视图，如 **StartTime** 和 **Priority** ，并且您可以设计自己的视图。

