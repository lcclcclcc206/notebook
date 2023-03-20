WPF 是一个与分辨率无关的 UI 框架，使用基于矢量的呈现引擎，构建用于利用现代图形硬件。 WPF 提供一套完善的应用程序开发功能，这些功能包括 Extensible Application Markup Language (XAML)、控件、数据绑定、布局、二维和三维图形、动画、样式、模板、文档、媒体、文本和版式。 WPF 属于 .NET，因此可以生成整合 .NET API 其他元素的应用程序。

## 使用 WPF 进行编程

WPF 作为 .NET 类型的一个子集存在，大部分位于 [System.Windows](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows) 命名空间中。 如果你曾经使用 ASP.NET 和 Windows 窗体等框架通过 .NET 构建应用程序，应该会熟悉基本的 WPF 编程体验：

- 实例化类
- 设置属性
- 调用方法
- 处理事件

WPF 还包括可增强属性和事件的其他编程构造：[依赖项属性](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/properties/dependency-properties-overview?view=netdesktop-6.0)和[路由事件](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/events/routed-events-overview?view=netdesktop-6.0)。

## 标记和代码隐藏

通过 WPF，可以使用标记和代码隐藏开发应用程序，这是 ASP.NET 开发人员已经熟悉的体验。 通常使用 XAML 标记实现应用程序的外观，同时使用托管编程语言（代码隐藏）来实现其行为。 这种外观和行为的分离具有以下优点：

- 降低了开发和维护成本，因为特定于外观的标记与特定于行为的代码不紧密耦合。
- 开发效率更高，因为设计人员在实现应用程序外观的同时，开发人员可以实现应用程序的行为。
- WPF 应用程序的[全球化和本地化](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/advanced/wpf-globalization-and-localization-overview?view=netdesktop-6.0) 得以简化。

## 标记（Markup）

XAML 是一种基于 XML 的标记语言，以声明形式实现应用程序的外观。 通常用它定义窗口、对话框、页面和用户控件，并填充控件、形状和图形。

下面的示例使用 XAML 来实现包含一个按钮的窗口的外观：

```xaml
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    Title="Window with Button"
    Width="250" Height="100">

  <!-- Add button to window -->
  <Button Name="button">Click Me!</Button>

</Window>
```

具体而言，此 XAML 使用 `Window` 元素定义窗口，使用 `Button` 元素定义按钮。 每个元素均配置了特性（如 `Window` 元素的 `Title` 特性）来指定窗口的标题栏文本。 在运行时，WPF 会将标记中定义的元素和特性转换为 WPF 类的实例。 例如， `Window` 元素被转换为 [Window](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.window) 类的实例，该类的 [Title](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.window.title) 属性是 `Title` 特性的值。

下图显示上一个示例中的 XAML 定义的用户界面 (UI)：

![包含按钮的窗口](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/overview/media/index/markup-window-button.png?view=netdesktop-6.0)

由于 XAML 是基于 XML 的，因此使用它编写的 UI 汇集在嵌套元素的层次结构中，称为[元素树](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/advanced/trees-in-wpf?view=netdesktop-6.0)。 元素树提供了一种直观的逻辑方式来创建和管理 UI。

## 代码隐藏

应用程序的主要行为是实现响应用户交互的功能，包括处理事件（例如，单击菜单、工具栏或按钮）以及相应地调用业务逻辑和数据访问逻辑。 在 WPF 中，在与标记相关联的代码中实现此行为。 此类代码称为代码隐藏。 下面的示例演示上一个示例的更新标记和代码隐藏：

```xaml
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    x:Class="SDKSample.AWindow"
    Title="Window with Button"
    Width="250" Height="100">

  <!-- Add button to window -->
  <Button Name="button" Click="button_Click">Click Me!</Button>

</Window>
```

