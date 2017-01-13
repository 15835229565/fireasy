USE 'fireasy-db';
CREATE TABLE Categories (
	CategoryID int NOT NULL,
	CategoryName nvarchar(15) NOT NULL,
	Description text NULL,
	CONSTRAINT PK_Categories PRIMARY KEY (CategoryID)
)
COMMENT='�����';
CREATE TABLE Customers (
	CustomerID nvarchar(50) NOT NULL ,
	CompanyName nvarchar(100) NULL ,
	ContactName nvarchar(100) NULL ,
	ContactTitle nvarchar(100) NULL ,
	Address nvarchar(100) NULL ,
	City nvarchar(20) NULL ,
	Region nvarchar(20) NULL ,
	PostalCode nvarchar(10) NULL ,
	Country nvarchar(20) NULL ,
	Phone nvarchar(100) NULL ,
	Fax nvarchar(100) NULL ,
	CONSTRAINT PK_Customers PRIMARY KEY (CustomerID)
)
COMMENT='�ͻ���';
CREATE TABLE Products
(
	ProductID int NOT NULL AUTO_INCREMENT COMMENT '��ƷID',
	ProductName nvarchar(40) NOT NULL COMMENT '��Ʒ����',
	SupplierID int NULL COMMENT '��Ӧ��ID',
	CategoryID int NULL COMMENT '����ID',
	QuantityPerUnit nvarchar(20) NULL,
	UnitPrice decimal(19,2) NULL COMMENT '����',
	UnitsInStock smallint NULL COMMENT '�����',
	UnitsOnOrder smallint NULL COMMENT '������',
	ReorderLevel smallint NULL,
	Discontinued bit NOT NULL,
	CONSTRAINT PK_Products PRIMARY KEY (ProductID)
)
COMMENT='��Ʒ��';
CREATE TABLE Orders
(
	OrderID int NOT NULL AUTO_INCREMENT COMMENT '����ID',
	CustomerID nchar(5) COMMENT '�ͻ�ID',
	EmployeeID int NULL COMMENT 'Ա��ID',
	OrderDate datetime NULL COMMENT '��������',
	RequiredDate datetime NULL,
	ShippedDate datetime NULL,
	ShipVia int NULL,
	Freight decimal(19,2) NULL,
	ShipName nvarchar(40) NULL,
	ShipAddress nvarchar(60) NULL,
	ShipCity nvarchar(15) NULL,
	ShipRegion nvarchar(15) NULL,
	ShipPostalCode nvarchar(10) NULL,
	ShipCountry nvarchar(15) NULL,
	CONSTRAINT PK_Orders PRIMARY KEY (OrderID)
)
COMMENT='������';
CREATE TABLE `Order Details` (
	OrderID int NOT NULL,
	ProductID int NOT NULL,
	UnitPrice decimal(19,2) NOT NULL,
	Quantity smallint NOT NULL,
	Discount decimal(18,2) NOT NULL,
	CONSTRAINT PK_Order_Details PRIMARY KEY (OrderID, ProductID)
)
COMMENT='������ϸ��';
CREATE TABLE Batchers (
	Id int NOT NULL,
	Name nvarchar(50) NOT NULL,
	Birthday datetime
);

CREATE TABLE Identitys (
	Id1 int NOT NULL AUTO_INCREMENT,
	Id2 int NOT NULL,
	CONSTRAINT PK_Identity PRIMARY KEY (Id1, Id2)
);