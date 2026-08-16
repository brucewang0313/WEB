SELECT
	CategoryID, 
	SupplierID,
	AVG(UnitPrice)
FROM Products
--完全不分類->再依照CategoryID分類->再依照SupplierID分類
GROUP BY ROLLUP(CategoryID, SupplierID)
ORDER BY CategoryID, SupplierID