WITH Emp_CTE AS (
    -- 【第一部分：錨點】大老闆本身就是路徑的起點
    SELECT 
        EmployeeID, 
        FirstName, 
        ReportsTo, 
        1 AS LEVEL,
        -- 因為大老闆是最頂層，他的路徑就只有他自己
        CAST(FirstName AS nvarchar(max)) AS EmployeePath
    FROM Employees
    WHERE ReportsTo IS NULL

    UNION ALL

    -- 【第二部分：遞迴】把主管的路徑拿過來，後面加上自己的名字
    SELECT 
        E.EmployeeID, 
        E.FirstName, 
        E.ReportsTo, 
        M.LEVEL + 1 AS LEVEL,
        -- 核心做法：主管的路徑 + '/' + 自己的名字
        CAST(M.EmployeePath + '/' + E.FirstName AS nvarchar(max)) AS EmployeePath
    FROM Employees E
    INNER JOIN Emp_CTE M ON E.ReportsTo = M.EmployeeID
)
-- 【最後輸出】
SELECT EmployeeID, FirstName, ReportsTo, LEVEL, EmployeePath
FROM Emp_CTE
ORDER BY LEVEL, EmployeeID;