-- Task 14
-- Rewrite the query using grouping:
-- SELECT DISTINCT s.CompanyName,
-- (SELECT min(t.UnitPrice) FROM dbo.Products as t WHERE t.SupplierID = p.SupplierID) as MinPrice,
-- (SELECT max(t.UnitPrice) FROM dbo.Products as t WHERE t.SupplierID = p.SupplierID) as MaxPrice
-- FROM dbo.Products AS p
-- INNER JOIN dbo.Suppliers AS s ON p.SupplierID = s.SupplierID
-- ORDER BY s.CompanyName

USE northwind;

SELECT s.CompanyName, MIN(p.UnitPrice) AS MinPrice,
MAX(p.UnitPrice) AS MaxPrice
FROM products AS p
INNER JOIN suppliers AS s ON p.SupplierID = s.SupplierID
WHERE s.CompanyName IS NOT NULL
GROUP BY s.CompanyName
ORDER BY s.CompanyName;