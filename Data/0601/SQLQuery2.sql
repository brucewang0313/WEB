SELECT 
C.CustomerID,
C.CompanyName,
O.OrderID,
O.OrderDate
FROM Customers C
LEFT OUTER JOIN Orders O ON O.CustomerID=C.CustomerID
--依左邊為主去跟右邊比對，比對不到還是會留下來