SELECT
COUNT(*),
COUNT(Fax),
--計算Fax不是NULL的數量
COUNT(*)-COUNT(Fax)--沒有Fax的客戶數量
FROM Customers