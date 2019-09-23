-- Task 05
-- Write a query to display the identifiers of the customer companies, for which 
-- orders were delivered (dbo.Orders.RequiredDate) in September 1996.
-- The list should be sorted in alphabetical order.

USE northwind;

SELECT DISTINCT CustomerID
FROM orders
WHERE RequiredDate BETWEEN '1996-09-01' AND '1996-09-30'
ORDER BY CustomerID;