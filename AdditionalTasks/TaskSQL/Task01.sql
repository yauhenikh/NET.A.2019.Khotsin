-- Task 01
-- Write a query to display a table with customers with
-- columns CustomerID and CompanyName. Sort results
-- by customer identifier.

USE northwind;

SELECT CustomerID, CompanyName
FROM customers
ORDER BY CustomerID;