CREATE SMALLFILE TABLESPACE "FIREASY_DB"
DATAFILE 'D:\ORACLE\ORADATA\LOCAL\FIREASY.dbf' SIZE 200M LOGGING EXTENT MANAGEMENT LOCAL SEGMENT SPACE MANAGEMENT AUTO;
CREATE USER "FIREASY-DB" PROFILE "DEFAULT" IDENTIFIED BY "123" DEFAULT
TABLESPACE "FIREASY_DB" TEMPORARY TABLESPACE "TEMP" ACCOUNT UNLOCK;
GRANT UNLIMITED TABLESPACE TO "FIREASY-DB";
GRANT "CONNECT" TO "FIREASY-DB";
GRANT "DBA" TO "FIREASY-DB";

CREATE TABLE Categories (
  CategoryID integer NOT NULL,
  CategoryName nvarchar2(15) NOT NULL,
  Description nvarchar2(2000) NULL,
  CONSTRAINT PK_Categories PRIMARY KEY (CategoryID)
);
comment on table Categories
  is '�����';
CREATE TABLE Customers (
  CustomerID nvarchar2(50) NOT NULL ,
  CompanyName nvarchar2(100) NULL ,
  ContactName nvarchar2(100) NULL ,
  ContactTitle nvarchar2(100) NULL ,
  Address nvarchar2(100) NULL ,
  City nvarchar2(20) NULL ,
  Region nvarchar2(20) NULL ,
  PostalCode nvarchar2(10) NULL ,
  Country nvarchar2(20) NULL ,
  Phone nvarchar2(100) NULL ,
  Fax nvarchar2(100) NULL ,
  CONSTRAINT PK_Customers PRIMARY KEY (CustomerID)
);
comment on table Customers
  is '�����';
CREATE TABLE Products
(
  ProductID INTEGER NOT NULL,
  ProductName nvarchar2(40) NOT NULL,
  SupplierID integer NULL,
  CategoryID integer NULL,
  QuantityPerUnit nvarchar2(20) NULL,
  UnitPrice number(19,2) NULL,
  UnitsInStock number(4) NULL,
  UnitsOnOrder number(4) NULL,
  ReorderLevel number(4) NULL,
  Discontinued number(1) NOT NULL,
  CONSTRAINT PK_Products PRIMARY KEY (ProductID)
);
comment on table Products
  is '��Ʒ��';
comment on column Products.ProductID
  is '��ƷID';
comment on column Products.ProductName
  is '��Ʒ����';
comment on column Products.SupplierID
  is '��Ӧ��ID';
comment on column Products.CategoryID
  is '����ID';
comment on column Products.UnitPrice
  is '����';
comment on column Products.UnitsInStock
  is '�����';
comment on column Products.UnitsOnOrder
  is '������';
CREATE TABLE Orders
(
  OrderID INTEGER NOT NULL,
  CustomerID nchar(5),
  EmployeeID integer NULL,
  OrderDate date NULL,
  RequiredDate date NULL,
  ShippedDate date NULL,
  ShipVia integer NULL,
  Freight number(19,2) NULL,
  ShipName nvarchar2(40) NULL,
  ShipAddress nvarchar2(60) NULL,
  ShipCity nvarchar2(15) NULL,
  ShipRegion nvarchar2(15) NULL,
  ShipPostalCode nvarchar2(10) NULL,
  ShipCountry nvarchar2(15) NULL,
  CONSTRAINT PK_Orders PRIMARY KEY (OrderID)
);
comment on table Orders
  is '������';
comment on column Orders.OrderID
  is '����ID';
comment on column Orders.CustomerID
  is '�ͻ�ID';
comment on column Orders.EmployeeID
  is 'Ա��ID';
comment on column Orders.OrderDate
  is '��������';
CREATE TABLE "ORDER DETAILS" (
  OrderID integer NOT NULL,
  ProductID integer NOT NULL,
  UnitPrice number(19,2) NOT NULL,
  Quantity number(4) NOT NULL,
  Discount number(18,2) NOT NULL,
  CONSTRAINT PK_Order_Details PRIMARY KEY (OrderID, ProductID)
);
comment on table "ORDER DETAILS"
  is '������ϸ��';
CREATE TABLE Batchers (
  Id integer NOT NULL,
  Name nvarchar2(50) NOT NULL,
  Birthday date
);
CREATE TABLE Identitys (
	Id1 integer NOT NULL,
	Id2 integer NOT NULL,
	CONSTRAINT PK_Identity PRIMARY KEY (Id1, Id2)
);