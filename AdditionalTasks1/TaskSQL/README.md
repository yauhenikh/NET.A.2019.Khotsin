Used DBMS: MySQL.

Script to create Northwind database: [install_northwind_mysql.sql](install_northwind_mysql.sql).

- [Task 01](Task01.sql). Write a query to display a table with customers with columns CustomerID and CompanyName. Sort results by customer identifier.
- [Task 02](Task02.sql). Write a query to display EmployeeID of the last hired employee.
- [Task 03](Task03.sql). Write a query to display all countries from the column dbo.Customers.Country. The list should be sorted in alphabetical order and should contain unique values without duplicates.
- [Task 04](Task04.sql). Write a query to display names of customer companies located in te following cities: Berlin, London, Madrid, Bruxelles, Paris. The list should be sorted by customer identifier in reverse alphabetical order.
- [Task 05](Task05.sql). Write a query to display the identifiers of the customer companies, for which orders were delivered (dbo.Orders.RequiredDate) in September 1996. The list should be sorted in alphabetical order.
- [Task 06](Task06.sql). Write a query to display a contact name of the customer company, whose phone number starts with the code "171" and contains "77" and the fax number starts with the code "171" and ends with "50".
- [Task 07](Task07.sql). Write a query to display the number of customer companies located in three Scandinavian contries. The resulting table should contain columns City and CustomerCount.
- [Task 08](Task08.sql). Write a query to display the number of customer companies in countries, having 10 or more customers. The resulting table should contain columns Country and CustomerCount, results should be sorted in reverse order by the number of customers in the country.
- [Task 09](Task09.sql). Write a query to display average freight (dbo.Order.Freight) of orders for customer companies, whose ship city located in United Kingdom or Canada. An additional criterion is the average freight of an order - greater than or equal to 100, or less than 10. The resulting table should contain columns CustomerID and FreightAvg, average freight should be rounded to the integer, results should be sorted in reverse order by average freight.
- [Task 10](Task10.sql). Write a query to display EmployeeID of the last but one hired employee. Use subquery to exclude the last hired employee.
- [Task 11](Task11.sql). Write a query to display EmployeeID of the last but one hired employee. Use keywords OFFSET and FETCH.
- [Task 12](Task12.sql). Write a query to display the sum of freights for customer companies of orders, whose freight is greater than or equal to the average freight of all orders and the date of the shipment should be in the second half of July 1996. The resulting table should contain columns CustomerID and FreightSum, results should be sorted by sum of the freights.
- [Task 13](Task13.sql). Write a query to display 3 orders with the highest cost created after September 1, 1997 inclusive and were delivered to South America. The total cost is calculated as the sum of order details with discount. The resulting table should contain columns CustomerID, ShipCountry and OrderPrice, results should be sorted by order cost in reverse order.
- [Task 14](Task14.sql). Rewrite the query using grouping:
```
SELECT DISTINCT s.CompanyName,
(SELECT min(t.UnitPrice) FROM dbo.Products as t WHERE t.SupplierID = p.SupplierID) as MinPrice,
(SELECT max(t.UnitPrice) FROM dbo.Products as t WHERE t.SupplierID = p.SupplierID) as MaxPrice
FROM dbo.Products AS p
INNER JOIN dbo.Suppliers AS s ON p.SupplierID = s.SupplierID
ORDER BY s.CompanyName
```
- [Task 15](Task15.sql). Write a query to display customer companies from London, which placed orders with employees of the London office and placed delivery using Speedy Express shipper. The resulting table should contain columns Customer and Employee, Employee column should contain FirstName and LastName of the employee.
- [Task 16](Task16.sql). Write a query to display products of categories Beverages and Seafood, which are possible to order from suppliers (Discontinued) and number of units in stock is less than 20. The resulting table should contain columns ProductName, UnitsInStock, ContactName and Phone of the supplier. The results should be sorted by number of units in stock.

