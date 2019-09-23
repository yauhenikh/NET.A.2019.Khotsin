-- Task 11
-- Write a query to display EmployeeID of the last but one
-- hired employee. Use keywords OFFSET and FETCH.

USE northwind;

SELECT EmployeeID
FROM employees 
ORDER BY HireDate DESC
LIMIT 1
OFFSET 1;