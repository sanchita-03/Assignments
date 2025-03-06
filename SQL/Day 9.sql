--Create a database named BookStoreDB.
Create database BookStoreDB

use BookStoreDB
--Create Author Table
Create Table Authors (
AuthorID int identity Primary Key, 
Name Varchar(20) not null, 
Country varchar(20) not null)

--Create Customer Table
Create table Customers (
CustomerID int identity(1,1) primary key, 
Name Varchar(20) not null, 
Email varchar(25) unique not null, 
PhoneNumber varchar(15) unique not null)

--Create Book Table
Create Table Books (
BookID int identity(1,1) primary key, 
Title Varchar(100) not null,
AuthorID int not null,
Price decimal not null, 
PublishedYear int not null,
Constraint FK_Books_Authors
Foreign key(AuthorID) references Authors(AuthorID))

--Create Table Order
create table Orders(
OrderID int identity(1,1) primary key, 
CustomerID int not null, 
OrderDate date not null, 
TotalAmount decimal not null,
constraint FK_Orders_Customers
foreign key(CustomerID) references Customers(CustomerID))

--Create Table Orderitem
Create Table OrderItems (
OrderItemID int identity(1,1) Primary key, 
OrderID int not null, 
BookID int not null, 
Quantity int not null, 
SubTotal decimal not null,
constraint FK_OrderItems_Orders foreign key(OrderID) references Orders(OrderID),
constraint FK_OrderItems_Books foreign key(BookID) references Books(BookID))

--alter OrderItems table
Alter Table OrderItems
Alter Column OrderID int null

Alter Table OrderItems
Alter Column BookID int null

--alter orders table
Alter Table Orders
Alter Column CustomerID int null

--alter books table
Alter Table Books
Alter Column AuthorID int null

-----------------------------DML-----------------------------------------------------------------------------

--1. Insert at least 5 records into each table.

INSERT INTO Authors (Name, Country) VALUES
('Robert C. Martin', 'USA'),
('Martin Fowler', 'UK'),
('Andrew Ng', 'USA'),
('Ben Forta', 'Canada'),
('Joe Celko', 'USA');


INSERT INTO Books (Title, AuthorID, Price, PublishedYear) VALUES
('SQL Mastery', 1, 1500, 2018),
('Refactoring', 2, 2200, 2019),
('Deep Learning', 3, 2500, 2021),
('SQL in 10 Minutes', 4, 1800, 2017),
('SQL for Smarties', NULL, 2100, 2020);  -- AuthorID is NULL


INSERT INTO Customers (Name, Email, PhoneNumber) VALUES
('Alice Johnson', 'alice@example.com', '9876543210'),
('James Smith', 'james@example.com', '8765432109'),
('Michael Lee', 'michael@example.com', '7654321098'),
('Jessica Brown', 'jessica@example.com', '6543210987'),
('John Doe', 'john@example.com', '5432109876');


INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES
(1, '2024-03-01', 3700),
(2, '2024-03-02', 2200),
(3, '2024-03-03', 2500),
(NULL, '2024-03-04', 1800),  -- No Customer (Guest Order)
(5, '2024-03-05', 1500);


INSERT INTO OrderItems (OrderID, BookID, Quantity, SubTotal) VALUES
(1, 2, 1, 2200),
(1, 3, 3, 2500),
(2, 2, 2, 2200),
(3, NULL, 1, 2500),  -- BookID is NULL (Unknown book)
(NULL, 4, 5, 1800),  -- OrderID is NULL (Orphaned item)
(5, 1, 1, 1500);


--2. Update the price of a book titled "SQL Mastery" by increasing it by 10%.
update Books
SET Price = Price*1.1
where Title='SQL Mastery'

--3. Delete a customer who has not placed any orders.
Delete from Customers
where CustomerID not in (select Distinct CustomerID from Orders where CustomerID is not NULL)


-------------------------------Operators-------------------------------------------

--1. Retrieve all books with a price greater than 2000.
Select * from Books where Price>2000

--2. Find the total number of books available.
INSERT INTO Books (Title, AuthorID, Price, PublishedYear) VALUES
('SQL Mastery', 1, 1500, 2019)

select COUNT(Distinct Title) as Total_Number_Of_books from Books

--3. Find books published between 2015 and 2023.
INSERT INTO Books (Title, AuthorID, Price, PublishedYear) VALUES
('SQL Mastery2', 2, 1500, 2004)

select * from Books where PublishedYear Between 2015 and 2023


--4. Find all customers who have placed at least one order.
select * from Customers
where CustomerID in (
select Distinct CustomerID from Orders 
where CustomerID is not NULL)

--5. Retrieve books where the title contains the word "SQL".
select * from Books where Title like '%SQL%'

--6. Find the most expensive book in the store.
Select * from Books where Price =(Select MAX(Price) From Books)

--7. Retrieve customers whose name starts with "A" or "J".
Select * From Customers where Name like 'A%' OR Name like 'J%'

--8. Calculate the total revenue from all orders. 
Select SUM(TotalAmount) as TotalRevenue from Orders


-------------------------------------Joins-----------------------------------------------------
--1. Retrieve all book titles along with their respective author names.
Select Title , Name as AuthorName 
from Books as b 
join Authors as a 
on b.AuthorID=a.AuthorID

--2. List all customers and their orders (if any).
select * from Customers as c
Left join Orders as o on c.CustomerID=o.CustomerID

--3. Find all books that have never been ordered.
select b.* from Books b
Left join OrderItems o on b.BookID=o.BookID
where o.BookID is null


--4. Retrieve the total number of orders placed by each customer.
SELECT 
    c.CustomerID, 
    c.Name, 
    COUNT(o.OrderID) AS OrderCount 
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.Name;

--5. Find the books ordered along with the quantity for each order.
SELECT 
    b.BookID, 
    b.Title, 
    o.OrderID, 
    o.Quantity 
FROM Books b
JOIN OrderItems o ON b.BookID = o.BookID 



--6. Display all customers, even those who haven’t placed any orders.
Select * from Customers c
Left Join Orders o
on c.CustomerID=o.CustomerID

--7. Find authors who have not written any books 
Select * from Authors a
left join Books b
on a.AuthorID=b.AuthorID
where b.AuthorID is null




select * from Customers
select * from Orders
select * from OrderItems
select * from Books
select * from Authors