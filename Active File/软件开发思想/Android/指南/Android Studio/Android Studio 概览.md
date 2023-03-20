Android Studio 是用于开发 Android 应用的官方集成开发环境 (IDE)。Android Studio 基于 [IntelliJ IDEA](https://www.jetbrains.com/idea/) 强大的代码编辑器和开发者工具，还提供更多可提高 Android 应用构建效率的功能，例如：

- 基于 Gradle 的灵活构建系统
- 快速且功能丰富的模拟器
- 统一的环境（供您开发适用于所有 Android 设备的应用）
- Apply Changes 功能可将代码和资源更改推送到正在运行的应用，而无需重启应用
- 代码模板和 GitHub 集成，可协助您打造常见的应用功能及导入示例代码
- 大量的测试工具和框架
- Lint 工具，能够找出性能、易用性和版本兼容性等方面的问题
- C++ 和 NDK 支持
- 内置对 [Google Cloud Platform](https://cloud.google.com/tools/android-studio/docs/?hl=zh-cn) 的支持，可轻松集成 Google Cloud Messaging 和 App Engine

本页面介绍了 Android Studio 的基本功能。如需查看最新变更摘要，请参阅 [Android Studio 版本说明](https://developer.android.com/studio/releases?hl=zh-cn)。

## 项目结构

Android Studio 中的每个项目都包含一个或多个内有源代码文件和资源文件的模块。模块的类型包括：

- Android 应用模块
- 库模块
- Google App Engine 模块

默认情况下，Android Studio 会在 Android 项目视图中显示您的项目文件（如图 1 所示）。该视图按模块组织结构，方便您快速访问项目的关键源文件。所有 build 文件都在顶层的 **Gradle Scripts** 下显示。

每个应用模块都包含以下文件夹：

- **manifests**：包含 `AndroidManifest.xml` 文件。
- **java**：包含 Java 和 Kotlin 源代码文件，包括 JUnit 测试代码。
- **res**：包含所有非代码资源，例如 XML 布局、界面字符串和位图图像。

磁盘上的 Android 项目结构与此扁平表示形式的项目结构有所不同。如需查看项目的实际文件结构，请从 **Project** 菜单中选择 **Project**，而非 **Android**。

![img](https://developer.android.com/static/studio/images/intro/project-android-view_2-1_2x.png?hl=zh-cn)

## 界面

Android Studio 主窗口由图 3 中标注的几个逻辑区域组成。

![img](https://developer.android.com/static/studio/images/intro/main-window_2-2_2x.png?hl=zh-cn)

**图 3.** Android Studio 主窗口。

1. **工具栏**：执行各种操作，其中包括运行应用和启动 Android 工具。
2. **导航栏**：在项目中导航，以及打开文件进行修改。此区域提供 **Project** 窗口中所示结构的精简视图。
3. **编辑器窗口**：创建和修改代码。编辑器可能因当前文件类型而异。例如，查看布局文件时，该编辑器会显示布局编辑器。
4. **工具窗口栏**：使用 IDE 窗口外部的按钮可展开或收起各个工具窗口。
5. **工具窗口**：执行特定任务，例如项目管理、搜索和版本控制等。您可以展开和折叠这些窗口。
6. **状态栏**：显示项目和 IDE 本身的状态以及任何警告或消息。

如需在源代码、数据库、操作、界面元素等对象中搜索，请执行以下操作之一：

- 连按两次 Shift 键。
- 点击 Android Studio 窗口右上角的放大镜。

此功能非常实用，例如在您忘记如何触发特定 IDE 操作时，可以利用此功能进行查找。

### 工具窗口

Android Studio 不使用预设窗口，而是根据情境在您执行操作时自动显示相关工具窗口。默认情况下，最常用的工具窗口会固定在应用窗口边缘的工具窗口栏上。

您也可以使用[键盘快捷键](https://developer.android.com/studio/intro/keyboard-shortcuts?hl=zh-cn)打开工具窗口。表 1 列出了最常用工具窗口的快捷键。

**表 1.** 工具窗口的键盘快捷键

| 工具窗口         | Windows 和 Linux | macOS             |
| :--------------- | :--------------- | :---------------- |
| 项目             | Alt+1            | Command+1         |
| 版本控制         | Alt+9            | Command+9         |
| 运行             | Shift+F10        | Ctrl+R            |
| 调试             | Shift+F9         | Ctrl+D            |
| Logcat           | Alt+6            | Command+6         |
| 返回编辑器       | Esc              | Esc               |
| 隐藏所有工具窗口 | Ctrl+Shift+F12   | Command+Shift+F12 |

### 代码补全

Android Studio 有三种代码补全类型，您可以通过键盘快捷键使用这些类型。

**表 2.** 代码补全功能的键盘快捷键

| 类型     | 说明                                                         | Windows 和 Linux  | macOS               |
| :------- | :----------------------------------------------------------- | :---------------- | :------------------ |
| 基本补全 | 显示对变量、类型、方法和表达式等的基本建议。如果连续两次调用基本补全，系统将显示更多结果，包括私有成员和非导入静态成员。 | Ctrl+空格键       | Ctrl+空格键         |
| 智能补全 | 根据上下文显示相关选项。智能自动补全可识别预期类型和数据流。如果连续两次调用智能自动补全，系统将显示更多结果，包括链。 | Ctrl+Shift+空格键 | Ctrl+Shift+空格键   |
| 语句补全 | 补全当前语句，添加缺失的圆括号、大括号、花括号和格式等。     | Ctrl+Shift+Enter  | Command+Shift+Enter |

若要执行快速修复并显示建议的操作，请按 Alt+Enter。

### 导航

以下是一些助您在 Android Studio 中导航的提示。

- 使用**最近文件**操作可在最近访问过的文件之间切换：

  按 Ctrl+E（在 macOS 中，按 Command+E）可调出**最近文件**操作。默认情况下，系统将选择最后一次访问的文件。在此操作中，您还可以通过左侧列访问任何工具窗口。

- 使用**文件结构**操作可查看当前文件的结构，还可快速前往当前文件的任何部分：

  按 Ctrl+F12（在 macOS 中，按 Command+F12）可调出**文件结构**操作。

- 使用**前往类**操作可搜索并前往项目中的特定类。**前往类**支持复杂的表达式，包括驼峰（让您可使用某元素的驼峰式大小写名称中的大写字母进行搜索）、路径、行导航（让您可前往文件内的特定行）和中间名匹配（让您可搜索类名称的一部分）等。 如果连续两次调用此操作，系统将显示项目类以外的结果。

  按 Ctrl+N（在 macOS 中，按 Command+O）可调出**前往类**操作。

- 使用**前往文件**操作可前往文件或文件夹：

  按 Ctrl+Shift+N（在 macOS 中，按 Command+Shift+O）可调出**前往文件**操作。如需搜索文件夹（而不是文件），请在表达式末尾添加“/”。

- 使用**前往符号**操作可按名称前往某个方法或字段：

  按 Ctrl+Shift+Alt+N（在 macOS 中，按 Command+Option+O）可调出**前往符号**操作。

- 按 Alt+F7（在 macOS 中，按 Option+F7）可查找引用当前光标位置处的类、方法、字段、参数或语句的所有代码片段。

### 样式和格式

在您编辑时，Android Studio 会自动应用代码样式设置中指定的格式和样式。您可以通过编程语言自定义代码样式设置，其中包括指定制表符和缩进、空格、换行、花括号以及空白行的规范。

如需自定义代码样式设置，请依次点击 **File > Settings > Editor > Code Style**（在 macOS 中，请依次点击 **Android Studio > Preferences > Editor > Code Style**）。

虽然 IDE 会在您执行操作时自动应用格式，但您也可以显式调用**重新格式化代码**操作。按 Ctrl+Alt+L（在 macOS 中，按 Option+Command+L）可调用此操作。按 Ctrl+Alt+I（在 macOS 中，按 Ctrl+Option+I）可自动缩进所有行。

### 版本控制基础知识

Android Studio 支持多个版本控制系统 (VCS)，包括 Git、GitHub、CVS、Mercurial、Subversion 和 Google Cloud Source Repositories。

在将您的应用导入 Android Studio 后，您可以使用 Android Studio VCS 菜单选项启用对所需系统的 VCS 支持、创建代码库、导入新文件至版本控制以及执行其他版本控制操作。

若要启用 VCS 支持，请按以下步骤操作：

1. 在 Android Studio **VCS** 菜单中，选择 **Enable Version Control Integration**。
2. 从该菜单中选择要与项目根目录关联的 VCS。
3. 点击 **OK**。

此时，VCS 菜单将根据您选择的系统显示多个版本控制选项。

**注意**：您还可以使用 **File > Settings > Version Control** 菜单选项设置和修改版本控制设置。

## Gradle 构建系统

Android Studio 会将 Gradle 用作构建系统的基础，并通过 [Android Gradle 插件](https://developer.android.com/studio/releases/gradle-plugin?hl=zh-cn)提供更多面向 Android 的功能。该构建系统可以作为集成工具从 Android Studio 菜单运行，也可从命令行独立运行。您可以利用构建系统的功能执行以下操作：

- 自定义、配置和扩展构建流程。
- 使用相同的项目和模块为您的应用创建多个具有不同功能的 APK。
- 在不同源集中重复使用代码和资源。

利用 Gradle 的灵活性，您可以在不修改应用核心源文件的情况下完成以上所有操作。

Android Studio build 文件以 `build.gradle` 命名。它们是使用 Android Gradle 插件提供的元素以 [Groovy](http://groovy-lang.org/) 语法来配置 build 的纯文本文件。每个项目都有一个用于整个项目的顶级 build 文件，以及用于各模块的单独模块级 build 文件。在导入现有项目时，Android Studio 会自动生成必要的 build 文件。

如需详细了解构建系统以及如何配置 build，请参阅[配置 build](https://developer.android.com/studio/build?hl=zh-cn)。

### build 变体

构建系统可帮助您从一个项目创建同一应用的不同版本。如果您同时拥有免费版本和付费版本的应用，或想要在 Google Play 上为不同设备配置分发多个 APK，此功能十分实用。

如需详细了解如何配置 build 变体，请参阅[配置 build 变体](https://developer.android.com/studio/build/build-variants?hl=zh-cn)。

### 管理依赖项

项目的依赖项在 `build.gradle` 文件中按名称指定。 Gradle 会查找依赖项，并在 build 中提供这些依赖项。您可以在 `build.gradle` 文件中声明模块依赖项、远程二进制依赖项以及本地二进制依赖项。

Android Studio 配置项目时默认使用 Maven 中央制品库。该配置包含在项目的顶级 build 文件中。

如需详细了解如何配置依赖项，请参阅[添加 build 依赖项](https://developer.android.com/studio/build/dependencies?hl=zh-cn)。