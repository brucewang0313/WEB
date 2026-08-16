SELECT 
OrderID,
OrderDate
FROM Orders
--WHERE OrderDate >='1997-07-01'AND OrderDate<'1997-08-01'
--用最後一天加一天來找特定日期，因為會有時間上的考量：可用"/"、"-"、直接輸入八碼數字
WHERE OrderDate >='19960801'AND OrderDate<'19960901'
--也可以寫成下面
SELECT 
OrderID,
OrderDate
FROM Orders
WHERE YEAR(OrderDate)=1996 AND MONTH(OrderDate)=8
