--CAST可以轉亂型別CAST(欄位名稱 AS 型別)
SELECT 
ProductName + ' is $' + CAST(UnitPrice AS nvarchar(50)) + '. There are only ' + CAST(UnitsInStock AS nvarchar(5)) + ' left in stock.',
*
FROM Products

--CONVERT()也可以轉換型態
