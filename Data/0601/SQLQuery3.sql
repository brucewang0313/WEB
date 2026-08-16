SELECT 
E.EmployeeID,
E.FirstName,
E.ReportsTo,
BOSS.EmployeeID,
BOSS.FirstName
FROM Employees E
--INNER JOIN Employees BOSS ON E.ReportsTo=BOSS.EmployeeID
LEFT OUTER JOIN Employees BOSS ON E.ReportsTo=BOSS.EmployeeID
--為了顯示老闆REPORTS TO=NULL的值