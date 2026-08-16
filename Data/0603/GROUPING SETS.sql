SELECT
	CategoryID, 
	SupplierID,
	AVG(UnitPrice)
FROM Products
--相當於用CategoryID和用SupplierID分類
GROUP BY GROUPING SETS(CategoryID, SupplierID,())
ORDER BY CategoryID, SupplierID