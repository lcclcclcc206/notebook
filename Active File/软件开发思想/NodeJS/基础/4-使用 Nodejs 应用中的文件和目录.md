## 包含“fs”模块

Node.js 提供了处理文件系统的内置模块。 它称为“fs”模块。 该名称是“file system”的缩写。

Node.js 中默认包含“fs”模块，因此你无需从 npm 进行安装。

这可能有点令人困惑，因为你无法在文件系统或“node_modules”文件夹中看到“fs”模块。 那么，如何在项目中包含“fs”模块呢？ 可以像引用任何其他依赖关系一样引用它。

“fs”模块具有 `promises` 命名空间，该命名空间具有所有方法的 promise 版本。 这是使用“fs”模块的首选方法，因为这样你可以使用 `async`。 它可避免回调发生混乱或避免阻止同步方法。

```javascript
const fs = require("fs").promises;
```

可以使用“fs”模块对文件和目录执行多种操作。 它有几种方法可供选择。

## 列出目录中的内容

使用“fs”模块时，经常执行的一项任务是列出或枚举目录中的内容。 例如，Tailwind Traders 有一个名为“stores”（门店）的根文件夹。 在该文件夹中，子文件夹是按门店编号组织的。 这些文件夹中是销售总额文件。 结构如下所示：

```
📂 stores
    📄 sales.json
    📄 totals.txt
    📂 201
    📂 202
```

若要通览文件夹的内容，可以使用 `readdir` 方法。 对“fs”模块执行的大多数操作都有同步和异步选项。

`readdir` 方法返回项列表：

```javascript
const items = await fs.readdir("stores");
console.log(items); // [ 201, 202, sales.json, totals.txt ]
```

`readdir` 和 `readdirsync` 方法按字母顺序返回结果。

## 确定内容类型

读取目录的内容时，会以字符串数组的形式返回文件夹和文件。 可以传入 `withFileTypes` 选项来确定哪些字符串是文件，哪些字符串是目录。 该选项将返回 `Dirent` 对象的数组，而不是字符串数组。 `Dirent` 对象具有 `isFile` 和 `isDirectory` 方法，可以使用这些方法来确定正在处理的对象的类型。

```javascript
const items = await fs.readdir("stores", { withFileTypes: true });
for (let item of items) {
  const type = item.isDirectory() ? "folder" : "file";
  console.log(`${item.name}: ${type}`);
  // 201: folder, 202: folder, sales.json: file, totals.txt: file
}
```

## 确定当前目录

有时，你不知道运行程序的目录是什么。 你需要让它只使用当前目录的路径。 Node.js 通过常量 `__dirname` 公开当前目录的完整路径。

```javascript
console.log(__dirname);
```

如果从下列文件夹结构的“sales”文件夹中运行该代码，则 `_dirname` 值将为 `/stores/201/sales`。

```
📂 stores
    📂 201
        📂 sales
```

## 使用路径 Path

路径是频繁出现的一个主题，Node.js 包含一个称为“path”的模块，专用于处理路径。

与“fs”模块一样，“path”模块随 Node.js 一起提供，无需安装。 只需要在文件顶部引用它即可。

```javascript
const path = require("path");
```

### 联接路径

“path”模块使用文件和文件夹路径的概念，这些路径就是一些字符串。 例如，如果想要获取“stores/201”文件夹的路径，可以使用 path 模块来执行此操作。	

```javascript
console.log(path.join("stores", "201")); // stores/201
```

使用“path”模块而不串联字符串的原因是，程序可能会在 Windows 或 Linux 上运行。 无论在什么操作系统上运行，“path”模块始终能够正确设置路径的格式。 在上面的示例中，`path.join` 会在 Windows 上返回 `stores\201`，且带有反斜杠而非斜杠。

### 确定文件扩展名

路径模块还可以标识文件扩展名。 如果你有一个文件，并且想要确定它是不是 JSON 文件，则可以使用 `path.extname` 方法。

```javascript
console.log(path.extname("sales.json"));
```

### 获取需要了解的有关文件或路径的所有信息

“path”模块包含许多不同的方法，这些方法可执行各种操作。 但是，可以使用 `parse` 方法获取有关路径或文件的大多数所需信息。 此方法返回一个对象，该对象包含你所在的当前目录、文件的名称、文件扩展名，甚至是不带扩展名的文件名称。

```javascript
console.log(path.parse("stores/201/sales.json"));
// { root: '', dir: 'stores/201', base: 'sales.json', ext: '.json', name: 'sales' }
```

“path”模块上有许多有用的实用工具方法，但这些是最常使用的核心概念。 在下一练习中，你将使用“path”模块来编写路径和标识 .json 文件。

## 创建目录

可使用 `mkdir` 方法创建目录。 下面的方法在“201”文件夹内创建一个名为“newDir”的文件夹。

