CREATE OR ALTER PROCEDURE LookupProducts(
	@min_price money = 0, @max_price money=999999999 --可以設定預設值
)
AS
BEGIN
	SELECT * FROM Products
	介於兩數之間
	WHERE UnitPrice BETWEEN @min_price AND @max_price
END
GO
 
EXEC LookupProducts 10, 50
EXEC LookupProducts @min_price=40 --named parameter 要有預設值才能帶

