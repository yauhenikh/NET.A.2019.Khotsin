-- Task 03
-- Write a query to display all countries from the column
-- dbo.Customers.Country. The list should be sorted in alphabetical order
-- and should contain unique values without duplicates.

USE northwind;

SELECT DISTINCT Country
FROM customers
ORDER BY Country;