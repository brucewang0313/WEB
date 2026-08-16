-- DERIVED TABLES
SELECT 
CustomerID,City,SalesAmount
FROM(
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
)T
WHERE SalesAmount >= 10000