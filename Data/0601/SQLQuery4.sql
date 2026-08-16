SELECT
E1.EmployeeID,
E1.FirstName,
E2.EmployeeID,
E2.FirstName
FROM Employees E1
CROSS JOIN Employees E2
--CROSS JOIN配對 不管條件自己會跟自己配到
WHERE E1.EmployeeID<>E2.EmployeeID
--WHERE可新增搜尋的條件