安装 Android Studio 后，您可以通过自动更新和 Android SDK 管理器让 Android Studio IDE 和 Android SDK 工具保持最新状态。

## 使用 JetBrains Toolbox 更新 IDE

https://developer.android.com/studio/intro/update?hl=zh-cn#:~:text=%E4%BF%9D%E6%8C%81%E6%9C%80%E6%96%B0%E7%8A%B6%E6%80%81%E3%80%82-,%E4%BD%BF%E7%94%A8%20JetBrains%20Toolbox%20%E6%9B%B4%E6%96%B0%20IDE,-%E5%A6%82%E6%9E%9C%E6%82%A8%E4%BD%BF%E7%94%A8

## 使用 SDK 管理器更新工具

Android SDK 管理器可以帮助您下载 SDK 工具、平台和开发应用所需的其他组件。下载后，您可以在标示为 **Android SDK Location** 的目录中找到各软件包，如图 3 所示。

需从 Android Studio 打开 SDK 管理器，请依次点击 **Tools > SDK Manager** 或点击工具栏中的 **SDK Manager** 图标 ![img](https://developer.android.com/static/studio/images/buttons/toolbar-sdk-manager.png?hl=zh-cn)。如果您没有使用 Android Studio，可使用 [`sdkmanager`](https://developer.android.com/studio/command-line/sdkmanager?hl=zh-cn) 命令行工具下载工具。

已安装的软件包如有更新，其旁边的复选框中会显示短划线图标 ![img](https://developer.android.com/static/studio/images/sdk-manager-icon-update_2-0_2x.png?hl=zh-cn)。

- 如需更新某个软件包或安装新软件包，请选中相应复选框。
- 如需卸载某个软件包，请点击以清除对应的复选框。

待下载的更新在左侧列中以下载图标 ![img](https://developer.android.com/static/images/tools/studio-sdk-dwnld-icon.png?hl=zh-cn) 表示。待执行的移除项以红色 X 标记 ![img](https://developer.android.com/static/images/tools/studio-sdk-removal-icon.png?hl=zh-cn) 表示。

如需更新所选的软件包，请点击 **Apply** 或 **OK**，然后同意所有许可协议。

![img](https://developer.android.com/static/studio/images/sdk-manager-tools_2x.png?hl=zh-cn)

**图 3.** Android SDK 管理器。

### 所需的软件包

您可以在 **SDK 工具**标签页中找到以下工具：

- **Android SDK 构建工具**

  包含构建 Android 应用的工具。如需了解详情，请参阅 [SDK Build Tools 版本说明](https://developer.android.com/studio/releases/build-tools?hl=zh-cn)。

- **Android SDK Platform Tools**

  包含 Android 平台所需的各种工具，包括 [`adb`](https://developer.android.com/studio/command-line/adb?hl=zh-cn) 工具。

- **Android SDK 命令行工具**

  包括 ProGuard 等基本工具。如需了解详情，请参阅 [SDK 工具版本说明](https://developer.android.com/studio/releases/sdk-tools?hl=zh-cn)。

- **Android SDK Platform**

  在 **SDK Platforms** 标签页中，您必须安装至少一个版本的 Android 平台，才能编译应用。请使用最新版本的平台作为构建目标，以便在最新设备上提供最佳用户体验。如需下载某个版本，请选中版本名称旁边的复选框。您仍然可以在较低版本上运行您的应用；不过，若要在搭载最新版 Android 的设备上使用应用的新功能，您必须以最新版为构建目标。

- **Google USB 驱动程序**

  对于 Windows 是必需的。包含可帮助您使用 Google 设备执行 [`adb`](https://developer.android.com/studio/command-line/adb?hl=zh-cn) 调试的工具。如需安装，请访问[获取 Google USB 驱动程序](https://developer.android.com/studio/run/win-usb?hl=zh-cn)。

### 推荐的软件包

建议您使用以下工具进行开发：

**Android 模拟器**

基于 QEMU 的设备模拟工具，可用于在实际的 Android 运行时环境中调试和测试应用。如需了解详情，请参阅[模拟器版本说明](https://developer.android.com/studio/releases/emulator?hl=zh-cn)。

**Intel** 或 **ARM 系统映像**

运行 [Android 模拟器](https://developer.android.com/tools/devices/emulator?hl=zh-cn)需要该系统映像。平台的每个版本均包含所支持的系统映像。您也可以之后在从 [AVD 管理器](https://developer.android.com/studio/run/managing-avds?hl=zh-cn)中创建 Android 虚拟设备 (AVD) 时下载系统映像。根据开发计算机的处理器选择 Intel 或 ARM。

**Google Play 服务**

包含一组库、Javadoc 和示例，可帮助您构建应用。如果您想使用 [Google Play 服务](https://developers.google.com/android/?hl=zh-cn)中的 API，则必须使用 Google API 系统映像或 Google Play 系统映像。

以上列表并不详尽，您可以添加其他网站，以便从第三方网站下载更多软件包，如以下部分所述。

在某些情况下，某个 SDK 软件包可能需要另一个工具的特定最低修订版。如果存在这种情况，SDK 管理器将发出警告通知您，并将依赖项添加到您的下载列表。

### Gradle 自动下载缺失的软件包 

当您[从命令行](https://developer.android.com/studio/build/building-cmdline?hl=zh-cn)或 Android Studio 运行 build 时，只要已在 **SDK 管理器**中接受相应的 SDK 许可协议，Gradle 就会自动下载项目依赖的缺失 SDK 软件包。

在您使用 SDK 管理器接受许可协议后，Android Studio 会在 SDK 主目录内部创建 licenses 目录。此 licenses 目录是 Gradle 自动下载缺失软件包所必需的。

如果您已经在一个工作站上接受许可协议，但希望在另一个工作站上构建项目，则可以通过复制已接受的许可所在的目录来导出许可。

如需将许可复制到另一台机器上，请按以下步骤执行操作：

1. 在已经安装 Android Studio 的机器上，依次点击 **Tools > SDK Manager**。注意窗口顶部的 **Android SDK Location**。

2. 前往该目录，并在其中找到 `licenses/` 目录。

   如果您没有看到 `licenses/` 目录，请返回到 Android Studio，更新您的 SDK 工具并接受许可协议。返回到 Android SDK 主目录后，您现在应该会看到该目录。

3. 复制整个 `licenses/` 目录，并将其粘贴到您希望用于构建项目的计算机上的 Android SDK 主目录中。

Gradle 现在会自动下载项目依赖的缺失软件包。

请注意，对于从 Android Studio 运行的 build，此功能自动处于停用状态，因为 SDK 管理器会处理 IDE 缺失软件包的下载任务。如需手动停用此功能，请在项目的 `gradle.properties` 文件中设置 `android.builder.sdkDownload=false`。

## 使用命令行更新工具

在没有图形界面的系统（例如 CI 服务器）上，您无法在 Android Studio 中使用 SDK 管理器。请改为使用 [`sdkmanager`](https://developer.android.com/studio/command-line/sdkmanager?hl=zh-cn) 命令行工具[安装](https://developer.android.com/studio/command-line/sdkmanager?hl=zh-cn#install)和[更新](https://developer.android.com/studio/command-line/sdkmanager?hl=zh-cn#update-all) SDK 工具和平台。

使用 `sdkmanager` 安装 SDK 工具和平台后，您可能需要接受尚未接受的任何许可。您也可以使用 `sdkmanager` 完成此操作：

```
$ sdkmanager --licenses
```

此命令会扫描所有已安装的 SDK 工具和平台，并显示尚未接受的任何许可。系统会提示您接受每个许可。

> C:\Users\lcclcclcc206\AppData\Local\Android\Sdk\tools\bin