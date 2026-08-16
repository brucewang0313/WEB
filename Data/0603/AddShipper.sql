CREATE OR ALTER PROCEDURE AddShipper(
	@name nvarchar(5), @phone varchar(50)
)
AS
BEGIN
	INSERT INTO Shippers(CompanyName, Phone)
	VALUES(@name, @phone)
END
GO
 
EXEC AddShipper 'Fedex', '04-9876543'
 
SELECT * FROM Shippers