create database dbStoreLinq
use dbStoreLinq

--product table
create table Product
(
ProductID int identity(1,1),
Name varchar(50) not null,
Description varchar(50) not null,
Price money not null,
DiscountPercentage float not null,
constraint PK_prod primary key (ProductID)
)


--customer table
create table Customer
(
CustomerID int identity(1,1),
Name varchar(50) not null,
Address varchar(50) not null,
ContactNo varchar(20) not null,
constraint PK_cust primary key (CustomerID)

)

--drop table Customer
--drop table PurchaseOrder
--drop table PurchaseOrderDetails
--drop table Product


--Purcharse Order table
create table PurchaseOrder
(
POID int identity(1,1),
CustomerID int,
Date Date not null,
Amount money not null,
constraint PK_porder primary key (POID),
constraint FK_cust foreign key(CustomerID)
references Customer(CustomerID)
)
sp_help PurchaseOrder

--Purchase Order Details Table

create table PurchaseOrderDetails
(
PODID int identity(1,1),
POID int not null,
ProductID int not null,
Price money not null,
Qty float not null,
constraint PK_pod primary key (PODID),
constraint FK_porder foreign key(POID)
references PurchaseOrder(POID),
constraint FK_product foreign key(ProductID)
references Product(ProductID),
)

--drop table PurchaseOrderDetails

select * from Product
select * from Customer
select * from PurchaseOrder
select * from PurchaseOrderDetails

-- List of Purchase order against Customer
select cust.Name as  CustomerName,po.POID,prod.Name as ProductName,pod.Price 
from Customer cust 
join PurchaseOrder po
on po.CustomerID=cust.CustomerID
join PurchaseOrderDetails pod
on pod.price=po.Amount
join Product prod
on prod.ProductID=pod.ProductID

-- Month wise customer report with products
 select Month(po.Date) as Month,cust.Name as Customer, Amount
 from PurchaseOrder po
 join Customer cust
 on cust.CustomerID=po.CustomerID


--Product sales report Month wise 

--select  Month(Date) Month,po.POID,max(Price) Price
--from PurchaseOrder po 
--join PurchaseOrderDetails pod on po.POID=pod.POID
--where po.POID in (select POID from PurchaseOrderDetails pod1 
--				  where Price in
--						(select Max(Price) from PurchaseOrderDetails pod2 
--						join PurchaseOrder po1 on po1.POID=pod2.POID 
--						group by Month(po1.Date)))
--group by MONTH (Date),po.POID


--Maximum order rice order and month wise


select  Month(Date) Month,po.POID,Max(Price) Price
from PurchaseOrder po 
join PurchaseOrderDetails pod on po.POID=pod.POID
group by po.POID,Month(Date)


