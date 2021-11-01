--1.
--virtual table whose contents are defined by a query which derived its data from one or more than one table columns. It is stored in the database. It is used to implement the security mechanism in the SQL Server.
--2.
--No
--3.
--A stored procedure groups one or more Transact-SQL statements into a logical unit, stored as an object in a SQL Server database. Increase database security. Faster execution. reduce network traffic for larger ad hoc queries.code reusability.  
--4.
--A Stored Procedure:
--Accepts parameters
--Can NOT be used as building block in a larger query
--Can contain several statements, loops, IF ELSE, etc.
--Can perform modifications to one or several tables
--Can NOT be used as the target of an INSERT, UPDATE or DELETE statement.
--A View:
--Does NOT accept parameters
--Can be used as building block in a larger query
--Can contain only one single SELECT query
--Can NOT perform modifications to any table
--But can (sometimes) be used as the target of an INSERT, UPDATE or DELETE statement.
--5.
--A Stored Procedure:
--used for DML
--called by its name
--input parameters is optional
--output is optional
--can call function
--A Function:
--used for calculation
--called in selection statement
--must have inputs
--must have outputs
--cannot call stored procedure
--6.
--Yes. They may return result sets in case you use SELECT statements.
--7.
--No. sp can only be called using exec
--8.
--Triggers are a special type of stored procedure that get executed (fired) when a specific event happens.
--DDL triggers, DML triggers, CLR triggers, LOGON triggers
--9.
--Triggers are automatically fired  on a event (DML Statements like Insert , Delete or Update)
--Triggers cannot  be explicitly executed.

--1.
CREATE VIEW view_product_order_Liu
AS
SELECT ProductID, SUM(Quantity) TotalOrderedQuantity
FROM [Order Details]
GROUP BY ProductID

--2.
CREATE PROC sp_product_order_quantity_Liu
@pid int,
@total smallint out
AS
BEGIN
SELECT @total = SUM(Quantity)
FROM [Order Details]
WHERE ProductID = @pid
END

BEGIN 
declare @total smallint
exec sp_product_order_quantity_Liu 23, @total out
print @total
END

--3.
CREATE PROC sp_product_order_city_Liu
@pname nvarchar(40)
AS
BEGIN
SELECT TOP 5 ShipCity, SUM(Quantity) TotalQuantity
FROM Orders o join [Order Details] od on o.OrderID = od.OrderID join Products p on od.ProductID = p.ProductID
WHERE p.ProductName = @pname
GROUP BY ShipCity
ORDER BY 2 DESC
END

EXEC sp_product_order_city_Liu 'Tofu'

--4.
CREATE TABLE people_Liu(
id int PRIMARY KEY,
FullName nvarchar(30) not null,
cityid int FOREIGN KEY REFERENCES city_Liu(id) on delete set null
)
INSERT INTO people_Liu VALUES
(1,'Aaron Rodgers',2),
(2,'Russell Wilson',1),
(3,'Jody Nelson',2)

CREATE TABLE city_Liu(
id int PRIMARY KEY,
CityName nvarchar(15) not null
)
INSERT INTO city_Liu VALUES
(1,'Seattle'),
(2,'Green Bay')

DELETE FROM city_Liu
WHERE CityName = 'Seattle'

INSERT INTO city_Liu VALUES
(1, 'Madison')

UPDATE people_Liu
SET cityid = 1	
WHERE cityid IS NULL

CREATE VIEW Packers_valerie
AS
SELECT fullname
FROM people_Liu p JOIN city_Liu c ON p.cityid = c.id
WHERE c.CityName = 'Green Bay'

DROP TABLE people_Liu, city_Liu
DROP VIEW Packers_valerie

--5.
CREATE PROC sp_birthday_employees_Liu
AS
BEGIN
SELECT EmployeeID, FirstName +' '+LastName Name, BirthDate
INTO birthday_employees_Liu
FROM Employees
WHERE MONTH(BirthDate)=2
END

exec sp_birthday_employees_Liu

select * from birthday_employees_Liu

drop table birthday_employees_Liu

--6.
--Except shows the difference between two tables
select * from table1
except
select * from table2

--7.
SELECT firstName+' '+lastName 
from Person 
where middleName is null 
UNION 
SELECT firstName+' '+lastName+' '+middelName+'.' 
from Person 
where middleName is not null

--8.
select top 1 marks
from StudentMark 
where sex = 'F'
order by marks desc

--9.
select * from StudentMark order by sex,marks