SELECT
	CategoryID, 
	SupplierID,
	AVG(UnitPrice)
FROM Products
GROUP BY CUBE(CategoryID, SupplierID)
ORDER BY CategoryID, SupplierID