```javascript
const fs = require("fs").promises;
const path = require("path");

await fs.mkdir(path.join(__dirname, "stores", "201", "newDir"));
```

请注意，“/stores/201”必须已经存在，否则此方法将失败。 如果文件结构不存在而你想要通过该操作创建它，则可以将其传入可选的 `recursive` 标志。

```javascript
await fs.mkdir(path.join(__dirname, "newDir", "stores", "201", "newDir"), {
  recursive: true
});
```

## 确保目录存在

如果尝试创建的目录已存在，`mkdir` 方法将引发错误。 这样不好，因为该错误会导致程序突然停止。 为了避免出现这种情况，Node.js 建议，如果计划在打开文件或目录后对其进行操作（我们是这样做的），请将 `mkdir` 方法包装在 `try/catch` 中。

```javascript
const pathToCreate = path.join(__dirname, "stores", "201", "newDirectory");

// create the salesTotal directory if it doesn't exist
try {
  await fs.mkdir(salesTotalsDir);
} catch {
  console.log(`${salesTotalsDir} already exists.`);
}
```

## 创建文件

可以通过使用 `fs.writeFile` 方法来创建文件。 此方法采用文件的路径和要写入该文件的数据。 如果此文件已存在，则会将其覆盖。

例如，此代码创建一个名为“greeting.txt”的文件，其中包含文本“Hello World!”。

```javascript
await fs.writeFile(path.join(__dirname, "greeting.txt"), "Hello World!");
```

如果省略第三个参数（即要写入到文件中的数据），Node.js 会将“undefined”写入文件。 这很可能不是你希望的。 若要编写空文件，请传递一个空字符串。 更好的选择是传递 `String` 函数，这会有效实现同样的目的，且代码中不会出现空引号。

```javascript
await fs.writeFile(path.join(__dirname, "greeting.txt"), String());
```

在下一练习中，你将使用有关如何创建文件和目录的知识来扩展程序，以创建用于存储所有销售文件的目录。

## 从文件读取数据

通过“fs”模块上的 `readFile` 方法读取文件。

JavaScript复制

```javascript
await fs.readFile("stores/201/sales.json");
```

`readFile` 方法的返回对象是一个 `Buffer` 对象。 它包含读取的文件的内容，但采用二进制格式。 例如，假设你有一个名为“sales.json”的文件，其中包含以下内容。

```
{
  "total": 22385.32
}
```

注销 `readFile` 方法的返回值后，你会得到 `Buffer` 值。

```javascript
console.log(await fs.readFile("stores/201/sales.json"));
// <Buffer 7b 0a 20 20 22 74 6f 74 61 6c 22 3a 20 32 32 33 38 35 2e 33 32 0a 7d>
```

这种结果并没有用。 你可能已读取该文件，但你当然是无法“阅读”此数据的。 但这不是问题。 JavaScript 可将 `Buffer` 值转换为可读取的字符串值。 为此，请调用 `String` 对象并传入缓冲区。

```javascript
const bufferData = await fs.readFile("stores/201/sales.json");
console.log(String(bufferData));
// {
//   "total": 22385.32
// }
```

## 分析文件中的数据

字符串格式的此数据并没有太大好处。 它仍然只是一些字符，但现在采用了一种可以读取的格式。 你希望能够将此数据分析为可通过编程方式使用的格式。

JavaScript 包含用于 JSON 文件的内置分析程序。 不需要包含任何内容即可使用它。 只需使用 `JSON` 对象即可。 还有一个好处就是，在分析 `Buffer` 值之前，无需将其转换为字符串。 `JSON.parse` 方法可以实现此目的。

```javascript
const data = JSON.parse(await fs.readFile("stores/201/sales.json"));
console.log(data.total);
// 22385.32
```

## 将数据写入文件

你在之前的练习中了解了如何编写文件。 只不过之前编写的是一个空文件。 要将数据写入文件，请使用相同的 `writeFile` 方法，不同的是应传入要作为第三个参数写入的数据。

```javascript
const data = JSON.parse(await fs.readFile("stores/201/sales.json"));

// write the total to the "totals.json" file
await fs.writeFile("salesTotals/totals.txt"), data.total);

// totals.txt
// 22385.32
```

在前面的示例中，每次对文件进行写入时，都会覆盖该文件。 有时无需这样做。 有时，只是需要将数据追加到文件；而不是完全替换。 可以将标志传递到 `writeFile` 方法来执行此操作。 默认情况下，标志设置为 `w`，表示“替换文件”。要改为追加到文件，请传递表示“追加”的 `a` 标志。

```javascript
const data = JSON.parse(await fs.readFile("stores/201/sales.json"));

// write the total to the "totals.json" file
await fs.writeFile(path.join("salesTotals/totals.txt"), `${data.total}\r\n`, {
  flag: "a"
});

// totals.json
// 22385.32
// 22385.32
```