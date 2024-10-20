--if (DB_ID('Codex') is not null)
--begin
--use master
--drop database [Codex]
--end

--create database Codex
--go

use [Codex]
go

--create table users (
--id int primary key identity(1000,1),
--firstName nvarchar(100) not null,
--lastName nvarchar(100) not null,
--email varchar(150) unique not null,
--username varchar(100) unique not null,
--phone_number varchar(20),
--date_of_birth date,
--avatar varchar(200),
--password varchar(max) not null,
--created_at datetime not null,
--isdeleted bit not null
--)
--go
create table addresses(
addressID int primary key identity(500,1),
userId int FOREIGN key references AspNetUsers(id),
address_line nvarchar(150) not null,
city nvarchar(50) not null,
country nvarchar(50) not null,
landmark nvarchar(100),
phone_number varchar(20) not null,
created_at datetime not null,
)
go

create table parentCategories(
categoryID int primary key identity,
name nvarchar(100) not null,
description nvarchar(150),
created_at datetime not null,
isdeleted bit not null
)

create table categories(
categoryID int primary key identity,
parentCategory_id int references parentCategories(categoryID),
name nvarchar(100) not null,
description nvarchar(150),
created_at datetime not null,
isdeleted bit not null
)
go

create table brands(
brandID int primary key identity,
name nvarchar(150) unique not null,
description nvarchar(200),
created_at datetime not null,
deleted_at datetime,
isdeleted bit not null,
)
go

create table products(
productID int primary key identity(700,1),
name nvarchar(100) not null,
description nvarchar(500),
summary nvarchar(500),
cover varchar(200),
serialNumber varchar(200) not null,
price int not null,
discount int,
instock bit not null,
quantity int not null,
categoryID int foreign key references categories(categoryID),
brandID int foreign key references brands(brandID),
created_at datetime not null,
deleted_at datetime,
isdeleted bit not null
)
go

create table product_attributes(
ID int primary key,
name varchar(100) not null,
value varchar(100) not null,
created_at datetime not null
)
go

create table productsProduct_attributes(
productID int foreign key references products(productID),
Product_attributes_ID int foreign key references product_attributes(ID)
primary key clustered(productID,Product_attributes_ID)
)
go

/*create table product_sku( --   sku --> Stock keeping unit
ID int primary key identity,
productID int foreign key references products(productID),
sku varchar(200),
--color_attribute int foreign key references product_attributes(ID), -- can add other attributes below this
price int not null, -- in cents
quantity int not null,
created_at datetime not null
)
go*/

create table carts(
--cartID int primary key references AspNetUsers(id) on delete cascade,
cartID int primary key identity,
userID int foreign key references  AspNetUsers(id) on delete cascade,
total int not null,
created_at datetime not null,
updated_at datetime not null
)
go

create table cart_items(
cartID int foreign key references carts(cartID) on delete cascade,
productID int foreign key references products(productID),
quantity int not null,
created_at datetime not null,
updated_at datetime not null,
primary key clustered (cartID,productID)
)
go

--create TRIGGER tr_createCart
--on [AspNetUsers]
--AFTER insert
--as
--begin
--	declare @id int= (select top 1 id from inserted)
--	declare @currentDate datetime=GETDATE()
--	insert into [carts] values (@id,0,@currentDate , @currentDate)
--end
--go

create table orders(
orderID int primary key identity,
userId int foreign key references AspNetUsers(id),
addressID int foreign key references addresses(addressID) not null,
total int not null,
created_at datetime not null,
updated_at datetime not null
)

create table order_items(
orderID int foreign key references orders(orderID),
productID int foreign key references products(productID),
quantity int not null,
created_at datetime not null,
updated_at datetime not null
)
go

create table payment_details(
ID int primary key identity,
orderID int foreign key references orders(orderID),
amount int,
provider varchar(150),
status varchar(50),
created_at datetime not null,
updated_at datetime not null,
)
go