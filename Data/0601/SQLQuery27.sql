SELECT
	p.CategoryID,
	(
	SELECT CategoryName FROM Categories WHERE CategoryID = P.CategoryID
	),
	p.SupplierID,
	(
	SELECT CompanyName FROM Suppliers WHERE SupplierID=P.SupplierID
	),
	MIN(p.UnitPrice) AS MinPrice,
	MAX(p.UnitPrice) AS MaxPrice,
	AVG(p.UnitPrice) AS AvgPrice,
	(
	SELECT 
	SUM(UnitPrice*Quantity*(1-Discount)) 
	FROM [Order Details] 
	WHERE ProductID=P.ProductID
	) AS SaleAmount
FROM Products p
GROUP BY p.CategoryID, p.SupplierID,P.ProductID
HAVING AVG(p.UnitPrice) >= 5
ORDER BY p.CategoryID, p.SupplierID