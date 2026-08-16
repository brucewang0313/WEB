SELECT 
P.CategoryID,
P.SupplierID,
C.CategoryName,
S.CompanyName,
MAX(P.UnitPrice)AS MAXPRICE,
MIN(P.UnitPrice)AS MINPRICE,
AVG(P.UnitPrice)AS AVGPRICE
FROM Products P
INNER JOIN Categories C ON P.CategoryID=C.CategoryID
INNER JOIN Suppliers S ON S.SupplierID=P.SupplierID
--在這一行新增C.CategoryName才能看到上面要的C.CategoryName,不然會報錯
GROUP BY P.CategoryID,C.CategoryName,S.CompanyName,P.SupplierID
--分類完之後的WHERE判斷就用HAVING，不然原本WHERE要放在JOIN後面
HAVING AVG(P.UnitPrice)>=5
ORDER BY P.CategoryID,P.SupplierID