```csharp
using System.Windows; // Window, RoutedEventArgs, MessageBox

namespace SDKSample
{
    public partial class AWindow : Window
    {
        public AWindow()
        {
            // InitializeComponent call is required to merge the UI
            // that is defined in markup with this class, including  
            // setting properties and registering event handlers
            InitializeComponent();
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            // Show message box when button is clicked.
            MessageBox.Show("Hello, Windows Presentation Foundation!");
        }
    }
}
```

在此示例中，代码隐藏实现派生自 [Window](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.window) 类的类。 `x:Class` 特性用于将标记与代码隐藏类相关联。 **从代码隐藏类的构造函数调用 `InitializeComponent`，以将标记中定义的 UI 与代码隐藏类合并在一起。 （生成应用程序时即会生成 `InitializeComponent`，因此不需要手动实现它。）`x:Class` 和 `InitializeComponent` 的组合可确保在创建实现时正确地对其进行初始化。** 代码隐藏类还可实现按钮的 [Click](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.primitives.buttonbase.click) 事件的事件处理程序。 单击该按钮后，事件处理程序会通过调用 [System.Windows.MessageBox.Show](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.messagebox.show) 方法显示一个消息框。

下图显示单击该按钮后的结果：

![A MessageBox](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/media/introduction-to-wpf/wpfintrofigure25.png?view=netframeworkdesktop-4.8)

## 控件

应用程序模型带来的用户体验是构造的控件。 在 WPF 中，控件是适用于 WPF 类这一类别的总括术语，这些类托管在窗口或页中、具有用户界面并实现一些行为。

下面列出了内置的 WPF 控件：

- **按钮**： [Button](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.button) 和 [RepeatButton](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.primitives.repeatbutton)。
- **数据显示**：[DataGrid](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.datagrid)、[ListView](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.listview) 和 [TreeView](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.treeview)。
- **日期显示和选项**： [Calendar](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.calendar) 和 [DatePicker](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.datepicker)。
- **对话框**： [OpenFileDialog](https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.win32.openfiledialog)、 [PrintDialog](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.printdialog)和 [SaveFileDialog](https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.win32.savefiledialog)。
- **数字墨迹**： [InkCanvas](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.inkcanvas) 和 [InkPresenter](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.inkpresenter)。
- **文档**： [DocumentViewer](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.documentviewer)、 [FlowDocumentPageViewer](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.flowdocumentpageviewer)、 [FlowDocumentReader](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.flowdocumentreader)、 [FlowDocumentScrollViewer](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.flowdocumentscrollviewer)和 [StickyNoteControl](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.stickynotecontrol)。
- **输入**： [TextBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.textbox)、 [RichTextBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.richtextbox)和 [PasswordBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.passwordbox)。
- **布局**： [Border](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.border)、 [BulletDecorator](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.primitives.bulletdecorator)、 [Canvas](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.canvas)、 [DockPanel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.dockpanel)、 [Expander](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.expander)、 [Grid](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.grid)、 [GridView](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.gridview)、 [GridSplitter](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.gridsplitter)、 [GroupBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.groupbox)、 [Panel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.panel)、 [ResizeGrip](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.primitives.resizegrip)、 [Separator](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.separator)、 [ScrollBar](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.primitives.scrollbar)、 [ScrollViewer](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.scrollviewer)、 [StackPanel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.stackpanel)、 [Thumb](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.primitives.thumb)、 [Viewbox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.viewbox)、 [VirtualizingStackPanel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.virtualizingstackpanel)、 [Window](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.window)和 [WrapPanel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.wrappanel)。
- **媒体**： [Image](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.image)、 [MediaElement](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.mediaelement)和 [SoundPlayerAction](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.soundplayeraction)。
- **菜单**： [ContextMenu](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.contextmenu)、 [Menu](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.menu)和 [ToolBar](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.toolbar)。
- **导航**： [Frame](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.frame)、 [Hyperlink](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.documents.hyperlink)、 [Page](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.page)、 [NavigationWindow](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.navigation.navigationwindow)和 [TabControl](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.tabcontrol)。
- **选项**： [CheckBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.checkbox)、 [ComboBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.combobox)、 [ListBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.listbox)、 [RadioButton](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.radiobutton)和 [Slider](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.slider)。
- **用户信息**： [AccessText](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.accesstext)、 [Label](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.label)、 [Popup](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.primitives.popup)、 [ProgressBar](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.progressbar)、 [StatusBar](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.primitives.statusbar)、 [TextBlock](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.textblock)和 [ToolTip](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.tooltip)。

