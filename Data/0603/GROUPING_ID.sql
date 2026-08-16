SELECT
	CategoryID, 
	GROUPING_ID(CategoryID),--判斷是不是依照CategoryID來判斷是的話是0
	SupplierID,
	GROUPING_ID(SupplierID),
	AVG(UnitPrice)
FROM Products
GROUP BY CUBE(CategoryID, SupplierID)
ORDER BY CategoryID, SupplierID