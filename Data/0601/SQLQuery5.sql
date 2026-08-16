SELECT 
ProductID,
ProductName,
SupplierID,
UnitPrice
FROM Products
ORDER BY SupplierID DESC, UnitPrice DESC
--先照第一個欄位排序[SupplierID]再照第二個欄位[UnitPrice]排序，可以用很多個，每個欄位都可以DESC