## 查看文件的绝对目录

realpath

## Ubuntu 22.04 安装 vm-tool

```bash
sudo apt install open-vm-tools-desktop open-vm-tools
```

## Ubuntu 22.04 安装并开启 SSH

安装 openssh-server

```
sudo apt install openssh-server
```

查看 ssh 服务是否启动，没有则输入 `sudo service ssh start`

```
sudo ps -e |grep ssh
```

## Linux 后台运行任务

```
nohup ./frpc > log.txt 2>&1 &
```

## Linux 查看后台任务

```
ps -ef | grep frpc
```

## systemctl 管理服务

Systemd 并不是一个命令，而是一组命令，涉及到系统管理的方方面面。

```bash
#停止cup电源管理服务
systemctl stop cups.service

#禁止cups服务开机启动
systemctl disable cups.service

#查看cups服务状态
systemctl status cups.service

#重新设置cups服务开机启动
systemctl enable cups.service
```

## nginx 配置修改和重载配置

```bash
# 修改配置
sudo vim /etc/nginx/nginx.conf

# 测试配置是否正确
sudo nginx -t

# 重载配置
sudo systemctl reload nginx  
```

## Linux 再次获取 dhcp ip地址

```
sudo dhclient -r //release ip 释放IP
sudo dhclient //获取IP
```

## Linux 下载文件

```
wget <download_url>
```

## Linux 将用户添加到 sudoer 中

Linux默认是没有将用户添加到sudoers列表中的，需要root手动将账户添加到sudoers列表中，才能让普通账户执行sudo命令。

root 账户键入**visudo**即可进入sudo配置，这个命令要比vim /etc/sudoers要好很多，因为使用visudo进行sudo配置，将会得到很多提示.

键入visudo后，在编辑器下键入 /root 寻找root，找到第三个root的那一行

```
root    ALL=(ALL)       ALL
```

复制并在粘贴在下一行，并修改为自己的用户名

## Linux 获取结果的前几行

```
<command> | head -10
```

## Linux 将系统文件夹名称切换为英文

```
export LANG=en_US
xdg-user-dirs-gtk-update
```

会提示是否切换为英文，点“是”，然后重启即可。
