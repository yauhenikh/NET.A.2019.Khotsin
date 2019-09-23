-- Task 12
-- Write a query to display the sum of freights for customer companies
-- of orders, whose freight is greater than or equal to 
-- the average freight of all orders and the date of the shipment
-- should be in the second half of July 1996. The resulting table
-- should contain columns CustomerID and FreightSum, results
-- should be sortde by sum of the freights.

USE northwind;

SELECT CustomerID, SUM(Freight) AS FreightSum
FROM orders
WHERE Freight >= (SELECT AVG(Freight) FROM orders AS subOrders
		 WHERE subOrders.CustomerID = orders.CustomerID)
AND ShippedDate BETWEEN '1996-07-16' AND '1996-07-31'
GROUP BY CustomerID
ORDER BY FreightSum;