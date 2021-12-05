[configure PowerShell to only show the current folder in the prompt](https://superuser.com/questions/446827/configure-the-windows-powershell-to-display-only-the-current-folder-name-in-the)

[关于配置文件 - PowerShell | Microsoft Docs](https://docs.microsoft.com/zh-cn/powershell/module/microsoft.powershell.core/about/about_profiles?view=powershell-7.1#:~:text=A PowerShell profile is a script that runs,aliases%2C functions%2C variables%2C snap-ins%2C modules%2C and PowerShell drives.)

`test-path $profile` (是否设置了配置文件？)

`new-item -path $profile -itemtype file -force` (假设以上答案为假)

`notepad $profile` (打开记事本)

粘贴(来自上面的 super 用户答案)

```powershell
function prompt {
  $p = Split-Path -leaf -path (Get-Location)
  "$p> "
}
```

保存(您不必选择一个位置，它已经为您完成了)

重新加载 vscode - 您可能会收到有关运行脚本的错误消息(或者只是在重新加载之前执行下一步)

`Set-ExecutionPolicy RemoteSigned -Scope CurrentUser` (在您的集成终端 PS 提示符下，也来自 super 用户的回答)