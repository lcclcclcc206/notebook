## 查询设备

在发出 adb 命令之前，了解哪些设备实例已连接到 adb 服务器会很有帮助。您可以使用 `devices` 命令生成已连接设备的列表。

```
adb devices -l
```

![image-20220620162038763](adb basic use.assets/image-20220620162038763.png)

作为回应，adb 会针对每个设备输出以下状态信息：

- 序列号：由 adb 创建的字符串，用于通过端口号唯一标识设备。 下面是一个序列号示例：`emulator-5554`
- 状态：设备的连接状态可以是以下几项之一：
  - `offline`：设备未连接到 adb 或没有响应。
  - `device`：设备现已连接到 adb 服务器。请注意，此状态并不表示 Android 系统已完全启动并可正常运行，因为在设备连接到 adb 时系统仍在启动。不过，在启动后，这将是设备的正常运行状态。
  - `no device`：未连接任何设备。
- 说明：如果您包含 `-l` 选项，`devices` 命令会告知您设备是什么。当您连接了多个设备时，此信息很有用，可帮助您将它们区分开来。

## 安装应用

可以使用 adb 的 `install` 命令在模拟器或连接的设备上安装 APK：

```
adb install path_to_apk
```

安装测试 APK 时，必须在 `install` 命令中使用 `-t` 选项。如需了解详情，请参阅 [`-t`](https://developer.android.google.cn/studio/command-line/adb#-t-option)。

