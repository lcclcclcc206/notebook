[ar 归档 - lydstory - 博客园 (cnblogs.com)](https://www.cnblogs.com/hshy/p/12028141.html)

## 创建库文件

```bash
cd > a.o #创建库文件
ar cru liba.a a.o #创建一个库并把a.o添加进去
```

"c"关键字告诉ar需要创建一个新库文件，如果没有指定这个标志则ar会创建一个文件，同时会给出 一个提示信息，"u"用来告诉ar如果a.o比库中的同名成员要新，则用新的a.o替换原来的。



## 加入新成员

使用"ar -r liba.a b.o"即可以将b.o加入到liba.a中。默认的加入方式为append，即加在库的末尾。"r"关键字可以有三个修饰符"a", "b"和"i"。

- "a"表示after，即将新成员加在指定成员之后。例如"ar -ra a.c liba.a b.c"表示将b.c加入liba.a并放在已有成员a.c之后；
- "b"表示before，即将新成员加在指定成员之前。例如"ar -rb a.c liba.a b.c";
- "i"表示insert，跟"b"作用相同。



## 列出库中已有成员

"ar -t liba.a"即可。如果加上"v"修饰符则会一并列出成员的日期等属性。



## 删除库中成员

"ar -d liba.a a.c"表示从库中删除a.c成员。如果库中没有这个成员ar也不会给出提示。如果需要列出被删除的成员或者成员不存在的信息，就加上"v"修饰符。



## 从库中解出成员

"ar -x liba.a b.c"



## 调整库中成员的顺序

使用"m"关键字。与"r"关键字一样，它也有3个修饰符"a","b", "i"。如果要将b.c移动到a.c之前，则使用"ar -mb a.c liba.a b.c"



## 生成静态库文件

ar –rc test.a test.o 

