## SSH 参考文档

[OpenSSH](http://www.openssh.com/)

[Home · PowerShell/Win32-OpenSSH Wiki (github.com)](https://github.com/powershell/win32-openssh/wiki)

[适用于 Windows 的 OpenSSH 服务器配置 | Microsoft Docs](https://docs.microsoft.com/zh-cn/windows-server/administration/openssh/openssh_server_configuration)

## 开启 SSH

**Windows 开启 ssh**

[安装 OpenSSH | Microsoft Docs](https://docs.microsoft.com/zh-cn/windows-server/administration/openssh/openssh_install_firstuse#install-openssh-using-powershell)

```
# Start the sshd service
Start-Service sshd

# OPTIONAL but recommended:
Set-Service -Name sshd -StartupType 'Automatic'

# Confirm the Firewall rule is configured. It should be created automatically by setup. Run the following to verify
if (!(Get-NetFirewallRule -Name "OpenSSH-Server-In-TCP" -ErrorAction SilentlyContinue | Select-Object Name, Enabled)) {
    Write-Output "Firewall Rule 'OpenSSH-Server-In-TCP' does not exist, creating it..."
    New-NetFirewallRule -Name 'OpenSSH-Server-In-TCP' -DisplayName 'OpenSSH Server (sshd)' -Enabled True -Direction Inbound -Protocol TCP -Action Allow -LocalPort 22
} else {
    Write-Output "Firewall rule 'OpenSSH-Server-In-TCP' has been created and exists."
}
```

**Linux 开启 ssh**

```
# 更新源
sudo apt-get update
# 安装 ssh 服务
sudo apt-get install openssh-server
# 检测是否启动
ps -e | grep ssh
```

## SSH 配置文件位置

Windows下，配置文件位于`~/.ssh/config`

在 Windows 中，sshd 默认情况下从 %programdata%\ssh\sshd_config 中读取配置数据，也可以通过使用 -f 参数启动 sshd 来指定不同的配置文件。 如果该文件不存在，则在启动该服务时，sshd 将使用默认配置生成一个文件。

## scp 传输文件

scp 命令的语法为

```
usage: scp [-346ABCpqrTv] [-c cipher] [-F ssh_config] [-i identity_file]
            [-J destination] [-l limit] [-o ssh_option] [-P port]
            [-S program] source ... target
```

简化版为

```
scp <source_path> <target_path>
```

参数有源地址和目的地址，这两个可以分别为本地地址和远程地址，不过本地地址和远程地址都分别且仅有一个

在执行文件传输操作之前，ssh 会要求输入远程端密码

以下是两个地址互传的实例，远程 ip 地址为 10.10.10.14

**将本地的 test.txt 文件传送到远程机器的桌面上**

```
scp .\test.txt lcc@10.10.10.14:~/Desktop/
```

**将远程机器的 test.txt 文件传送到本地终端的上下文文件夹中**

```
scp lcc@10.10.10.14:/home/lcc/Desktop/test.txt .
```

## SSH 禁止 root 连接

首先必须禁用基于 ssh 的直接 root 登录，这可以通过 sshd_config 完成

修改你的 /etc/ssh/sshd_config 并确保 PermitRootLogin 被禁用，如下所示

```
# grep -i PermitRootLogin /etc/ssh/sshd_config
PermitRootLogin no
```

默认情况下，该值为 yes，因此将其更改为“no”并保存文件，然后重启 sshd 服务以使更改生效

```
systemctl restart sshd.service
```

## SSH 远程连接时间设置

找到属性ClientAliveInterval和ClientAliveCountMax修改连接状态规则为：

ClientAliveInterval 300

ClientAliveCountMax 10

