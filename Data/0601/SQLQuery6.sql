SELECT
CustomerID,
City
FROM Customers
--WHERE City ='London'OR City='Paris'OR City='Berlin'
-- 上下兩式相等
--WHERE City IN('London','Paris','Berlin')
--也可以用 NOT取之外的
WHERE City NOT IN('London','Paris','Berlin')