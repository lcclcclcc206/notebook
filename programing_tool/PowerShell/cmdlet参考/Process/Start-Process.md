[Start-Process (Microsoft.PowerShell.Management) - PowerShell | Microsoft Docs](https://docs.microsoft.com/zh-cn/powershell/module/microsoft.powershell.management/start-process?view=powershell-7.1#parameters)

启动本地计算机上的一个或多个进程。



## 语法

```powershell
Start-Process
     [-FilePath] <String>
     [[-ArgumentList] <String[]>]
     [-Credential <PSCredential>]
     [-WorkingDirectory <String>]
     [-LoadUserProfile]
     [-NoNewWindow]
     [-PassThru]
     [-RedirectStandardError <String>]
     [-RedirectStandardInput <String>]
     [-RedirectStandardOutput <String>]
     [-WindowStyle <ProcessWindowStyle>]
     [-Wait]
     [-UseNewEnvironment]
     [-WhatIf]
     [-Confirm]
     [<CommonParameters>]
```

```powershell
Start-Process
     [-FilePath] <String>
     [[-ArgumentList] <String[]>]
     [-WorkingDirectory <String>]
     [-PassThru]
     [-Verb <String>]
     [-WindowStyle <ProcessWindowStyle>]
     [-Wait]
     [-WhatIf]
     [-Confirm]
     [<CommonParameters>]
```



## 说明

`Start-process` cmdlet 在本地计算机上启动一个或多个进程。默认情况下，`Start-Process` 创建一个新进程，该进程继承当前进程中定义的所有环境变量。

若要指定进程中运行的程序，请输入可执行文件或脚本文件，或者可以使用计算机上的程序打开的文件。如果指定了一个非可执行文件，`Start-Process` 将启动与该文件关联的程序，类似于 `Invoke-Item` cmdlet。

您可以使用 `Start-Process` 的参数来指定选项，例如加载用户配置文件、在新窗口中启动进程或使用备用凭据。



## 例子



### 示例1: 启动使用默认值的进程

此示例启动使用当前文件夹中的 `Sort.exe` 文件的进程。该命令使用所有默认值，包括默认窗口样式、工作文件夹和凭据。

```powershell
Start-Process -FilePath "sort.exe"
```



### 示例2: 打印文本文件

此示例启动输出 `C:\PS-Test\MyFile.txt` 文件的进程。

```powershell
Start-Process -FilePath "myfile.txt" -WorkingDirectory "C:\PS-Test" -Verb Print
```



### 示例3: 启动一个进程，将项目排序到一个新文件

此示例启动一个进程，对 `Testsort.txt` 文件中的项进行排序，并返回 `Sorted.txt` 文件中的排序项。任何错误都被写入到 `SortError.txt` 文件中。`UseNewEnvironment` 参数指定流程使用自己的环境变量运行。

```powershell
$processOptions = @{
    FilePath = "sort.exe"
    RedirectStandardInput = "TestSort.txt"
    RedirectStandardOutput = "Sorted.txt"
    RedirectStandardError = "SortError.txt"
    UseNewEnvironment = $true
}
Start-Process @processOptions
```

此示例使用 splatting 将参数传递给 cmdlet。



### 示例4: 最大化窗口启动进程

此示例启动 `Notepad.exe` 进程，它最大化窗口并保留窗口直到进程完成。

```powershell
Start-Process -FilePath "notepad" -Wait -WindowStyle Maximized
```



### 示例5: 以管理员身份启动 PowerShell

此示例使用 **Run as administrator** 选项启动 PowerShell。

```powershell
Start-Process -FilePath "powershell" -Verb RunAs
```



### 例6: 使用不同的动词开始一个过程

此示例演示如何查找启动进程时可以使用的动词。可用动词由进程中运行的文件的文件扩展名确定。

```powershell
$startExe = New-Object System.Diagnostics.ProcessStartInfo -Args PowerShell.exe
$startExe.verbs

open
runas
runasuser
```

该示例使用 `New-Object` 创建一个 **System.Diagnostics.ProcessStartInfo** 对象。用于 **PowerShell.exe** 的 **ProcessStartInfo** 对象，该文件运行在 PowerShell 进程中。**ProcessStartInfo** 对象的 **Verbs** 属性显示您可以将 Open 和 RunAs 谓词与 `PowerShell.exe` 一起使用。



### 示例7: 为进程指定参数

这两个命令都启动 Windows 命令解释器，在 `Program Files` 文件夹中发出 `dir` 命令。因为此 foldername 包含一个空格，所以该值需要包含转义引号。注意，第一个命令将字符串指定为 **ArgumentList**。第二个命令是一个字符串数组。

```powershell
Start-Process -FilePath "$env:comspec" -ArgumentList "/c dir `"%systemdrive%\program files`""
Start-Process -FilePath "$env:comspec" -ArgumentList "/c","dir","`"%systemdrive%\program files`""
```



### 示例8: 在 Linux 上创建一个分离进程

在 Windows 上，`Start-Process` 创建一个独立于启动 shell 的独立进程。在非 windows 平台上，新启动的进程附加到启动的 shell 上。如果启动的 Shell 关闭，子进程终止。

为了避免在类 unix 平台上终止子进程，可以将 `Start-Process` 与 `nohup` 结合起来。下面的示例在 Linux 上启动 PowerShell 的后台实例，即使在关闭启动会话之后它仍然是活动的。`nohup` 收集输出到工作目录文件 nohup.out 中。

```powershell
# Runs for 2 minutes and appends output to ./nohup.out
Start-Process nohup 'pwsh -noprofile -c "1..120 | % { Write-Host . -NoNewline; sleep 1 }"'
```

在本例中，`Start-Process` 正在运行 linux `nohup` 命令，该命令将 pwsh 作为一个分离进程启动。有关更多信息，请参见 nohup 手册页。



## 注释

默认情况下，`Start-Process` 异步启动流程。即使新进程仍在运行，控件也会立即返回到 PowerShell。

- 在本地系统上，启动的进程独立于调用进程
- 在远程系统上，当远程会话结束时，新进程将在 `Start-process` 命令之后立即终止。因此，您不能在远程会话中使用 `Start-Process` ，因为它期望的启动的进程比会话长。

如果确实需要在远程会话中使用 `Start-Process`，请使用 **Wait** 参数调用它。或者您可以使用其他方法在远程系统上创建一个新进程。

当使用 **Wait** 参数时，`Start-Process` 等待进程树(进程及其所有子进程)退出，然后返回控制。这与 `Wait-Process` cmdlet 的行为不同，后者只等待指定的进程退出。

在 Windows 上，`Start-Process` 最常见的用例是使用 **Wait** 参数阻止进度，直到新进程退出。在非 windows 系统上，很少需要这样做，因为命令行应用程序的默认行为相当于 `Start-Process -Wait`。

这个 cmdlet 是使用 **System.Diagnostics.Process**  的 Start 方法实现的。有关此方法的详细信息，请参阅[Process.Start Method](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process.start#overloads)。

