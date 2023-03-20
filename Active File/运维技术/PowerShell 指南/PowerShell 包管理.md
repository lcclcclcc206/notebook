[PackageManagement Module - PowerShell | Microsoft Learn](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/?view=powershell-7)

[关于 PSModulePath - PowerShell | Microsoft Learn](https://learn.microsoft.com/zh-cn/powershell/module/microsoft.powershell.core/about/about_psmodulepath?view=powershell-7.2)

PowerShell 中进行包管理的模块为 PackageManagement

| 命令                                                         | 描述                                                         |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [Find-Package](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/find-package?view=powershell-7) | Finds software packages in available package sources.        |
| [Find-PackageProvider](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/find-packageprovider?view=powershell-7) | Returns a list of Package Management package providers available for installation. |
| [Get-Package](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/get-package?view=powershell-7) | Returns a list of all software packages that were installed with **PackageManagement**. |
| [Get-PackageProvider](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/get-packageprovider?view=powershell-7) | Returns a list of package providers that are connected to Package Management. |
| [Get-PackageSource](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/get-packagesource?view=powershell-7) | Gets a list of package sources that are registered for a package provider. |
| [Import-PackageProvider](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/import-packageprovider?view=powershell-7) | Adds Package Management package providers to the current session. |
| [Install-Package](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/install-package?view=powershell-7) | Installs one or more software packages.                      |
| [Install-PackageProvider](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/install-packageprovider?view=powershell-7) | Installs one or more Package Management package providers.   |
| [Register-PackageSource](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/register-packagesource?view=powershell-7) | Adds a package source for a specified package provider.      |
| [Save-Package](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/save-package?view=powershell-7) | Saves packages to the local computer without installing them. |
| [Set-PackageSource](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/set-packagesource?view=powershell-7) | Replaces a package source for a specified package provider.  |
| [Uninstall-Package](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/uninstall-package?view=powershell-7) | Uninstalls one or more software packages.                    |
| [Unregister-PackageSource](https://learn.microsoft.com/zh-cn/powershell/module/packagemanagement/unregister-packagesource?view=powershell-7) | Removes a registered package source.                         |

## 包提供程序

使用 Get-PackageProvider 可以获取 Powershell 连接的包管理程序

```
Desktop> Get-PackageProvider

Name                     Version          DynamicOptions
----                     -------          --------------
NuGet                    3.0.0.1          Destination, Exc…
PowerShellGet            2.2.5.0          PackageManagemen…
```

查看一下这些包管理提供程序的源地址是什么：

```
Desktop> Get-PackageSource

Name                             ProviderName     IsTrusted  Location
----                             ------------     ---------  --------
nuget.org                        NuGet            False      https://api.nuget.org/v3/index.json
PSGallery                        PowerShellGet    True       https://www.powershellgallery.com/api/v2
```

使用 Find-PackageProvider 来查看可用的包提供程序

```
Desktop> Find-PackageProvider

Name                           Version          Source           Summary
----                           -------          ------           -------
PowerShellGet                  2.2.5            PSGallery        PowerShell module with commands fo…
ChocolateyGet                  4.0.0            PSGallery        Package Management (OneGet) provid…
WinGet                         0.0.8            PSGallery        Package Management (OneGet) provid…
ContainerImage                 0.6.4.0          PSGallery        This is a PackageManagement provid…
NanoServerPackage              1.0.1.0          PSGallery        A PackageManagement provider to  D…
Chocolatier                    1.2.0            PSGallery        Package Management (OneGet) provid…
DotNetGlobalToolProvider       0.0.7            PSGallery        OneGet package provider for dotnet…
Homebrew                       0.0.1            PSGallery        Package Management (OneGet) provid…
```

如果要安装包提供程序的话，使用 Install-PackageProvider

```
Install-PackageProvider -Name winget
```

## 软件包的安装、查找、卸载等等

使用 Get-Package 获取随 **PackageManagement** 一起安装的所有软件包的列表。

```
Desktop> Get-Package

Name                           Version          Source                           ProviderName
----                           -------          ------                           ------------
Az                             7.4.0            https://www.powershellgallery.c… PowerShellGet
Az.Accounts                    2.7.5            https://www.powershellgallery.c… PowerShellGet
......
PSReadLine                     2.2.5            https://www.powershellgallery.c… PowerShellGet
VSSetup                        2.2.16           https://www.powershellgallery.c… PowerShellGet
WinGet                         0.0.8            https://www.powershellgallery.c… PowerShellGet
```

使用 Find-Package 查找软件包

```
# 此命令查找已注册库中所有可用的 PowerShell 模块包。 用于 Get-PackageProvider 获取提供程序名称。
Find-Package -ProviderName NuGet

Name               Version   Source     Summary
----               -------   ------     -------
NUnit              3.11.0    MyNuGet    NUnit is a unit-testing framework for all .NET langua...
Newtonsoft.Json    12.0.1    MyNuGet    Json.NET is a popular high-performance JSON framework...
EntityFramework    6.2.0     MyNuGet    Entity Framework is Microsoft's recommended data acce...
MySql.Data         8.0.15    MyNuGet    MySql.Data.MySqlClient .Net Core Class Library
bootstrap          4.3.1     MyNuGet    Bootstrap framework in CSS. Includes fonts and JavaSc...
NuGet.Core         2.14.0    MyNuGet    NuGet.Core is the core framework assembly for NuGet...

# 此命令从指定的包源中查找包的最新版本。 如果未提供包源， Find-Package 请搜索每个已安装的包提供程序及其包源。 用于 Get-PackageSource 获取源名称。
Find-Package -Name NuGet.Core -Source MyNuGet

Name         Version   Source    Summary
----         -------   ------    -------
NuGet.Core   2.14.0    MyNuGet   NuGet.Core is the core framework assembly for NuGet...
```

使用 Install-Package 安装软件包

```
# 按包名称安装包
PS> Install-Package -Name NuGet.Core -Source
```

如果要将包保存到本地计算机，而无需安装它们，使用 Save-Package

```
PS> Save-Package -Name NuGet.Core -ProviderName NuGet -Path C:\LocalPkg
```

