SELECT 
ProductID,
ProductName,
UnitPrice,
CASE 
	WHEN UnitPrice <= 5 THEN '便便便'
	WHEN UnitPrice <= 10 THEN '普普普'
	ELSE '貴貴貴'
END AS LEVEL, 
CASE 
	WHEN UnitPrice <= 5 THEN 1  --因為是數字不用''
	WHEN UnitPrice <= 10 THEN 0.8
	ELSE 0.6
END 
AS DISCOUNT, 
CASE 
	WHEN UnitPrice <= 5 THEN UnitPrice * 1
	WHEN UnitPrice <= 10 THEN UnitPrice * 0.8
	ELSE UnitPrice * 0.6
END 
AS NEWPRICR
FROM Products