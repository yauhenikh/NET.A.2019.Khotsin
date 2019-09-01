-- Task 02
-- Write a query to display EmployeeID of the last
-- hired employee.

USE northwind;

SELECT EmployeeID
FROM Employees
WHERE HireDate = (SELECT MAX(HireDate)
FROM employees);