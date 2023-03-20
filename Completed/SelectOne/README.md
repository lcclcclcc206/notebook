## 可以优化的目标

- [x] 程序实现完全最大化并且不能更改大小，并且程序可以最小化

```xaml
<Window .....
        Height="1080" Width="1920" MinHeight="1080" MinWidth="1920"
        ResizeMode="CanResize" WindowState="Maximized" WindowStyle="SingleBorderWindow">
```

- [ ] 可以通过快捷键来触发抽选
  - [ ] 按 Esc 退出程序
  - [ ] 按 Space 开始抽选
- [ ] 程序拥有配置文件
- [ ] 项目重构，模块化
- [ ] 美化UI界面
- [ ] 使界面不受分辨率，缩放影响
- [ ] 给抽选添加音效

## 程序目前的问题

- [ ] 调试状态下，在屏幕的帧率为 144hz 时程序会出现卡顿现象
- [ ] DispatcherTimer性能问题，使用其他方式进行UI更新

## 通过这个程序可以衍生出来的知识点

- WPF 程序的布局类型，如何使用这些布局类型
- WPF 中高频率更新UI的方案
- WPF 常用控件使用
- WPF 调试 Xaml 代码
- C# 文件操作
- WPF 显示弹窗