SELECT
ProductID,
ProductName,
CategoryID,
UnitPrice,
SUM(UnitPrice) OVER (
PARTITION BY CategoryID --依照CategoryID的類別加總
ORDER BY UnitPrice DESC
ROWS BETWEEN 2 PRECEDING 
AND CURRENT ROW
) AS TOTALPRICE
FROM Products