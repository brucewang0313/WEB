SELECT 
P.ProductID,
P.ProductName,
P.CategoryID,
C.CategoryName,
P.UnitPrice,
S.CompanyName AS Supplier
FROM Products P --P代表Products的別名
INNER JOIN Categories C ON P.CategoryID = C.CategoryID --ON後面代表條件
INNER JOIN Suppliers S ON P.SupplierID = S.SupplierID

SELECT 
CategoryID,
CategoryName
FROM Categories

SELECT 
C.CustomerID,
C.CompanyName,
O.OrderID,
O.EmployeeID,
N.Discount,
N.ProductID,
N.Quantity,
N.UnitPrice,
P.ProductName
FROM Customers C 
INNER JOIN Orders O ON C.CustomerID=O.CustomerID
INNER JOIN [Order Details] N ON O.OrderID=N.OrderID
INNER JOIN Products P ON N.ProductID=P.ProductID

