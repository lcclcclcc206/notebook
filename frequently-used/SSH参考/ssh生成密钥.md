## 生成密钥

```
ssh-keygen -t ed25519
```

## Windows 开启 ssh-agent 服务

```powershell
# By default the ssh-agent service is disabled. Allow it to be manually started for the next step to work.
# Make sure you're running as an Administrator.
Get-Service ssh-agent | Set-Service -StartupType Manual

# Start the service
Start-Service ssh-agent

# This should return a status of Running
Get-Service ssh-agent
```

## 客户端添加密钥

```
ssh-add <key-path>
```

## Linux 创建公钥认证文件

```
touch ~/.ssh/authorized_keys
```

