-- Task 07
-- Write a query to display the number of customer companies
-- located in three Scandinavian contries. The resulting
-- table should contain columns City and CustomerCount.

USE northwind;

SELECT City, COUNT(*) AS CustomerCount
FROM customers
WHERE Country IN ('Norway', 'Sweden', 'Finland')
GROUP BY City;