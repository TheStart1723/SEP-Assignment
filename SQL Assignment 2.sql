--QUESTIONS
--1.
--The result set represents a set of data returned from database, as the result of a query.
--2.
--1)Union removes duplicate records, union all doesn't.
--2)Union will sort the first column of returned data ascendingly.
--3)Union can be used for cte.
--3.
--UNION, UNION ALL, INTERSECT, EXCEPT
--4.
--1)UNION is used to combine result sets vertically, JOIN is used to combine them horizontally
--2)UNION can only be used to sets that have same columns (number and type), JOIN only needs the tables that have one simmilar column
--5.
--INNER JOIN returnes only the matched values from both tables, FULL JOIN returns all the records from both tables, where the on condition 
--can't be satisfied for those rows it puts null values in for the unpopulated fields.
--6.
--Left Join and Left Outer Join are one and the same.
--7.
--Cross Join creates a cartesian product between the two tables, returning all possible combinations of all rows.
--8.
--YES

--QUERIES
USE AdventureWorks2019
GO
--1.
SELECT COUNT(ProductID) TotalNumOfProducts
FROM Production.Product
--2.
SELECT COUNT(ProductID) TotalNumOfProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
--3.
SELECT ProductSubcategoryID, COUNT(ProductID) CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID
--4.
SELECT COUNT(ProductID) TotalNumOfProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NULL
--5.
SELECT SUM(Quantity) TotalNumOfProducts
FROM Production.ProductInventory
--6.
SELECT ProductID, Quantity TheSum
FROM Production.ProductInventory
WHERE LocationID = 40 AND Quantity < 100
--7.
SELECT Shelf, ProductID, Quantity TheSum
FROM Production.ProductInventory
WHERE LocationID = 40 AND Quantity < 100
--8.
SELECT ProductID, Quantity
FROM Production.ProductInventory
WHERE LocationID = 10
--9.
SELECT ProductID, Shelf, AVG(Quantity) TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf
ORDER BY 1
--10.
SELECT ProductID, Shelf, AVG(Quantity) TheAvg
FROM Production.ProductInventory
WHERE Shelf <> 'N/A'
GROUP BY ProductID, Shelf
ORDER BY 1
--11.
SELECT Color, Class, COUNT(ProductID) TheCount, AVG(ListPrice) AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND CLASS IS NOT NULL
GROUP BY Color, Class
--12.
SELECT c.Name Country, ISNULL(s.Name, 'N/A') Province
FROM Person.CountryRegion c LEFT JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode
ORDER BY 1, 2
--13.
SELECT c.Name Country, ISNULL(s.Name, 'N/A') Province
FROM Person.CountryRegion c LEFT JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name IN ('Germany', 'Canada')
ORDER BY 1, 2

USE Northwind
GO
--14.
SELECT DISTINCT p.ProductID, p.ProductName
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p ON od.ProductID = p.ProductID
WHERE YEAR(o.OrderDate) > 1996
--15.
SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) Total
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL
Group BY o.ShipPostalCode
ORDER BY 2 DESC
--16.
SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) Total
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL AND YEAR(o.OrderDate) > 1996
Group BY o.ShipPostalCode
ORDER BY 2 DESC
--17.
SELECT City, COUNT(CustomerID) NumOfCustomers
FROM Customers
GROUP BY City
--18.
SELECT City, COUNT(CustomerID) NumOfCustomers
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) > 2
--19.
SELECT c.ContactName, o.OrderDate
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID 
WHERE o.OrderDate > '1/1/98'
--20.
SELECT c.ContactName, ISNULL(MAX(CONVERT(varchar,o.OrderDate)), 'N/A') MostRecentDate
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName
--21.
SELECT c.ContactName, COUNT(od.ProductID) NumOfProductsBought
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.ContactName
--22.
SELECT c.CustomerID, COUNT(od.ProductID) NumOfProductsBought
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
Having COUNT(od.ProductID) >= 100
--23.
SELECT su.CompanyName [Supplier Company Name], sh.CompanyName [Shipping Company Name]
FROM Suppliers su CROSS JOIN Shippers sh
ORDER BY 1
--24.
SELECT o.OrderDate, p.ProductName
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p ON od.ProductID = p.ProductID
ORDER BY 1
--25.
SELECT e.FirstName + ' ' + e.LastName as Employee1, m.FirstName + ' ' + m.LastName as Employee2
FROM Employees e INNER JOIN Employees m ON e.Title = m.Title
WHERE e.EmployeeID <> m.EmployeeID
--26.
SELECT m.FirstName + ' ' + m.LastName as Manager, COUNT(e.EmployeeID) as NumOfEmloyees
FROM Employees e LEFT JOIN Employees m ON e.ReportsTo = m.EmployeeID
GROUP BY m.FirstName + ' ' + m.LastName
HAVING COUNT(e.EmployeeID) > 2
--27.
SELECT City, CompanyName [Name], ContactName [Contact Name], 'Customer' as [Type]
FROM Customers
UNION
SELECT City, CompanyName [Name], ContactName [Contact Name], 'Supplier' as [Type]
FROM Suppliers