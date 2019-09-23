-- Task 13
-- Write a query to display 3 orders with the highest cost
-- created after September 1, 1997 inclusive and were delivered
-- to South America. The total cost is calculated as the sum
-- of order details with discount. The resulting table should
-- contain columns CustomerID, ShipCountry and OrderPrice, results
-- should be sorted by order cost in reverse order.

USE northwind;

SELECT CustomerID, ShipCountry, (SELECT ROUND(SUM(UnitPrice * Quantity * (1 - Discount)), 2)
FROM order_details
WHERE orders.OrderID = order_details.OrderID
GROUP BY order_details.OrderID) AS OrderPrice
FROM orders
WHERE ShipCountry IN ('Argentina', 'Bolivia', 'Brazil',
 'Chile', 'Colombia', 'Equador', 'Guyana', 'Paraguay',
 'Peru', 'Suriname', 'Uruguay', 'Venezuela')
AND OrderDate >= '1997-09-01'
AND ShippedDate IS NOT NULL
ORDER BY OrderPrice DESC
LIMIT 3;