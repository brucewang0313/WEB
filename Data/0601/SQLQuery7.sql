SELECT
CustomerID,
CompanyName
FROM Customers
--WHERE ContactTitle LIKE '%Manager'
--%代表萬用字可加在開頭結尾
--WHERE ContactTitle LIKE '%ing%'
--WHERE CompanyName LIKE 'G_d%'
--底線代表一個字_
--WHERE CompanyName LIKE '[C-EI-M]%'
--代表[A-Z]代表範圍
--WHERE CompanyName LIKE '[bkgq]%'
WHERE CompanyName LIKE '[^bkgq-S]%'
-- ^代表不是
