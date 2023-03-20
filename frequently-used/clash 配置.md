## 文件准备

- clash：clash 二进制运行文件，https://github.com/Dreamacro/clash/releases

- config.yaml：clash 配置文件，由机场提供
- Country.mmdb：`Country.mmdb` 文件利用 GeoIP2 服务能识别互联网用户的地点位置，以供规则分流时使用

将文件放到指定位置

```
mkdir /etc/clash

# /usr/local/bin/clash
cp clash /usr/local/bin

# /etc/clash/config.yaml
cp config.yaml /etc/clash/

# /etc/clash/Country.mmdb
cp Country.mmdb /etc/clash/
```

记得给 clash 赋予可执行权限

```
chmod u+x /usr/local/bin/clash
```

## 使用 systemd 将 clash 转为系统服务

创建 systemd 服务配置文件 `sudo nano /etc/systemd/system/clash.service`：

```
[Unit]
Description=Clash daemon, A rule-based proxy in Go.
After=network.target

[Service]
Type=simple
Restart=always
ExecStart=/usr/local/bin/clash -d /etc/clash

[Install]
WantedBy=multi-user.target
```

让 clash 开机自启动

```
systemctl enable clash
```

立即启动 clash

```
systemctl start clash
```

检查 clash 运行情况和日志

```
systemctl status clash
journalctl -xe
```

## 使用代理

利用 export 命令使用代理

```
export https_proxy=http://127.0.0.1:7890 http_proxy=http://127.0.0.1:7890 all_proxy=socks5://127.0.0.1:7890
```

可以将该命令添加到 `.bashrc` 中，登陆后该用户自动开启代理。

取消系统代理：

```
unset  http_proxy  https_proxy  all_proxy
```

## DashBoard 外部控制

http://clash.razord.top/

外部控制端口为 9090，可以在该链接的网站下输入 ip 地址和端口来对 clash 进行配置

## 访问外网测试

```
cd /tmp
wget https://www.7-zip.org/a/7z2201.exe

ping stackflow.com
```

## Other

```
export https_proxy=http://175.178.206.100:7890 http_proxy=http://175.178.206.100:7890 all_proxy=socks5://175.178.206.100:7890
export https_proxy=http://106.52.149.164:7890 http_proxy=http://106.52.149.164:7890 all_proxy=socks5://106.52.149.164:7890
```

