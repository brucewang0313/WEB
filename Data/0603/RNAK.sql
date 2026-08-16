SELECT
ProductID,
ProductName,
CategoryID,
UnitPrice,
--編號會依據內容兩個同名下一名會跳過變+2
RANK() OVER (
PARTITION BY CategoryID 
ORDER BY UnitPrice DESC
) AS RANKno,
--編號會依據內容兩個同名下一名+1
DENSE_RANK() OVER (
PARTITION BY CategoryID 
ORDER BY UnitPrice DESC
) AS RANKnoDENSE,
--編號不管內容
ROW_NUMBER() OVER (
PARTITION BY CategoryID 
ORDER BY UnitPrice DESC
) AS NO,
--均分 分成幾組
NTILE(3) OVER (
PARTITION BY CategoryID 
ORDER BY UnitPrice DESC
) AS TILENO
FROM Products