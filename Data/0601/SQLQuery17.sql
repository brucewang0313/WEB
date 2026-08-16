SELECT 
CustomerID,
Country,
Region,
City,
--Country+N' '+Region+N' '+City
--若上述程式有空值則整個會變成NULL
--Country+ISNULL(' '+Region,'')+' '+City
--CONCAT格式
CONCAT(Country,(' '+Region),(' '+City))
FROM Customers