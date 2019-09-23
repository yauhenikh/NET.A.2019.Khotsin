-- Task 06
-- Write a query to display a contact name of the customer company,
-- whose phone number starts with the code "171" and contains "77"
-- and the fax number starts with the code "171" and ends with "50".

USE northwind;

SELECT ContactName
FROM customers
WHERE Phone LIKE '(171)%'
AND Phone LIKE '%77%'
AND Fax LIKE '(171)%'
AND Fax LIKE '%50';