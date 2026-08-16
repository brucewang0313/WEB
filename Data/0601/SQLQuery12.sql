--前12個(TOP 12) WITH TIES是指跟後面相同的單價都會列出來
SELECT TOP 12 WITH TIES
ProductID,
ProductName,
UnitPrice
FROM Products
ORDER BY UnitPrice