## 输入和命令

最常检测和响应用户输入的控件。 [WPF 输入系统](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/advanced/input-overview?view=netframeworkdesktop-4.8) 使用直接事件和路由事件来支持文本输入、焦点管理和鼠标定位。

应用程序通常具有复杂的输入要求。 WPF 提供了[命令系统](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/advanced/commanding-overview?view=netframeworkdesktop-4.8)，用于将用户输入操作与对这些操作做出响应的代码分隔开来。

## 布局

创建用户界面时，按照位置和大小排列控件以形成布局。 任何布局的一项关键要求都是适应窗口大小和显示设置的变化。 WPF 为你提供一流的可扩展布局系统，而不强制你编写代码以适应这些情况下的布局。

布局系统的基础是相对定位，这提高了适应不断变化的窗口和显示条件的能力。 此外，该布局系统还可管理控件之间的协商以确定布局。 协商是一个两步过程：首先，控件将需要的位置和大小告知父级；其次，父级将控件可以有的空间告知控件。

该布局系统通过基 WPF 类公开给子控件。 对于通用的布局（如网格、堆叠和停靠），WPF 包括若干布局控件：

- [Canvas](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.canvas)：子控件提供其自己的布局。
- [DockPanel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.dockpanel)：子控件与面板的边缘对齐。
- [Grid](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.grid)：子控件由行和列定位。
- [StackPanel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.stackpanel)：子控件垂直或水平堆叠。
- [VirtualizingStackPanel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.virtualizingstackpanel)：子控件在水平或垂直的行上虚拟化并排列。
- [WrapPanel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.wrappanel)：子控件按从左到右的顺序定位，在当前行上的控件超出允许的空间时，换行到下一行。

下面的示例使用 [DockPanel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.dockpanel) 布置几个 [TextBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.textbox) 控件：

XAML复制

```xaml
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    x:Class="SDKSample.LayoutWindow"
    Title="Layout with the DockPanel" Height="143" Width="319">
  
  <!--DockPanel to layout four text boxes--> 
  <DockPanel>
    <TextBox DockPanel.Dock="Top">Dock = "Top"</TextBox>
    <TextBox DockPanel.Dock="Bottom">Dock = "Bottom"</TextBox>
    <TextBox DockPanel.Dock="Left">Dock = "Left"</TextBox>
    <TextBox Background="White">This TextBox "fills" the remaining space.</TextBox>
  </DockPanel>

</Window>
```

[DockPanel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.dockpanel) 允许子 [TextBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.textbox) 控件，以告诉它如何排列这些控件。 为了完成此操作，[DockPanel](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.dockpanel) 实现 `Dock` 附加了属性，该属性公开给子控件，以允许每个子控件指定停靠样式。

下图显示上一个示例中的 XAML 标记的结果：：

![DockPanel page](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/media/introduction-to-wpf/wpfintrofigure11.png?view=netframeworkdesktop-4.8)

## 数据绑定

大多数应用程序旨在为用户提供查看和编辑数据的方法。 对于 WPF 应用程序，已对存储和访问数据的工作提供技术（如 SQL Server 和 ADO.NET）。 访问数据并将数据加载到应用程序的托管对象后，WPF 应用程序的复杂工作开始。 从根本上来说，这涉及到两件事：

1. 将数据从托管对象复制到控件，在控件中可以显示和编辑数据。
2. 确保使用控件对数据所做的更改将复制回托管对象。

