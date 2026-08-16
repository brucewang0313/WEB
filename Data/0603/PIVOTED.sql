--PIVOTED

SELECT Category,[1996],[1997],[1998]
FROM SalesData
PIVOT(
SUM(Quantity) FOR Orderyear IN([1996],[1997],[1998])
)AS PVT

SELECT Orderyear,[Dairy Products],[Grains/Cereals],[Seafood]
FROM SalesData
PIVOT(
SUM(Quantity) FOR Category IN([Dairy Products],[Grains/Cereals],[Seafood])
)AS PVT

SELECT * FROM SalesData

