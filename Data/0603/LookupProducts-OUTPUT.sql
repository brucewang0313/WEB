CREATE OR ALTER PROCEDURE LookupProducts(
	@min_price money = 0, @max_price money = 9999999999
)
AS
BEGIN
	DECLARE @no int
 
	SELECT @no = COUNT(*) FROM Products
	WHERE UnitPrice BETWEEN @min_price AND @max_price
 
	SELECT * FROM Products
	WHERE UnitPrice BETWEEN @min_price AND @max_price
 
	RETURN @no
END
GO

--另一種寫法

--DECLARE @count int
--EXEC @count = LookupProducts 5, 20
--PRINT @count

--CREATE OR ALTER PROCEDURE LookupProducts(
--	@min_price money = 0, @max_price money = 9999999999, @no int OUTPUT
--)
--AS
--BEGIN
--	SELECT @no = COUNT(*) FROM Products
--	WHERE UnitPrice BETWEEN @min_price AND @max_price
 
--	SELECT * FROM Products
--	WHERE UnitPrice BETWEEN @min_price AND @max_price
--END
--GO
 
--DECLARE @count int
--EXEC LookupProducts 5, 20, @count OUTPUT
--PRINT @count