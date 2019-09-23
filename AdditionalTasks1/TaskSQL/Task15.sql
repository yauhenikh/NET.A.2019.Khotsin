-- Task 15
-- Write a query to display customer companies from London,
-- which placed orders with employees of the London office and placed 
-- delivery using Speedy Express shipper. The resulting table should
-- contain columns Customer and Employee, Employee column should contain
-- FirstName and LastName of the employee.

USE northwind;

SELECT DISTINCT c.CompanyName AS Customer, CONCAT(e.FirstName, ' ', e.LastName) AS Employee
FROM customers AS c
INNER JOIN orders AS o
ON c.CustomerID = o.CustomerID
INNER JOIN employees AS e
ON o.EmployeeID = e.EmployeeID
INNER JOIN shippers AS sh
ON o.ShipVia = sh.ShipperID
WHERE c.City = 'London'
AND e.City = 'London'
AND sh.CompanyName = 'Speedy Express';