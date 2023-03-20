## 下载安装

[Releases · termux/termux-app (github.com)](https://github.com/termux/termux-app/releases)

> 建议不要去 Google Play 上下载安装，Play 商店的 Termux 版本不是最新的

## 更换镜像站

[termux | 镜像站使用帮助 | 清华大学开源软件镜像站 | Tsinghua Open Source Mirror](https://mirrors.tuna.tsinghua.edu.cn/help/termux/)

在较新版的 Termux 中，官方提供了图形界面（TUI）来半自动替换镜像，推荐使用该种方式以规避其他风险。 在 Termux 中执行如下命令

```
termux-change-repo
```

在图形界面引导下，使用自带方向键可上下移动。
第一步使用空格选择需要更换的仓库，之后在第二步选择 TUNA/BFSU 镜像源。确认无误后回车，镜像源会自动完成更换。

## 运行 SSH Server

**Android 端**

```bash
pkg install openssh

# 修改密码
passwd

# 查看 ip
ifconfig

# 查看用户名
whoami

sshd

# 查看 ssh 是否启动
ps -e | grep sshd
```

**客户端**

```
ssh <username>@<ip> -p 8022
```

## 自动启动 ssh

[termux自动启动ssh-CSDN博客](https://blog.csdn.net/xnllc/article/details/123002331)

```
nano ~/.bashrc
```

编辑 .bashrc 文件

```shell
echo
echo "ip 信息"
ifconfig | grep inet
echo
echo "用户："$(whoami)

if pgrep -x "sshd" >/dev/null
  then
    echo "sshd运行中"
  else
    sshd
    echo "自动启动sshd"
fi
```

