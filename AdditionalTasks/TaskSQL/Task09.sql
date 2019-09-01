-- Task 09
-- Write a query to display average freight (dbo.Order.Freight) of orders
-- for customer companies, whose ship city located in United Kingdom or Canada,
-- An additional criterion is the average freight of an order - greater than or equal
-- to 100, or less than 10. The resulting table should contain columns
-- CustomerID and FreightAvg, average freight should be rounded to the integer,
-- results should be sorted in reverse order by average freight.

USE northwind;

SELECT CustomerID, ROUND(AVG(Freight), 0) AS FreightAvg
FROM orders
WHERE ShipCountry IN ('UK', 'Canada')
GROUP BY CustomerID
HAVING AVG(Freight) >= 100 OR AVG(Freight) < 10
ORDER BY FreightAvg DESC;