--可以帶參數的VIEW，FUNCTION
CREATE OR ALTER FUNCTION OrderSummaryByDateRange(
@BEGIN_DATE DATETIME, @END_DATE DATETIME
)
RETURNS TABLE
AS
RETURN
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
	WHERE OrderDate >= @BEGIN_DATE AND OrderDate < DATEADD(d,1,@END_DATE)
	GROUP BY c.CustomerID,	c.CompanyName,c.City,	o.OrderID,o.OrderDate
 GO

 SELECT * FROM OrderSummaryByDateRange('19970501','19970531')