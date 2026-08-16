--CREATE建立 或 ALTER修改 若是只寫CREATE按第二次就會錯誤
CREATE OR ALTER VIEW OrderSummary --OrderSummary裡面儲存的是SQL語法，不是儲存資料(VIEW)，好處是不用重複寫一樣的語法
AS
	SELECT
		c.CustomerID,
		c.CompanyName,
		c.City,
		o.OrderID,
		o.OrderDate,
		SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS SalesAmount
	FROM Customers c
	INNER JOIN Orders o ON o.CustomerID = c.CustomerID
	INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
	GROUP BY c.CustomerID,	c.CompanyName,c.City,	o.OrderID,o.OrderDate
 GO

 SELECT * FROM OrderSummary
 WHERE SalesAmount >= 10000

 SELECT * FROM OrderSummary
 WHERE OrderDate >= '19980401' AND OrderDate <'19980501'