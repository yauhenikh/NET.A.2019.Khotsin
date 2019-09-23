Find out the cardinality for the relationships between the PK Table (the table that contains the primary key of the entity) and the FK Table (the table that contains the foreign key of the entity). Fill in the Cardinality columns in the table. Find out the type of relationship between the database tables. Fill in the Relationship column in the table above.

| PK Table      | Cardinality PK Table | FK Table             | Cardinality FK Table | Relationship |
| ------------- | -------------------- | -------------------- | -------------------- | ------------ |
| shippers      | Zero-or-One          | orders               |  One-or-Many         | One-to-Many  |
| employees     | Zero-or-One          | orders               |  One-or-Many         | One-to-Many  |
| employees     | Zero-or-One          | employees            |  One-or-Many         | One-to-Many  |
| employees     | -                    | territories          | -                    | Many-to-Many |
| customers     | Zero-or-One          | orders               |  One-or-Many         | One-to-Many  |
| customers     | -                    | customerdemographics | -                    | Many-to-Many |
| orders        | One-and-only-One     | orderdetails         |  One-or-Many         | One-to-Many  |
| products      | One-and-only-One     | orderdetails         |  One-or-Many         | One-to-Many  |
| suppliers     | Zero-or-One          | products             |  One-or-Many         | One-to-Many  |
| categories    | Zero-or-One          | products             |  One-or-Many         | One-to-Many  |
| region        | One-and-only-One     | territories          |  One-or-Many         | One-to-Many  |

Create a new collection in Postman with the name Northwind, in this collection create such requests to the Northwind OData Service that will satisfy the description in the table below. After checking the request, enter the necessary parameters in the table. Create at least 5 more queries and write them in the table.

| Query Description                                             | HTTP Verb | Url                                       |
| --------------------------------------------------------------| --------- | ----------------------------------------- |
| Get service metadata.                                         | GET       | /$metadata                                |
| Get all customers.                                            | GET       | /Customers                                |
| Get a customer with "ALFKI" id.                               | GET       | /Customers('ALFKI')                       |
| Get all orders.                                               | GET       | /Orders                                   |
| Get an order with "10248" id.                                 | GET       | /Orders(10248)                            |
| Get all orders for a customer with "ANATR" id.                | GET       | /Customers('ANATR')/Orders                |
| Get a customer for an order with "10248" id.                  | GET       | /Orders(10248)/Customer                   |
| Get all customers from Germany.                               | GET       | /Customers?$filter=Country eq 'Germany'   |
| Get all orders shipped to France in 1997                      | GET       | /Orders?$filter=ShipCountry eq 'France' and (year(ShippedDate) eq 1997)  |
