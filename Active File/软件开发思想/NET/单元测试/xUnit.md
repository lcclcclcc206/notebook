本教程演示如何生成包含单元测试项目和源代码项目的解决方案。 若要使用预构建解决方案学习本教程，请[查看或下载示例代码](https://github.com/dotnet/samples/tree/main/core/getting-started/unit-testing-using-dotnet-test/)。 有关下载说明，请参阅[示例和教程](https://learn.microsoft.com/zh-cn/dotnet/samples-and-tutorials/#view-and-download-samples)。

- ## 创建测试

  测试驱动开发 (TDD) 中的一种常用方法是在实现目标代码之前编写测试。 本教程使用 TDD 方法。 `IsPrime` 方法可调用，但未实现。 对 `IsPrime` 的测试调用失败。 对于 TDD，会编写已知失败的测试。 更新目标代码使测试通过。 你可以重复使用此方法，编写失败的测试，然后更新目标代码使测试通过。

  更新 PrimeService.Tests 项目：

  - 删除 PrimeService.Tests/UnitTest1.cs。
  - 创建 PrimeService.Tests/PrimeService_IsPrimeShould.cs 文件。
  - 将 PrimeService_IsPrimeShould.cs 中的代码替换为以下代码：

  ```csharp
  using Xunit;
  using Prime.Services;
  
  namespace Prime.UnitTests.Services
  {
      public class PrimeService_IsPrimeShould
      {
          [Fact]
          public void IsPrime_InputIs1_ReturnFalse()
          {
              var primeService = new PrimeService();
              bool result = primeService.IsPrime(1);
  
              Assert.False(result, "1 should not be prime");
          }
      }
  }
  ```

  `[Fact]` 属性声明由测试运行程序运行的测试方法。 从 PrimeService.Tests 文件夹运行 `dotnet test`。 [dotnet test](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-test) 命令生成两个项目并运行测试。 xUnit 测试运行程序包含要运行测试的程序入口点。 `dotnet test` 使用单元测试项目启动测试运行程序。

  测试失败，因为尚未实现 `IsPrime`。 使用 TDD 方法，只需编写足够的代码即可使此测试通过。 使用以下代码更新 `IsPrime`：

  ```csharp
  public bool IsPrime(int candidate)
  {
      if (candidate == 1)
      {
          return false;
      }
      throw new NotImplementedException("Not fully implemented.");
  }
  ```

运行 `dotnet test`。 测试通过。

### 添加更多测试

为 0 和 -1 添加素数测试。 可以复制在上一步中创建的测试，并复制以下代码以测试 0 和 -1。 但请不要这样做，因为有更好的方法。

```csharp
var primeService = new PrimeService();
bool result = primeService.IsPrime(1);

Assert.False(result, "1 should not be prime");
```

仅当参数更改代码重复和测试膨胀中的结果时复制测试代码。 以下 xUnit 属性允许编写类似测试套件：

- `[Theory]` 表示执行相同代码，但具有不同输入参数的测试套件。
- `[InlineData]` 属性指定这些输入的值。

可以不使用上述 xUnit 属性创建新测试，而是用来创建单个索引。 替换以下代码：

```csharp
[Fact]
public void IsPrime_InputIs1_ReturnFalse()
{
    var primeService = new PrimeService();
    bool result = primeService.IsPrime(1);

    Assert.False(result, "1 should not be prime");
}
```

替换为以下代码：

```csharp
[Theory]
[InlineData(-1)]
[InlineData(0)]
[InlineData(1)]
public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
{
    var result = _primeService.IsPrime(value);

    Assert.False(result, $"{value} should not be prime");
}
```

在前面的代码中，`[Theory]` 和 `[InlineData]` 允许测试多个小于 2 的值。 2 是最小的素数。

在类声明之后和 `[Theory]` 属性之前添加以下代码：

```csharp
private readonly PrimeService _primeService;

public PrimeService_IsPrimeShould()
{
    _primeService = new PrimeService();
}
```

运行 `dotnet test`，两项测试均失败。 若要使所有测试通过，请使用以下代码更新 `IsPrime` 方法：

```csharp
public bool IsPrime(int candidate)
{
    if (candidate < 2)
    {
        return false;
    }
    throw new NotImplementedException("Not fully implemented.");
}
```

遵循 TDD 方法，添加更多失败的测试，然后更新目标代码。 请参阅[已完成的测试版本](https://github.com/dotnet/samples/blob/main/core/getting-started/unit-testing-using-dotnet-test/PrimeService.Tests/PrimeService_IsPrimeShould.cs)和[库的完整实现](https://github.com/dotnet/samples/blob/main/core/getting-started/unit-testing-using-dotnet-test/PrimeService/PrimeService.cs)。

已完成的 `IsPrime` 方法不是用于测试素性的有效算法。