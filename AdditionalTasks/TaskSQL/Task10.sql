-- Task 10
-- Write a query to display EmployeeID of the last but one
-- hired employee. Use subquery to exclude the last hired
-- employee.

USE northwind;

SELECT EmployeeID
FROM employees 
WHERE HireDate = (SELECT MAX(HireDate) 
FROM employees 
WHERE HireDate < (SELECT MAX(HireDate) 
FROM employees));