SELECT
	CustomerID, 
	CompanyName
FROM Customers
WHERE  CompanyName LIKE '%\[TEST\]' ESCAPE'\'
--ESCAPE溢出字元可以自訂，因為單純用[TEST]會找不到