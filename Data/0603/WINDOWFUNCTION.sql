SELECT
ProductID,
ProductName,
CategoryID,
UnitPrice,
--往前
LAG(UnitPrice) OVER (
PARTITION BY CategoryID
ORDER BY UnitPrice DESC
)AS LAGNO,
--往後(可帶參數)
LEAD(UnitPrice,3) OVER (
PARTITION BY CategoryID
ORDER BY UnitPrice DESC
)AS LEANNO,
--前減後
LAG(UnitPrice)OVER(
PARTITION BY CategoryID
ORDER BY UnitPrice DESC
)- UnitPrice AS DiffPrice,
FIRST_VALUE(UnitPrice) OVER (
PARTITION BY CategoryID
ORDER BY UnitPrice DESC
)AS FirstPrice,
LAST_VALUE(UnitPrice) OVER (
PARTITION BY CategoryID
ORDER BY UnitPrice
)AS LastPrice,
--最貴減最便宜
FIRST_VALUE(UnitPrice) OVER (
PARTITION BY CategoryID
ORDER BY UnitPrice DESC
)- FIRST_VALUE(UnitPrice) OVER (
PARTITION BY CategoryID
ORDER BY UnitPrice
) AS DiffPrice
FROM Products
ORDER BY CategoryID,UnitPrice DESC