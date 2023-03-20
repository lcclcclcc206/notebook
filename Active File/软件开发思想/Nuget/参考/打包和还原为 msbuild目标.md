## 打包许可证表达式或许可证文件

使用许可证表达式时，请使用该 `PackageLicenseExpression` 属性。 有关示例，请参阅 [许可证表达式示例](https://github.com/NuGet/Samples/tree/main/PackageLicenseExpressionExample)。

```xml
<PropertyGroup>
    <PackageLicenseExpression>MIT</PackageLicenseExpression>
</PropertyGroup>
```

若要详细了解 .org 接受 NuGet的许可证表达式和许可证，请参阅 [许可证元数据](https://learn.microsoft.com/zh-cn/nuget/reference/nuspec#license)。

打包许可证文件时，使用 `PackageLicenseFile` 属性指定包路径，相对于包的根目录。 此外，请确保文件包含在包中。 例如：

```xml
<PropertyGroup>
    <PackageLicenseFile>LICENSE.txt</PackageLicenseFile>
</PropertyGroup>

<ItemGroup>
    <None Include="licenses\LICENSE.txt" Pack="true" PackagePath=""/>
</ItemGroup>
```

有关示例，请参阅 [许可证文件示例](https://github.com/NuGet/Samples/tree/main/PackageLicenseFileExample)。

一次只能指定其中一个`PackageLicenseExpression``PackageLicenseFile``PackageLicenseUrl`

### 打包没有扩展名的文件

在某些情况下，例如打包许可证文件时，可能需要包含没有扩展名的文件。 出于历史原因， NuGet&MSBuild 将没有扩展的路径视为目录。

```xml
  <PropertyGroup>
    <TargetFrameworks>netstandard2.0</TargetFrameworks>
    <PackageLicenseFile>LICENSE</PackageLicenseFile>
  </PropertyGroup>

  <ItemGroup>
    <None Include="LICENSE" Pack="true" PackagePath=""/>
  </ItemGroup>  
```

[没有扩展示例的文件](https://github.com/NuGet/Samples/blob/main/PackageLicenseFileExtensionlessExample/)。