为了简化应用程序开发，WPF 提供了一个数据绑定引擎来自动执行这些步骤。 数据绑定引擎的核心单元是 [Binding](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.data.binding) 类，其工作是将控件（绑定目标）绑定到数据对象（绑定源）。 下图阐释了这种关系：

![Basic data binding diagram](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/media/introduction-to-wpf/databindingmostbasic.png?view=netframeworkdesktop-4.8)

下一示例演示如何将 [TextBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.textbox) 绑定到自定义 `Person` 对象的实例。 下面的代码演示了 `Person` 实现：

```cs
namespace SDKSample
{
    class Person
    {
        string name = "No Name";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
```

下面的标记将 [TextBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.textbox) 绑定到自定义 `Person` 对象的实例：

```xaml
<Window
     xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
     xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
     x:Class="SDKSample.DataBindingWindow">

   <!-- Bind the TextBox to the data source (TextBox.Text to Person.Name) -->
   <TextBox Name="personNameTextBox" Text="{Binding Path=Name}" />

 </Window>
```

```cs
using System.Windows; // Window

namespace SDKSample
{
    public partial class DataBindingWindow : Window
    {
        public DataBindingWindow()
        {
            InitializeComponent();

            // Create Person data source
            Person person = new Person();

            // Make data source available for binding
            this.DataContext = person;
        }
    }
}
```

在此示例中， `Person` 类在代码隐藏中实例化并被设置为 `DataBindingWindow`的数据上下文。 在标记中， [Text](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.textbox.text) 的 [TextBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.textbox) 属性被绑定至 `Person.Name` 属性（使用“`{Binding ... }`”XAML 语法）。 此 XAML 告知 WPF 将 [TextBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.textbox) 控件绑定至窗口的 `Person` 属性中存储的 [DataContext](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.frameworkelement.datacontext) 对象。

WPF 数据绑定引擎提供了额外支持，包括验证、排序、筛选和分组。 此外，数据绑定支持在标准 WPF 控件显示的用户界面不恰当时，使用数据模板来为数据绑定创建自定义的用户界面。

有关详细信息，请参阅[数据绑定概述](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/data/data-binding-overview?view=netframeworkdesktop-4.8)。

## 图形

