-- Task 08
-- Write a query to display the number of customer companies in countries,
-- having 10 or more customers. The resulting table should contain
-- columns Country and CustomerCount, results should be sorted
-- in reverse order by the number of customers in the country.

USE northwind;

SELECT Country, COUNT(*) AS CustomerCount
FROM customers
GROUP BY Country
HAVING CustomerCount >= 10
ORDER BY CustomerCount DESC;