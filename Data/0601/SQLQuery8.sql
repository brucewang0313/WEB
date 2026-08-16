SELECT 
CustomerID,
Phone
FROM Customers
WHERE Phone LIKE '_3%[37]____'
--電話第二碼是3倒數第五碼是3或7
ORDER BY Phone