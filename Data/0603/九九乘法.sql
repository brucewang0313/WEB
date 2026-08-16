DECLARE @no1 int = 2; -- 外層迴圈變數（被乘數）
DECLARE @no2 int;     -- 內層迴圈變數（乘數）
DECLARE @row nvarchar(max); -- 用來暫存「同一橫排」的字串

-- 外層迴圈：控制 @no1 從 2 跑到 9
WHILE @no1 < 10
BEGIN
    SET @no2 = 1;
    SET @row = ''; 

    WHILE @no2 < 10
    BEGIN
        SET @row = @row 
                 + CAST(@no1 AS nvarchar) + ' x ' 
                 + CAST(@no2 AS nvarchar) + ' = ' 
                 + CAST((@no1 * @no2) AS nvarchar) 
                 + CHAR(9);
        SET @no2 = @no2 + 1;
    END
    PRINT @row;
    SET @no1 = @no1 + 1;
END