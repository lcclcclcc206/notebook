## Select

SELECT 语句是最常用的 SQL 语句，它能帮助我们从一个或多个表中查询信息。查询是数据库中最常用的功能，因此我们选择它作为 SQL 语句学习的第一步。

SELECT 语句用于从数据库中选取数据，并将结果存储在一个临时结果表中，这个表称为结果集。结果集实际上也是一种包含行与列的表，只不过是未持久化的，即临时表。

基础语法如下：

```sql
SELECT `column_name`
FROM `table_name`;
```

> 反引号的作用是什么？
>
> 其实我们在命名字段的时候，字段名可能会与 SQL 关键字冲突，这时候要用反引号将列名和表名包含一下，避免关键字冲突。因此，在本课程所有小节的学习中，都会更加严谨地加上反引号。

### 查询多个列

当我们仅需要查询某一列的信息，且知道该列的列名时，可以使用简单的 SELECT COLUMN 的语句查询单个列来获取该列的信息。

当我们想要从一个表中查询多个列时，使用的 SELECT 语句与查询一个列时使用的语句相似，但是需要在 SELECT 关键字后给出多个列名，并且列名之间必须以逗号分隔。

语法：

```sql
SELECT `column_name_1`, `column_name_2`  
FROM `table_name`;
```

### 查询所有列

SELECT 语句可以直接检索表中所有信息，即检索所有的列。这可以通过在列名的位置使用星号（ * ）通配符来实现，输出的列的顺序一般是列在表定义中出现的物理顺序。

通配符是一类键盘字符，* (星号) 就是较为常用的通配符之一，可以使用 * 代替零个、单个或多个字符。
使用 * 通配符最大的优点就是，当不明确需要检索的列名时，可以通过检索所有列名来确定。

语法：

```sql
SELECT * FROM `table_name`;
```

### 查询不同行

有时候会遇到数据相同的情况。如果我们只想知道有哪些不同的值，即希望查询的值都是唯一不重复的，我们该怎么办呢？这时候我们就需要用到 DISTINCT 关键字。

语法：

```sql
SELECT DISTINCT `column_name`
FROM `table_name`
```

> DISTINCT 关键字需位于列名之前。

### 对行进行筛选过滤

在大多数情况下，我们只希望留下感兴趣的行而过滤掉不感兴趣的行，这时我们可以使用 WHERE 子句来帮助我们。SELECT WHERE 语句是筛选查询很重要的操作，WHERE 关键字后面加上条件可以过滤掉我们不需要信息，对查询效率有着很大的提高。

在使用 SELECT WHERE 语句检索表数据时，需要给出检索的表名 (table_name)、检索的列名 (column_name) 和操作符 (operator) 。

语法：

```sql
SELECT `column_name1`,`column_name2`…
FROM `table_name`
WHERE `column_name` operator `value`;
```

- column_name 对应指定列的名称，或者是多列，用逗号（ , ）分隔开

- table_name 对应查询表的名称

- operator 为操作符，常用的有等于 = 、小于 < 、大于 > 、不等于<> 或 !=，我们会在后续课程中更加深入地学习它。

## Insert

我们在学习了从表中查询数据后，如果希望在表中添加新的数据，那么该如何操作呢？这就需要用到我们的 INSERT INTO 语句了。

INSERT INTO 的第一种形式。这种形式，不需指定列名，只需提供要插入的数据即可，语法如下：

```sql
INSERT INTO `table_name`
VALUES (value1, value2, value3,...);
其中
```

value1, value2 …… 为对应插入数据表中的值，每个值的属性需要与对应表中的列名属性相匹配，而且需要把插入的信息填写完整，否则会报错。

### 在指定列中插入数据

INSERT INTO 的第二种形式。这种形式需要指定列名，语法如下： 

```sql
INSERT INTO `table_name`
(`column1`, `column2`, `column3`,...)
VALUES (value1, value2, value3,...);
```

其中 column1, column2 ... 为指定的列名，value1, value2 …… 为对应插入数据表中的值，每个值的属性需要与对应的列名属性相匹配。

## Update

在我们平时的使用中 UPDATE 语句，也是一种较常用的 SQL 语句，它可以用来更新表中已存在的记录。

我们在查询教师表 teachers 的时候发现，教师姓名 name 为 "Linghu Chong" 的老师邮箱 email 信息为 NULL，即没有该部分信息，我们现在希望更新邮箱信息，这时候就需要用到 UPDATE 语句。

语法

```sql
UPDATE `table_name`
SET `column1`=value1,`column2`=value2,...
WHERE `some_column`=some_value;
```

> 请注意 UPDATE 语句中的 WHERE 子句！WHERE 子句规定哪条记录或者哪些记录需要更新。如果您省略了 WHERE 子句，所有的记录都将被更新！

## Delete

前面我们学习了插入，更新语句，但总有一些数据是我们不需要的，在实际生活中，会员卡过期，银行卡销户之类的，都需要用到 DELETE 关键字对原有的数据进行删除，下面我们就来介绍一下。

示例代码

```sql
DELETE FROM `table_name`
WHERE `some_column` = `some_value`;
```

- table_name 代表表名称

- some_column 代表列名称，如 id

- some_value 可以为任意值。some_column 和 some_value 构成 WHERE 子句中的搜索条件。

> 请注意 SQL DELETE 语句中的 WHERE 子句。WHERE 子句规定哪条记录或者哪些记录需要删除。如果省略了 WHERE 子句，所有的记录都将被删除！