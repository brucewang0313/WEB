--FROM後面有空格的要用[]起來

SELECT 
*,
UnitPrice*Quantity*(1-Discount) AS SubTotal
FROM [Order Details]
