SELECT
CustomerID,
Fax
FROM Customers
WHERE Fax IS NOT NULL
--NULL值不能用"="來判斷

