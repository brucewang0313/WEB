--作業要抓出每個表的各兩個欄位
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