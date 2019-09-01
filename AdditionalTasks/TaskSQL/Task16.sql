-- Task 16
-- Write a query to display products of categories Beverages
-- and Seafood, which are possible to order from suppliers (Discontinued) and
-- number of units in stock is less than 20. The resulting table should
-- contain columns ProductName, UnitsInStock, ContactName and Phone of the supplier.
-- The results should be sorted by number of units in stock.

USE northwind;

SELECT p.ProductName, p.UnitsInStock, s.ContactName, s.Phone
FROM products AS p
INNER JOIN categories AS c
ON p.CategoryID = c.CategoryID
INNER JOIN suppliers AS s
ON p.SupplierID = s.SupplierID
WHERE c.CategoryName IN ('Beverages', 'Seafood')
AND p.Discontinued = 0
AND p.UnitsInStock < 20
ORDER BY p.UnitsInStock;