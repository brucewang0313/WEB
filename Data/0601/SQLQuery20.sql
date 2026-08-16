INSERT INTO Table1(CompanyName,Fax)
SELECT 
*
FROM Shippers
WHERE Phone LIKE '(503)%'

