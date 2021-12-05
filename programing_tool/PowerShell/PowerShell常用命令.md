**注销当前会话**

logoff.exe

shutdown.exe -l

**重启和关闭**

Stop-Computer

Restart-Computer -Force

**获取桌面设置**

Get-CimInstance -ClassName Win32_Desktop

**列出 BIOS 信息**

Get-CimInstance -ClassName Win32_BIOS

**列出处理器信息**

Get-CimInstance -ClassName Win32_Processor | Select-Object -ExcludeProperty "CIM*"

对于该处理器系列的常规描述字符串

Get-CimInstance -ClassName Win32_ComputerSystem | Select-Object -Property SystemType

**列出计算机制造商和型号**

Get-CimInstance -ClassName Win32_ComputerSystem

**列出操作系统版本信息**

`Get-CimInstance -ClassName Win32_OperatingSystem | Select-Object -Property Build*,OSType,ServicePack*`

**列出本地用户和所有者**

`Get-CimInstance -ClassName Win32_OperatingSystem | Select-Object -Property *user*`

**获取可用磁盘空间**

Get-CimInstance -ClassName Win32_LogicalDisk -Filter "DriveType=3"

Get-CimInstance -ClassName Win32_LogicalDisk -Filter "DriveType=3" |
  Measure-Object -Property FreeSpace,Size -Sum |
    Select-Object -Property Property,Sum

**获取登录会话信息**

Get-CimInstance -ClassName Win32_LogonSession

**获取登录到计算机的用户**

Get-CimInstance -ClassName Win32_ComputerSystem -Property UserName

**获取计算机的本地时间**

Get-CimInstance -ClassName Win32_LocalTime