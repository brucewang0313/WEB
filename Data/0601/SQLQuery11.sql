SELECT
ProductID,
ProductName,
UnitPrice
FROM Products
WHERE UnitPrice <= 5 AND UnitPrice <= 10

SELECT
ProductID,
ProductName,
UnitPrice
FROM Products
WHERE UnitPrice BETWEEN 5 AND 10