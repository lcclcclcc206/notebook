## 编译链接基础简介

在讲解本节实验之前，我们需要先简单了解下 C/C++ 程序的大致构建流程，它主要分为：预编译、编译和链接三个阶段，而这三个阶段会使用不同的工具去处理。

- 预编译：使用预编译器去处理 C/C++ 源文件中头文件、宏定义等。
- 编译：使用编译器对处理后的 C/C++ 源文件进行源码编译生成 `.o` 对象文件。
- 链接：使用链接器将编译生成的 `.o` 对象文件进行完整链接生成最终的可执行文件。

大致的编译链接流程可以参考下图。

![1](https://doc.shiyanlou.com/courses/2764/27526/6795acf26e4f15326f1d9970f80db3bd-1)

从图中，我们可以看到链接器除了会去链接所有 `.o` 对象文件外，如果提供了 `.a` 静态库和 `.so` 动态库，那么链接器也会对它们进行链接。

通常我们使用的一些第三方 C/C++ 库以及系统库，都是通过静态库或者动态库的方式提供，这两者的区别在于：

- 静态库：链接后会直接把里面所有的代码都合并生成到可执行程序中。
- 动态库：链接后仅仅将动态库中导出的函数提供给可执行程序调用，实际运行过程中，还是会单独加载这个动态库。

因此，使用静态库完整链接后的程序大小通常比使用动态库的程序大很多，但这也有自己的优势，就是依赖少、便于升级维护和部署。



### 编译器和链接器

目前市面上常用的编译器有：gcc，clang，msvc 等，而这里主要使用 gcc 作为我们的编译器，可以在之前的 hello 工程下执行 `xmake -rv` 查看当前使用的编译器和链接器。

![2](https://doc.shiyanlou.com/courses/2764/27526/f6f5131977f1e9118e9b0d28bbff65e1-0)

从上图可以看出，gcc 就是我们当前使用的编译器，它可以直接编译 `.cpp` 源文件到 `.o` 文件，而 `g++` 就是我们使用的链接器，用来将所有生成的 `.o` 文件链接成可执行文件。

其中需要注意的是，其实 `g++` 也仅仅只是个编译器前端，它实际上会去内部调用真实的 `ld` 链接器程序，相比直接使用 `ld`，我们使用 `g++` 来链接的一个好处是，它会自动搜索和链接内置提供的 libc++ 等依赖库，这会省事不少，也更通用，否则如果直接使用 `ld` 的话，那么我们只能自己处理对这些依赖的搜索路径等配置选项了。

而关于实际的内部链接器，比较常用的有 ld.bfd、ld.gold 和 lld，其中 bfd 用的最多，而 lld 是 llvm 新出的链接器，链接速度更加快，关于这块细节与本实验关系不大，就不再过多展开讨论了。



## xmake.lua 基础配置

接下来，我们开始逐一介绍 xmake 的配置文件 xmake.lua 里面的一些基础配置接口使用方式，只要大概掌握了这些配置，基本上常规的 C/C++ 项目编译和维护都能快速搞定了。



### 配置目标类型

首先，我们来介绍下 xmake 支持的几种基础目标类型，目前主要也就是四种类型。

| 值     | 描述       |
| ------ | ---------- |
| phony  | 空目标程序 |
| binary | 二进制程序 |
| static | 静态库程序 |
| shared | 动态库程序 |



### 可执行程序类型

比如我们之前一直在用的可执行目标程序类型 `binary`，可以通过 `set_kind("binary")` 来设置，如下面的配置。

```lua
target("hello")    
	set_kind("binary")    
	add_files("src/*.cpp") 
```



### 静态库程序类型

我们接下来尝试编译生成一个带有静态库的目标程序，直接使用 xmake 来创建个空工程，例如。

```bash
cd ~/Code
xmake create -t static hello_static
```

`-t static` 参数用于指定当前工程类型为静态库，后面是工程项目名，生成后的项目结构如下。

![图片描述](https://doc.shiyanlou.com/courses/2764/600404/26ce1f0bc2d4ab2c3e64991386dfb579-0)

其中，项目根目录下还是会自动生成一个 xmake.lua 用于维护整个项目构建，而 src 源码目录下 `interface.cpp` 就是用来参与静态库编译，`main.cpp` 用来生成可执行程序，在里面调用静态库的接口。

我们可以进入 hello_static 项目根目录后，执行 `gvim ./xmake.lua` 查看下里面的内容，大致如下。

![4](https://doc.shiyanlou.com/courses/2764/27526/50281287c151a7b38d0d7ecf585a28d2-0)

里面有两个编译目标，通过 `target()` 定义维护，一个是 static 静态库类型，一个是 binary 可执行程序类型，它们之间通过 `add_deps("hello_static")` 进行依赖关联，这样 xmake 在编译的时候，会优先编译依赖的静态库，并且把静态库自动集成到对应的可执行程序上去。

执行 `xmake` 对这个工程进行编译，如果输出结果跟下图基本一致，说明我们成功生成了一个链接静态库的目标程序。

![5](https://doc.shiyanlou.com/courses/2764/27526/4de8234eedd78b4da1331687d4b5a336-0)

然后我们执行 `xmake run` 运行下这个程序。

![6](https://doc.shiyanlou.com/courses/2764/27526/3af8597a38cce093c496ea1084e04e5a-0)





### 动态库程序类型

动态库的创建跟静态库类似，只需要把类型名改成 `shared` 就行了，例如。

```bash
cd ~/Code
xmake create -t shared hello_shared
```

生成的工程结构和 xmake.lua 内容都跟静态库的基本一致，唯一的区别就是目标类型变成了 `shared`。

```lua
add_rules("mode.debug", "mode.release")

target("hello_shared")
    set_kind("shared") -- 设置为动态库目标程序
    add_files("src/interface.cpp")

target("hello_shared_demo")
    set_kind("binary")
    add_deps("hello_shared")
    add_files("src/main.cpp")
```

然后我们执行下编译和运行。

```bash
cd hello_shared
xmake
xmake run
```

编译运行结果也跟静态库基本一致。

![7](https://doc.shiyanlou.com/courses/2764/27526/5e07dc323beadec5332bff84c2dc2584-0)



### Phony 目标类型

其中，phony 是一个特殊的目标程序类型，使用它定义的 target 目标不会生成任何实际的程序文件，也不会执行任何编译操作，通常用于组合其它目标程序的依赖关系，实现关联编译。

为了更好的理解 phony 类型，我们这回手工创建个带有 phony 目标的工程进行测试，首先创建个空目录。

```bash
cd ~/Code
mkdir phony_test
cd phony_test
```

然后执行 `vim ./xmake.lua` 编辑 xmake.lua 写入下面的内容。

```lua
target("foo")
    set_kind("phony")
```

可以看到，这边我们没有添加任何源文件，这个 foo 目标仅仅只是个空目标程序，执行编译也是空执行，不会有任何源文件参与编译。

![8](https://doc.shiyanlou.com/courses/2764/27526/6eb55fd3da9f7044dcb1ca8cf2c4593a-0)

而关于使用 phony 目标跟其它目标程序的关联编译，我们会在实验 6 《xmake 基础之目标依赖》中详细讲解。



## 添加 C/C++ 编译选项

在实验 2 《xmake 的基本命令使用》中，我们介绍了通过命令行的方式快速添加 C/C++ 编译选项，不过这种方式不适合永久保存和对外发布，仅仅用于本地编译。如果我们想将自己的项目发布后提供给其他用户编译，那么就需要在 xmake.lua 中去设置这些编译选项。

进入之前创建的 hello 程序目录，然后使用 `vim xmake.lua` 编辑里面的 xmake.lua 文件，修改成如下内容。

```lua
add_rules("mode.debug", "mode.release")

target("hello")
    set_kind("binary")
    add_files("src/*.cpp")
    add_cxflags("-DTEST1")
```

通过 `add_cxflags("-DTEST1")` 设置就能对所有的 C/C++ 代码定义上 `TEST1` 宏开关，然后通过执行 `xmake -v` 查看完整编译命令中，是否真的生效了。

![9](https://doc.shiyanlou.com/courses/2764/27526/e8cce8f2cdf89db44a61e712fbd9d9db-0)

上图中，我们确实可以看到 `-DTEST1` 被传递到了 gcc 编译器进行宏定义。

另外在上图中，我们还看到了一些编译选项的自动检测，这是由于通过 `add_cxflags()` 等设置接口添加的选项都是特定某些编译器的，并不一定是完全跨编译通用的，因此 xmake 会去检测用户的设置，如果不支持的选项被设置进去，xmake 会检测失败并提示警告信息然后忽略它。



### 添加宏定义

除了可以通过 `add_cxflags` 方式添加宏定义，其实 xmake 还提供了内置的配置接口 `add_defines` 去更方便设置它，这个配置接口相比 `add_cxflags` 使用原始编译选项的方式更加的通用，跨编译器，也是我们更加推荐的配置方式。这个接口会自动处理各种编译的支持方式，所以不会触发 flags 的自动检测机制，更加的快速可靠。

我们还是基于之前的 hello 项目的配置，做一些修改，通过 `add_defines("TEST2")` 添加新的宏定义开关 `TEST2`。

```lua
add_rules("mode.debug", "mode.release")

target("hello")
    set_kind("binary")
    add_files("src/*.cpp")
    add_cxflags("-DTEST1")
    add_defines("TEST2")
```

然后，我们重新执行 `xmake -v` 去编译查看新增的宏定义是否生效，如图。

![10](https://doc.shiyanlou.com/courses/2764/27526/7c5bb8721171913ac459409760248b40-0)

从图中，我们可以看出，相比之前的输出，新增加了一个 `-DTEST2` 宏定义参数选项传入了 gcc，说明我们的配置确实生效了。



### 头文件路径和链接库配置

make 也提供了方便的配置接口去配置头文件搜索路径、链接库、库搜索路径，分别是如下几个接口。

- `add_includedirs`：添加头文件搜索目录。
- `add_linkdirs`：添加库搜索目录。
- `add_links`：添加链接库。
- `add_syslinks`：添加系统链接库。

上述几个接口都是跨编译器配置，相比直接设置到 ldflags 更加的通用。至于 `add_syslinks` 和 `add_links` 这两个的区别就是：`add_syslinks` 通常用于添加一些系统依赖库，比如 pthread，这样 xmake 会把这些系统库链接放置的更靠后些。这是因为链接器在处理库链接时候，是会依赖顺序的，放置在最左边的链接会优先处理，例如 libfoo 库依赖 libpthread 库中的符号，那么我们必须严格按照这个顺序添加链接库依赖 `-lfoo -lpthread`，否则链接器就会报找不到 pthread 库符号的错误。

而链接库和头文件搜索路径，顾名思义，就是设置后告诉编译器、链接器应该从这些目录位置尝试查找指定的链接库和头文件。

继续配置 hello 工程中的 `xmake.lua` 文件。

```lua
add_rules("mode.debug", "mode.release")

target("hello")
    set_kind("binary")
    add_files("src/*.cpp")
    add_cxflags("-DTEST1")
    add_defines("TEST2")
    add_links("z")
    add_syslinks("pthread")
    add_linkdirs("/tmp")
    add_includedirs("/tmp")
```

然后执行 `xmake -v` 查看编译输出，里面的红框部分就是新设置的编译选项：

- `-I/tmp`：添加头文件搜索路径。
- `-L/tmp`：添加链接库搜索路径。
- `-lz -lpthread`：添加的链接库，由于我们是通过 `add_links` 添加的 zlib 库，而 pthread 库是作为系统库添加的，所以被放置在 pthread 的左边优先链接。

![11](https://doc.shiyanlou.com/courses/2764/27526/e39af17e83f3a839cf7aadc012ad0f70-0)



### 设置语言标准

我们可以使用 `set_languages` 接口设置目标代码编译时候的语言标准，比如是基于 c99 标准，还是 c++11、c++14 标准等。

目前 xmake 支持的语言标准主要有以下几个：

| 值      | 描述                    |
| ------- | ----------------------- |
| ansi    | c 语言标准: `ansi`      |
| c89     | c 语言标准: `c89`       |
| gnu89   | c 语言标准: `gnu89`     |
| c99     | c 语言标准: `c99`       |
| gnu99   | c 语言标准: `gnu99`     |
| c++98   | c++ 语言标准: `c++98`   |
| gnu++98 | c++ 语言标准: `gnu++98` |
| c++11   | c++ 语言标准: `c++11`   |
| gnu++11 | c++ 语言标准: `gnu++11` |
| c++14   | c++ 语言标准: `c++14`   |
| gnu++14 | c++ 语言标准: `gnu++14` |
| c++1z   | c++ 语言标准: `c++1z`   |
| gnu++1z | c++ 语言标准: `gnu++1z` |
| c++17   | c++ 语言标准: `c++17`   |
| gnu++17 | c++ 语言标准: `gnu++17` |

并且 c 标准和 c++ 标准可同时进行设置，例如：

```lua
-- 设置 c 代码标准：c99， c++ 代码标准：c++11
set_languages("c99", "c++11")
```

将这个配置添加到刚刚修改的 xmake.lua 文件中去，就跟上一节的配置方式一样，放置到 `target("hello")` 配置域下面，然后执行 `xmake -v` 看下编译输出结果。

![12](https://doc.shiyanlou.com/courses/2764/27526/35f4b7d3a34c05ccc62c7c86159b000a-0)

由于当前没 C 代码，所以实际只有 C++11 的标准设置生效了，也就是上图红框位置的编译选项 `-std=c++11`。



### 设置编译优化

其实，xmake 默认创建的工程 xmake.lua 文件中，已经设置了 `add_rules("mode.debug", "mode.release")` 这两个编译规则，而默认 xmake 编译就是 release 模式编译，它会开启所有内置的编译优化选项，并不需要用户设置什么。

![13](https://doc.shiyanlou.com/courses/2764/27526/9ce81350b7740ae9abd6509ee2d8da3c-0)

上图红框的部分都是编译优化相关的一些选项，比如最直接的 `-O3` 优化，还有 `-fvisibility=hidden -fvisibility-inlines-hidden` 用于去重一些符号字符串数据，使得编译后的程序更小。

当然，我们也可以不使用 xmake 提供的内置编译规则，自己控制应该如何优化编译，比如继续改成下面配置。

```lua
target("hello")
    set_kind("binary")
    add_files("src/*.cpp")
    add_cxflags("-DTEST1")
    add_defines("TEST2")
    add_links("z")
    add_syslinks("pthread")
    add_linkdirs("/tmp")
    add_includedirs("/tmp")
    set_languages("c99", "c++11")
    if is_mode("release") then
        set_optimize("fastest")
        set_strip("all")
        set_symbols("hidden")
    end
```

我们去除了 `mode.release` 的编译规则，通过 `is_mode("release")` 自己判断和控制优化编译，可以达到跟之前一样的优化效果。

其中 `set_optimize("fastest")` 就是添加 `-O3` 的编译优化开关，而 `set_strip("all")` 和 `set_symbols("hidden")` 用于去掉调试符号数据，使得程序更小。

配置完成以后再执行 `xmake -v` 看看，最后的编译输出里面这些编译优化选项还是同样存在的。



### 添加源文件

在本实验最后，再讲解下如何添加源文件参与编译，其实之前的配置中，我们已经大概知道，可以通过使用 `add_files` 接口来添加源文件，这里进一步了解下这个配置接口的使用。

其实这个接口还是很强大的，不仅仅支持单个源文件的添加，还可以支持通过模式匹配的方式批量添加源文件，并且支持同时添加不同语言的源文件，不过这里主要讲解对 C/C++ 源文件的添加。

我们先来看个实例，简单了解下用法。

```lua
add_files("src/test_*.c", "src/**.cpp")
```

其中通配符 `*` 表示匹配当前目录下源文件，而 `**` 则递归匹配多级目录下的源文件。

在之前的配置中，我们是用 `add_files("src/*.cpp")` 仅仅匹配 src 单级目录下的 c++ 源文件，现在有了大致的了解后，编辑 hello/xmake.lua 文件来实验如何递归添加源文件，将该文件改为下面的配置。

```lua
add_rules("mode.debug", "mode.release")

target("hello")
    set_kind("binary")
    add_files("**.cpp")
```

然后我们在 `hello/src/test` 目录下，通过下面的命令新创建一个 C++ 的空代码文件，用来测试验证递归模式匹配。

```bash
cd ~/Code/hello
mkdir -p src/test
touch src/test/stub.cpp
```

创建好后执行 `xmake` 编译工程，如果顺利就可以看到新添加的 stub.cpp 文件也参与了编译，如下图。

![14](https://doc.shiyanlou.com/courses/2764/27526/7826a1a02f632ddfc65a68cb5012b57c-0)



### 过滤源文件

模式匹配的方式虽然很方便，但如果源码目录层级结构复杂，在添加过程中，需要排除一些不需要的文件时，就不是那么灵活了，不过 xmake 也提供了在模式匹配过程中排除一批文件的方式，同样还是这个配置接口，我们只需要通过 `|` 符号指定后面的排除匹配模式即可，例如。

```lua
target("hello")
    set_kind("binary")
    add_files("src/**.cpp|test/*.cpp")
```

其中分隔符 `|` 之后的都是需要排除的文件，这些文件也同样支持匹配模式，并且可以同时添加多个过滤模式，只要中间用 `|` 分割就行了，而这里的配置就是在 `src/**.cpp` 基础上，忽略掉其中 `test` 子目录下所有的 C++ 源文件，最终的结果也就是仅仅编译 `src/main.cpp`。

我们再来执行下 `xmake -r` 重新编译验证下结果，如下图。

![15](https://doc.shiyanlou.com/courses/2764/27526/1fffc429e83c688a883f3512419d9666-0)

上图中，可以看到我们成功过滤掉了 `src/test/stub.cpp` 仅仅编译 `src/main.cpp`。

还有需要注意的一点是，为了使得描述上更加的精简，`|` 之后的过滤描述都是基于前一个模式：`src/**.cpp` 中 `*` 所在的目录作为根目录，也就是 `src` 目录的基础上来过滤匹配的，所以后面的过滤子模式只需要设置 `test/*.cpp` 而不是 `src/test/*.cpp`。



## C/C++ 依赖库介绍

C/C++ 库不像其它新的高级语言那样官方提供好用的依赖包管理和集成，整个生态比较杂乱不统一，集成起来非常的不方便，这也是 C/C++ 开发的痛点之一。

我们经常需要到处找库，研究如何编译、安装它们，并且如何去集成使用，如果需要跨平台，遇到的问题可能还更多点，为了集中管理这些依赖包，现在市面上已经有不少成熟的第三方包管理器来维护和解决这些问题，比如：conan，vcpkg，homebrew 等等，不过我们还是需要有一种更加方便的集成方式将其与我们的 C/C++ 项目工程进行关联集成，才能使用它们。

为此，xmake 内置了对这些第三方包管理仓库的集成，另外 xmake 还有自己的包依赖仓库来更好的解决依赖包集成问题。



### 直接集成使用系统库

首先，我们先从最简单的集成方式开始，尝试直接集成系统中已经安装的第三方库，由于 zlib 库在大多数 Linux 系统环境中都是内置了的，并且在本实验环境也是已经存在的，那么我们就先从集成 zlib 库开始实验。

由于 zlib 是 C 库，为了方便起见，这回我们来创建一个 C 工程来尝试它，只需要在创建工程的时候指定下语言即可，例如。

```bash
cd ~/Code
xmake create -l c crc32
```

`-l c` 参数指定当前创建的 crc32 工程是基于 C 语言的，其目录结构如下，跟之前的 hello 项目很相似，仅仅只是 `main.cpp` 源文件变成了 `main.c`。

![1](https://doc.shiyanlou.com/courses/2764/27526/a05183d1a967b3542ce02f42dde97ec9-0)

进入 `crc32` 目录中，执行 `vim src/main.c` 编辑源文件，编写一个简单实用、使用 zlib 库中 `crc32()` 接口去计算 crc32 的例子，代码如下。

```c
#include <stdio.h>
#include <zlib.h>

int main(int argc, char** argv)
{
    printf("crc32: %x!\n", crc32(0, argv[1], strlen(argv[1])));
    return 0;
}
```

上述代码通过计算输入字符串内容的 crc32 值，然后回显输出到终端上，我们先尝试下直接执行 `xmake` 命令去编译它。

![2](https://doc.shiyanlou.com/courses/2764/27526/c54ce38d76f600527b21fc69b7aa6b7f-0)

通过上图，我们看到编译链接阶段报错了，缺少 `crc32` 符号，这是因为我们还没集成链接 zlib 库，继续修改 xmake.lua 文件手动加上 zlib 库以及它系统库搜索路径。

```lua
target("crc32")
    set_kind("binary")
    add_files("src/*.c")
    add_links("z")
    add_linkdirs("/usr/lib/x86_64-linux-gnu")
```

然后重新执行 `xmake` 编译这个工程，这回看到编译通过了。

![3](https://doc.shiyanlou.com/courses/2764/27526/753ae6438fecb35e2aa6790b3d760361-0)

如果我们执行 `xmake -rv` 命令，是可以看到详细编译输出里面已经带上了 `-L/usr/lib/x86_64-linux-gnu -lz` 的库链接选项。

注：这里没有额外添加头文件搜索路径，是因为 `zlib.h` 是在 `/usr/include` 目录下，这个目录 xmake 会内置自动添加对应的 `-I` 选项到 gcc。

![4](https://doc.shiyanlou.com/courses/2764/27526/d601e96ec7b350b3940f5cb360188c87-0)

接下来，我们尝试执行下面的命令运行这个程序。

```bash
xmake run crc32 somedata
```

如果运行正常，会看到类似下面的运行结果，说明我们已经正常集成使用了系统自带的 zlib 库。

![5](https://doc.shiyanlou.com/courses/2764/27526/99590274624424105b8c30b3b438028f-0)



### 自动查找系统库

在上节中，我们通过 `add_linkdirs("/usr/lib/x86_64-linux-gnu")` 方式来集成系统依赖库，虽然可以使用但不是非常通用，因为带有 xmake.lua 的 C/C++ 项目有可能会在其它 Linux 环境甚至在其它系统上编译，zlib 库并不一定安装在这个目录下。

为了更加通用化的适配系统库路径，可以使用 `find_packages` 来自动查找 zlib 库所在的位置，通过这种方式集成之前，我们可以先尝试直接执行下面的命令，来探测 zlib 库的位置信息，对这个接口返回的信息有个大概的了解。

```bash
xmake l find_packages zlib
```

如果我们成功找到系统路径下安装的 zlib 库，那么会看到类似下图的结果。

![图片描述](https://doc.shiyanlou.com/courses/2764/600404/37ae4573514eff6a84187455f8bcc018-0)

里面有链接库名、链接库的搜索路径，有可能还会有头文件的搜索路径等信息，因此我们只需要把这些信息自动探测到后设置到对应的目标程序中，就可以实现自动集成安装在系统环境的依赖库了。

接下来，我们继续修改 xmake.lua，在 target 定义下面新增一个 `on_load()` 脚本块，在里面调用 `find_packages("zlib")` 将探测到的 zlib 库信息直接动态设置到 target 里面去就行了，如下配置代码。

```lua
target("crc32")
    set_kind("binary")
    add_files("src/*.c")
    add_links("z")
    add_linkdirs("/usr/lib/x86_64-linux-gnu")
    on_load(function (target)
        target:add(find_packages("zlib"))
    end)
```

修改完成后执行 `xmake -rv`，其编译输出应该跟之前的输出完全一致才对。

不过需要注意的一点是：xmake 默认会缓存依赖包的检测结果，并不是每次编译都会重新检测，如果之前检测失败，那么结果也会缓存，这个时候我们可以执行 `xmake f -c` 在配置时候，忽略之前的缓存内容，就会自动重新触发各种检测。

![4](https://doc.shiyanlou.com/courses/2764/27526/d601e96ec7b350b3940f5cb360188c87-0)



## 远程库下载集成

我们现在虽然能够自动检测和集成系统环境的 C/C++ 库，但是如果需要的库在当前环境中还没有安装，那么还是需要手动的去安装它们，如果有些库安装非常复杂容易出错，那么整个过程也是很折腾的。

因此 xmake 提供了依赖包的自动远程下载以及安装集成功能，它不仅支持 conan、vcpkg、homebrew 等第三方包管理仓库，还支持自建的分布式私有包管理仓库，并且 xmake 也提供了官方的 [C/C++ 包仓库](https://github.com/xmake-io/xmake-repo)。

其大致流程可以通过下面这个图来直观的了解。

![7](https://doc.shiyanlou.com/courses/2764/27526/308009fc6eea85743abe41e97cc60d73-0)

如果暂时看不懂上图的流程，没有关系，我们先来个简单的例子体验下如何远程下载依赖包并把它集成到项目中去，还是拿之前的 zlib 为例，我们先假设当前系统环境中没有这个库存在，想要从网上拉取对应版本进行集成。

还是拿之前的 crc32 工程做下修改，编辑里面的 xmake.lua 文件，修改为下面的内容。

```lua
add_requires("zlib", {system = false})

target("crc32")
    set_kind("binary")
    add_files("src/*.c")
    add_packages("zlib")
```

其中 `add_requires()` 接口指定当前项目需要哪些包，配置这个编译时候会触发一次依赖包的安装，而 `add_packages()` 用来配置对特定 target 目标集成指定的依赖包，这两者需要配合使用，缺一不可。

接下来，执行 `xmake` 重新来编译项目，如果出现下面的提示信息，说明我们配置的 `zlib` 包有在官方仓库中被收录，并且当前平台支持这个依赖包的集成。

如果安装完成并且编译成功会显示下面的信息。

![图片描述](https://doc.shiyanlou.com/courses/2764/600404/c6d3c0fbcc9427ea787c82c686bccb98-0)

需要注意的一点是，上面的配置中我们额外加上了 `{system = false}` 是因为当前的实验环境中已经存在了 zlib 库，所以 `add_requires("zlib")` 默认会优先自动检测系统环境中的 zlib 库，如果存在就直接使用，也就是内置了 `find_packages("zlib")` 的逻辑。

而这里出于演示远程下载的逻辑，我们通过配置 `{system = false}` 强制触发远程下载，人为忽略了系统库的探测逻辑，在实际项目中，大家可根据自己的需求来决定是否配置这个选项。

另外一个注意事项是，我们的包检测结果都是有本地缓存的，第二次编译并不会再触发依赖包的下载安装，会直接参与集成编译。

所以再次执行 `xmake -rv` 重新编译看看，这次并不会再去安装 zlib 库了，同样可以正常集成 zlib 来重新编译项目，效果如图。

![9](https://doc.shiyanlou.com/courses/2764/27526/5a098d59fc91cbee44f0a0f04a5f7d0a-0)

上图中红线部分就是我们从远程仓库集成的 zlib 库头文件和链接信息。



### 卸载和重装依赖包

如果我们想要卸载之前的依赖包，只需要执行卸载命令。

```bash
xmake require --uninstall zlib
```

如果看到下图，说明已经成功卸载了安装包。

![10](https://doc.shiyanlou.com/courses/2764/27526/a3bb42bbecb4b8c0eb5c5828d0ab184a-0)

不过需要注意的是，虽然卸载了包，但是当前项目的配置缓存还在，如果继续执行 `xmake` 命令，还是会使用缓存的 zlib 包信息。

因此可以添加 `-c` 参数给 `xmake config`，也就是执行下 `xmake f -c` 命令，强制忽略缓存配置，触发依赖包的重新检测逻辑。

由于 xmake.lua 中还是配置了 zlib 包依赖，因此这次会触发重新安装逻辑（不过不会再重新下载了，而是直接解压安装之前缓存的 zlib 包），效果如图。

![图片描述](https://doc.shiyanlou.com/courses/2764/600404/4d691d5278b4ed5ecf4d1432894e7702-0)



### 语义版本设置

xmake 的依赖包管理是完全支持语义版本选择的，例如："~1.6.1"，对于语义版本的具体描述见：https://semver.org/。

这里，我们在之前的 xmake.lua 基础上，新增两个依赖库，并且设置上不同的语义版本，例如。

```lua
add_requires("zlib", {system = false})
add_requires("tbox 1.6.*", "pcre2 >10.0")

target("crc32")
    set_kind("binary")
    add_files("src/*.c")
    add_packages("zlib", "tbox", "pcre2")
```

其中 [tbox 库](https://github.com/tboox/tbox) 我们会集成匹配 `1.6` 下面的所有可用子版本，而 pcre2 正则库我们会集成匹配 `>10.0` 的可用版本。配置好后，继续执行 `xmake` 安装依赖库编译，如果一切顺利，会看到类似下面的结果输出。

![图片描述](https://doc.shiyanlou.com/courses/2764/600404/ec17829315411b65bdf2620a0bc74a2d-0)

再来执行 `xmake -rv` 查看完整命令输出，看看是否真的集成上了这两个库。

![13](https://doc.shiyanlou.com/courses/2764/27526/180a63868e4e68ec8eab0c57d700e5d5-0)

上图红框部分，就是我们新下载集成的两个依赖库的路径和编译链接选项，说明我们已经顺利集成上了，至于 C 代码里面如何去使用它们，这里就不再过多介绍了，大家在实验后可以自行研究。

当然，如果我们对当前的依赖包的版本没有特殊要求，那么也可以不设置版本，xmake 会默认拉取安装当前可以获得的最新版本包。

如果当前依赖包有 git 仓库，也可以集成 git 仓库的 `master/dev` 分支依赖包，只需要把版本号换成对应的分支名就行了，例如。

```lua
add_requires("tbox master")
add_requires("tbox dev")
```

后续编译操作跟之前的类似，这里就不再重复实验了。



### 查看依赖库信息

我们可以执行下面的命令，快速查看通过 `add_requires("zlib")` 配置的依赖包信息，比如查看实际的安装路径、缓存目录、可选配置信息等。

```bash
xmake require --info zlib
```

相关的包信息说明可以参考下面的图片。

![14](https://doc.shiyanlou.com/courses/2764/27526/854df30bf6d0b501080cae667db8dcdb-0)



## Conan 仓库依赖包的集成

虽然 xmake 内置的包仓库功能已经很完善，但毕竟生态还没完全建立起来，收录的包还不是很多，如果用户需要的 C/C++ 依赖包在我们的包仓库中找不到，那么还可以直接集成使用第三方仓库中提供的包，例如：Conan、Vcpkg、Homebrew 等仓库，xmake 都是支持的。

这里我们来重点尝试下集成 Conan 中提供的包，因为相比 Vcpkg、Homebrew 等仓库，Conan 支持更加完善，不仅自身跨平台，提供的包也是支持多个不同平台的，收录的包数量也非常多。

在使用 [Conan](https://conan.io/) 之前，首先需要安装它到系统环境中，由于 conan 是基于 python 的，因此可以通过 pip 工具来安装它，只需要执行下面的命令。

```bash
sudo pip install --upgrade pip
sudo pip install conan
source ~/.profile
```

然后我们可以通过执行 `conan --version` 确认下是否安装成功，如果成功，我们会看到对应的版本信息，如图。

![图片描述](https://doc.shiyanlou.com/courses/2764/600404/cb007cef65df38649f5f2d6a368e664d-0)

接下来，使用 vim 编辑之前的 crc32/xmake.lua 文件，改成如下配置。

```lua
add_requires("CONAN::zlib/1.2.11@conan/stable", {alias = "zlib"})

target("crc32")
    set_kind("binary")
    add_files("src/*.c")
    add_packages("zlib")
```

这里我们使用 `CONAN::` 作为 conan 包仓库的命名空间，让 xmake 将其作为 conan 依赖包来处理后续的探测、下载和安装逻辑。xmake 内部会自动调用 conan 去安装指定的 zlib 包，并且集成进来，因此这里的 `zlib/1.2.11@conan/stable` 包描述格式也是完全基于 conan 自身的规范，大家可以直接到 [conan 官方文档](https://docs.conan.io/en/latest/using_packages/conanfile_txt.html#requires) 查看如何设置。

而后面的 `{alias = "zlib"}` 部分是 `add_requires` 接口对于每个包的扩展配置，这里 alias 用来设置包的别名，方便之后每个 target 中更加精简的去集成，例如：`add_packages("zlib")`，而不是每次都是用全名。

配置完成后，执行 `xmake` 去编译这个集成了 conan 依赖包的项目，整个依赖包的下载安装流程，跟之前完全一致，如图。

![图片描述](https://doc.shiyanlou.com/courses/2764/600404/7bf090db28cbba13a5dd35c7fb0117f8-0)

如果安装成功，可以继续执行 `xmake -rv` 来查看 xmake 实际链接的 conan 包路径信息。

![17](https://doc.shiyanlou.com/courses/2764/27526/cf6f6b2d7930d3782459425fff3bf90c-0)

通过上图可以看到，xmake 直接引用了安装在 conan 自身仓库目录下的 zlib 库，说明整个集成流程已经通过。
