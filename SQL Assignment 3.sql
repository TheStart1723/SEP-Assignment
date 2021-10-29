--Questions
--1.
--Join has better performance and is faster than subquery.
--2.
--cte stands for common table expression. It is the result set of a query which exists temporarily and for use only within the context of a larger query. 
--3.
--Table variables can be declared within batches, functions, and stored procedures, and table variables automatically go out of scope when the declaration batch, function, or stored procedure goes out of scope. Within their scope, table variables can be used in SELECT, INSERT, UPDATE, and DELETE statements.
--4.
--Truncate removes all records and doesn't fire triggers. Truncate is faster compared to delete as it makes less use of the transaction log. Truncate is not possible when a table is referenced by a Foreign Key or tables are used in replication or with indexed views.
--5.
--Identity column is a special type of column that is used to automatically generate key values based on a provided seed (starting point) and increment. Delete retains the identity and does not reset it to the seed value. Truncate reset the identity to its seed value.
--6.
--Delete can be used to remove all rows or only a subset of rows. Truncate removes all rows.
--Queries
--1.
SELECT DISTINCT c.City
FROM Customers c, Employees e
WHERE c.City = e.city
--2.a
SELECT DISTINCT City
FROM Customers
WHERE City NOT IN
(SELECT City
FROM Employees)
--2.b
SELECT DISTINCT c.City
FROM Customers c LEFT JOIN Employees e ON c.city = e.city
WHERE e.city IS NULL
--3.
SELECT p.ProductName, SUM(od.Quantity) TotalOrderQuantity
FROM [Order Details] od JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.ProductName
--4.
SELECT c.City, SUM(od.Quantity) TotalProducts
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.City
ORDER BY 2 DESC
--5.a
select City from Customers
group by City
having count(*) = 0
union 
select City from Customers
except 
select City from Customers
group by City
having count(*) = 1
--5.b
SELECT City
FROM Customers
GROUP BY City
HAVING COUNT(*) >= 2

SELECT co.City
FROM (SELECT City, COUNT(*) num FROM Customers GROUP BY City) co 
WHERE co.num >= 2
--6.
select distinct city from orders o join [order details] od on o.orderid=od.orderid join customers c on c.customerid=o.CustomerID
group by city
having COUNT(*)>=2
--7.
select distinct contactname
from customers c join orders o on c.CustomerID = o.CustomerID
where c.City <> o.ShipCity
--8.
select top 1 city
from customers c join orders o on c.CustomerID = o.CustomerID join [Order Details] od on o.OrderID = od.OrderID
where od.ProductID = od.ProductID
group by city
order by sum(quantity) desc

select top 5 productid, avg(UnitPrice) avgprice, 
(select top 1 city
from customers c join orders o on c.CustomerID = o.CustomerID join [Order Details] od1 on o.OrderID = od1.OrderID
where od1.ProductID = od2.ProductID
group by city
order by sum(quantity) desc) city
from [Order Details] od2
group by productid
order by sum(quantity) desc
--9.a
select city 
from employees
where city not in 
(select c.city from customers c join orders o on c.CustomerID = o.CustomerID)
--9.b
select city from employees
except 
select c.city from customers c join orders o on c.CustomerID = o.CustomerID
--10.
select (select top 1 City from Orders o join [Order Details] od on o.OrderID=od.OrderID join Employees e on e.EmployeeID = o.EmployeeID
group by e.EmployeeID,e.City
order by COUNT(*) desc) as MostOrderedCity,
(select top 1 City from Orders o join [Order Details] od on o.OrderID=od.OrderID join Employees e on e.EmployeeID = o.EmployeeID
group by e.EmployeeID,e.City
order by sum(Quantity) desc) as MostQunatitySoldCity
--11.
--use group by and count(*), if having count(*) > 1, use subquery to union them together
--12.
select empid 
from employee
except 
select mgrid
from employee
--13.
select deptid
from employee
group by deptid 
having count(*) = (
select top 1 count(*)
from employee
group by deptid
order by count(*) desc)
--14. 
select deptname, empid, salary
from employee e join dept d on e.deptid = d.deptid
order by deptname, salary desc

