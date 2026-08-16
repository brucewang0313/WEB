--CTE可以省略一樣的段落C

WITH t1 AS (
	SELECT
		ProductID,
		ProductName,
		UnitPrice,
		CASE 
			WHEN UnitPrice <= 5 THEN 1
			WHEN UnitPrice <= 10 THEN 0.8
			ELSE 0.6
		END AS Discount
	FROM Products
)
SELECT 
	*,
	CASE 
		WHEN UnitPrice <= 5 THEN '便宜'
		WHEN UnitPrice <= 10 THEN '普通'
		ELSE '很貴'
	END AS Level,
	UnitPrice * Discount AS NewPrice
FROM t1