[Windows Presentation Foundation 简介 - WPF .NET | Microsoft Learn](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/overview/?view=netdesktop-6.0&preserve-view=true#graphics--animation)

WPF 引入了一组广泛、可伸缩的灵活图形功能，具有以下优点：

- **图形与分辨率和设备均无关**。 WPF 图形系统中的基本度量单位是与设备无关的像素（即 1/96 英寸），且不考虑实际屏幕分辨率，并为实现与分辨率和设备无关的呈现提供了基础。 每个与设备无关的像素都会自动缩放，以匹配呈现它的系统的每英寸点数 (dpi) 设置。
- **精度更高**。 WPF 坐标系统使用双精度浮点数字度量，而不是单精度数字。 转换和不透明度值也表示为双精度数字。 WPF 还支持广泛的颜色域 (scRGB)，并集成了对管理来自不同颜色空间的输入的支持。
- **高级图形和动画支持**。 WPF 通过为你管理动画场景简化了图形编程，你无需担心场景处理、呈现循环和双线性内插。 此外，WPF 还提供了点击测试支持和全面的 alpha 合成支持。
- **硬件加速**。 WPF 图形系统充分利用图形硬件来尽量降低 CPU 使用率。

## 文本和版式

WPF 提供以下功能以实现高质量的文本呈现：

- OpenType 字体支持。
- ClearType 增强功能。
- 利用硬件加速的高性能。
- 文本与媒体、图形和动画的集成。
- 国际字体支持和回退机制。

作为文本与图形集成的演示，下图显示了文本修饰的应用程序：

![具有各种文本修饰的文本](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/overview/media/index/text.png?view=netdesktop-6.0)

有关详细信息，请参阅 [Windows Presentation Foundation 中的版式](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/advanced/typography-in-wpf?view=netdesktop-6.0)。

## 自定义 WPF 应用

到目前为止，你已经了解用于开发应用程序的核心 WPF 构建块：

- 你可以使用该应用程序模型来托管和交付应用程序内容，它主要由控件组成。
- 为简化用户界面中控件的安排，可使用 WPF 布局系统。
- 可以使用数据绑定来减少将用户界面与数据集成的工作。
- 若要增强你应用程序的可视化外观，可以使用 WPF 提供的综合图形、动画和媒体支持。

不过，在创建和管理真正独特且视觉效果非凡的用户体验时，基础知识通常是不够的。 标准的 WPF 控件可能无法与你所需的应用程序外观集成。 数据可能不会以最有效的方式显示。 你应用程序的整体用户体验可能不适合 Windows 主题的默认外观和感觉。

出于此原因，WPF 提供了各种机制来打造独特的用户体验。

### 内容模型

大多数 WPF 控件的主要用途是显示内容。 在 WPF 中，可以构成控件内容的项的类型和数目称为控件的 *内容模型*。 某些控件可以包含一种内容类型的一个项。 例如，[TextBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.textbox) 的内容是分配给 [Text](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.textbox.text) 属性的一个字符串值。

但是，其他控件可以包含不同内容类型的多个项；[Button](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.button) 的内容（由 [Content](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.contentcontrol.content) 属性指定）可以包含各种项，包括布局控件、文本、图像和形状。

有关各种控件支持的内容类型的详细信息，请参阅 [WPF 内容模型](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/controls/wpf-content-model?view=netdesktop-6.0)。

### 触发器

尽管 XAML 标记的主要用途是实现应用程序的外观，你也可以使用 XAML 来实现应用程序行为的某些方面。 其中一个示例是使用触发器来基于用户交互更改应用程序的外观。 有关详细信息，请参阅[样式和模板](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/controls/styles-templates-overview?view=netdesktop-6.0)。

### 模板

WPF 控件的默认用户界面通常是从其他控件和形状构造的。 例如， [Button](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.button) 由 [ButtonChrome](https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.windows.themes.buttonchrome) 和 [ContentPresenter](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.contentpresenter) 控件组成。 [ButtonChrome](https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.windows.themes.buttonchrome) 提供了标准按钮外观，而 [ContentPresenter](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.contentpresenter) 显示按钮的内容，正如 [Content](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.contentcontrol.content) 属性所指定。

有时，某个控件的默认外观可能与应用程序的整体外观冲突。 在这种情况下，可以使用 [ControlTemplate](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.controltemplate) 更改控件的用户界面的外观，而不更改其内容和行为。

###  数据模板

使用控件模板可以指定控件的外观，而使用数据模板则可以指定控件内容的外观。 数据模板经常用于改进绑定数据的显示方式。 下图显示 [ListBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.listbox) 的默认外观，它绑定到 `Task` 对象的集合，其中每个任务都具有名称、描述和优先级：

![具有默认外观的列表框](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/overview/media/index/data-template-listbox-normal.png?view=netdesktop-6.0)

默认外观是你对 [ListBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.listbox)的期望。 但是，每个任务的默认外观仅包含任务名称。 若要显示任务名称、描述和优先级，必须使用 [ListBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.listbox) 更改 [DataTemplate](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.datatemplate)控件绑定列表项的默认外观。 下面是一个示例，说明如何应用为 `Task` 对象创建的数据模板。

![使用数据模板的列表框](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/overview/media/index/data-template-listbox-applied.png?view=netdesktop-6.0)

[ListBox](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.listbox) 会保留其行为和整体外观；只有列表框所显示内容的外观发生变化。

有关详细信息，请参阅[数据模板化概述](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/data/data-templating-overview?view=netdesktop-6.0)。

### 样式

通过样式功能，开发人员和设计人员能够对其产品的特定外观进行标准化。 WPF 提供了一个强样式模型，其基础是 [Style](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.style) 元素。 样式可以将属性值应用于类型。 引用样式时，可以根据类型将其自动应用于所有对象，或应用于单个对象。 下面的示例创建一个样式，该样式将窗口上的每个 [Button](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.button) 的背景色设置为 `Orange`：

```xaml
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    x:Class="SDKSample.StyleWindow"
    Title="Styles">

    <Window.Resources>
        <!-- Style that will be applied to all buttons for this window -->
        <Style TargetType="{x:Type Button}">
            <Setter Property="Background" Value="Orange" />
            <Setter Property="BorderBrush" Value="Crimson" />
            <Setter Property="FontSize" Value="20" />
            <Setter Property="FontWeight" Value="Bold" />
            <Setter Property="Margin" Value="5" />
        </Style>
    </Window.Resources>
    <StackPanel>

        <!-- This button will have the style applied to it -->
        <Button>Click Me!</Button>

        <!-- This label will not have the style applied to it -->
        <Label>Don't Click Me!</Label>

        <!-- This button will have the style applied to it -->
        <Button>Click Me!</Button>
        
    </StackPanel>
</Window>
```

由于此样式针对所有 [Button](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.button) 控件，因此将自动应用于窗口中的所有按钮，如下图所示：

![两个橙色按钮](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/overview/media/index/styles-buttons.png?view=netdesktop-6.0)

有关详细信息，请参阅[样式和模板](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/controls/styles-templates-overview?view=netdesktop-6.0)。

###  资源

应用程序中的控件应共享相同的外观，它可以包括从字体和背景色到控件模板、数据模板和样式的所有内容。 你可以对用户界面资源使用 WPF 支持，以将这些资源封装在一个位置以便重复使用。

下面的示例定义 [Button](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.button) 和 [Label](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.label)共享的通用背景色：

XAML复制

```xaml
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    x:Class="SDKSample.ResourcesWindow"
    Title="Resources Window">

  <!-- Define window-scoped background color resource -->
  <Window.Resources>
    <SolidColorBrush x:Key="defaultBackground" Color="Red" />
  </Window.Resources>

  <!-- Button background is defined by window-scoped resource -->
  <Button Background="{StaticResource defaultBackground}">One Button</Button>

  <!-- Label background is defined by window-scoped resource -->
  <Label Background="{StaticResource defaultBackground}">One Label</Label>
</Window>
```

有关详细信息，请参阅[如何定义和引用 WPF 资源](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/systems/xaml-resources-how-to-define-and-reference?view=netdesktop-6.0)。

### 自定义控件

尽管 WPF 提供了大量自定义支持，但你仍可能会遇到现有 WPF 控件不满足你的应用程序或其用户的需求的情况。 出现这种情况的原因有：

- 不能通过自定义现有 WPF 实现的外观和感觉创建所需的用户界面。
- 现有 WPF 实现不支持（或很难支持）所需的行为。

但是，此时，你可以充分利用三个 WPF 模型中的一个来创建新的控件。 每个模型都针对一个特定的方案并要求你的自定义控件派生自特定 WPF 基类。 下面列出了这三个模型：

- **用户控件模型**
  自定义控件派生自 [UserControl](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.usercontrol) 并由一个或多个其他控件组成。
- **控件模型** 自定义控件派生自 [Control](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.control)，并用于生成使用模板将其行为与其外观分隔开来的实现，非常类似大多数 WPF 控件。 派生自 [Control](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.control) 使得你可以更自由地创建自定义用户界面（相较用户控件），但它可能需要花费更多精力。
- **框架元素模型**。
  当其外观由自定义呈现逻辑（而不是模板）定义时，自定义控件派生自 [FrameworkElement](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.frameworkelement) 。

有关自定义控件的详细信息，请参阅[控件创作概述](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/controls/control-authoring-overview?view=netdesktop-6.0)。