SELECT
ProductID,
ProductName,
CategoryID,
SupplierID,
UnitPrice,
AVG(UnitPrice) OVER (
PARTITION BY CategoryID --PARTITION BY 分割的意思
) AS AvgPriceByCaTegory,
AVG(UnitPrice) OVER (
PARTITION BY SupplierID
) AS AvgPriceBySupplier
FROM Products