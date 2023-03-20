## INSERT INTO

The `INSERT INTO` statement is used to insert new records in a table.

It is possible to write the `INSERT INTO` statement in two ways:

1. Specify both the column names and the values to be inserted:

   ```SQL
   INSERT INTO table_name (column1, column2, column3, ...)
   VALUES (value1, value2, value3, ...);
   ```

2. If you are adding values for all the columns of the table, you do not need to specify the column names in the SQL query. However, make sure the order of the values is in the same order as the columns in the table. Here, the `INSERT INTO` syntax would be as follows:

   ```SQL
   INSERT INTO table_name
   VALUES (value1, value2, value3, ...);
   ```

## DELETE

The `DELETE` statement is used to delete existing records in a table.

```SQL
DELETE FROM table_name WHERE condition;
```

> Be careful when deleting records in a table! Notice the `WHERE` clause in the `DELETE` statement. The `WHERE` clause specifies which record(s) should be deleted. If you omit the `WHERE` clause, all records in the table will be deleted!

## UPDATE

The `UPDATE` statement is used to modify the existing records in a table.

```SQL
UPDATE table_name
SET column1 = value1, column2 = value2, ...
WHERE condition;
```

