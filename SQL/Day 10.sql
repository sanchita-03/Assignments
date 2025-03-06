Use BookStoreDB

------------------------------------------SubQueries---------------------------------------------

--1. Find the customer(s) who placed the first order (earliest OrderDate).
select * from Customers 
where CustomerID in(
select CustomerID from Orders 
where OrderDate=(select MIN(OrderDate) from Orders) )


--2. Find the customer(s) who placed the most orders.

select * from Customers where CustomerID in(
select CustomerID from Orders group by CustomerID having COUNT(OrderID)=(
select Max(OrderCount) as maxcount From (
select Count(OrderID) as OrderCount from Orders 
group by CustomerID Having CustomerID is not Null) as Ordercounts))


--3. Find customers who have not placed any orders
insert into Customers values('Sanchita','mandh@gmail.com',9370852344)
insert into Customers values('Sanket','mandhare@gmail.com',9370852346)
Select * from Customers where CustomerID not in (select CustomerID from Orders where CustomerID is not null)


--4. Retrieve all books cheaper than the most expensive book written by( any author based on your data)
Select * from Books where Price <(select max(Price) from Books)


--5. List all customers whose total spending is greater than the average spending of all customers
select * From Customers where CustomerID in
(Select CustomerID from Orders 
group by CustomerID 
having SUM(TotalAmount)>
(select AVG(TotalAmount) from Orders))


--------------------------------------Stored Procedures--------------------------------------------------------

--1. Write a stored procedure that accepts a CustomerID and returns all orders placed by that customer
Create Procedure sp_get_by_customerid
@CustmerID int
as 
begin
select * from Orders where CustomerID=@CustmerID
end

exec sp_get_by_customerid 5



--2.Create a procedure that accepts MinPrice and MaxPrice as parameters and returns all books within that range 
Create Procedure sp_get_book_within_range
@MinPrice decimal(18,0),
@MaxPrice decimal(18,0)
as
begin
select * from Books where Price between @MinPrice and @MaxPrice
end

exec sp_get_book_within_range 2000 , 3000




---------------------------------------Views-----------------------------------------------------------------------

--1.Create a view named AvailableBooks that shows only books that are in 
--   stock, including BookID, Title, AuthorID, Price, and PublishedYear 
alter table Books
add StockQuantity int 

UPDATE Books SET StockQuantity = 5 WHERE BookID = 1;
UPDATE Books SET StockQuantity = 0 WHERE BookID = 2;
UPDATE Books SET StockQuantity = 8 WHERE BookID = 3;
UPDATE Books SET StockQuantity = 3 WHERE BookID = 4;
UPDATE Books SET StockQuantity = 0 WHERE BookID = 5;
UPDATE Books SET StockQuantity = 2 WHERE BookID = 6;
UPDATE Books SET StockQuantity = 1 WHERE BookID = 7;


Create View AvailableBooks 
as 
select 
	BookID, 
	Title, 
	AuthorID, 
	Price,
	PublishedYear 
from Books 
    where StockQuantity > 0


select * from AvailableBooks
