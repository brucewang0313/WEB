SELECT TOP 3
O.CustomerID
FROM [Order Details] OD
INNER JOIN Orders O ON OD.OrderID=O.OrderID
GROUP BY O.CustomerID
ORDER BY SUM(OD.UnitPrice*OD.Quantity*(1-OD.Discount)) DESC

UPDATE Customers
SET 
City='Taipei101'
WHERE CustomerID IN (
SELECT TOP 3
O.CustomerID
FROM [Order Details] OD
INNER JOIN Orders O ON OD.OrderID=O.OrderID
GROUP BY O.CustomerID
ORDER BY SUM(OD.UnitPrice*OD.Quantity*(1-OD.Discount)) DESC
)

SELECT * FROM Customers WHERE City='Taipei101'