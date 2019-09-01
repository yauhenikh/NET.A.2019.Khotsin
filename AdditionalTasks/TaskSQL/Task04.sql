-- Task 04
-- Write a query to display names of customer companies
-- located in te following cities: Berlin, London, Madrid, Bruxelles,
-- Paris. The list should be sorted by customer identifier in reverse
-- alphabetical order.

USE northwind;

SELECT CompanyName
FROM customers
WHERE City IN ('Berlin', 'London', 'Madrid', 'Bruxelles', 'Paris')
ORDER BY CustomerID DESC;