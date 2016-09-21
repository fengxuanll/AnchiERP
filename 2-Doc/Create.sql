-- �û���
CREATE TABLE [User] (
	[Id] uniqueidentifier NOT NULL PRIMARY KEY, 
	[TrueName] varchar(50) NOT NULL, 
	[LoginName] varchar(50) NOT NULL, 
	[Password] varchar(50) NOT NULL, 
	[IDCard] char(20), 
	[Tel] varchar(20), 
	[Address] nvarchar(100), 
	[Status] tinyint NOT NULL, 
	[Remark] nvarchar(1000), 
	[CreatedOn] datetime NOT NULL
);
CREATE UNIQUE INDEX [uidx_User_LoginName] ON [User] ([LoginName]);

-- ��Ӧ�̱�
CREATE TABLE [Supplier] (
	[Id] uniqueidentifier NOT NULL PRIMARY KEY, 
	[CompanyName] nvarchar(50) NOT NULL, 
	[Contact] nvarchar(50) NOT NULL, 
	[Tel] varchar(50), 
	[Address] nvarchar(100), 
	[Remark] nvarchar(1000), 
	[CreatedOn] datetime NOT NULL
);

-- �ͻ���
CREATE TABLE [Customer] (
	[Id] uniqueidentifier NOT NULL PRIMARY KEY, 
	[Name] nvarchar(50) NOT NULL, 
	[CarNumber] nvarchar(50) NOT NULL, 
	[Tel] varchar(50), 
	[Address] nvarchar(100), 
	[Remark] nvarchar(1000), 
	[CreatedOn] datetime NOT NULL
);
CREATE UNIQUE INDEX [uidx_Customer_CarNumber] ON [Customer] ([CarNumber]);

-- Ա����
CREATE TABLE [Employee] (
	[Id] uniqueidentifier NOT NULL PRIMARY KEY, 
	[Code] varchar(50) NOT NULL, 
	[Name] nvarchar(50) NOT NULL,
	[IDCard] char(20), 
	[Tel] varchar(50),
	[Address] nvarchar(100),
	[EntryOn] datetime NOT NULL,
	[Status] tinyint NOT NULL,
	[Remark] nvarchar(1000), 
	[CreatedOn] datetime NOT NULL
);
CREATE UNIQUE INDEX [uidx_Employee_IDCard] ON [Employee] ([IDCard]);
CREATE UNIQUE INDEX [uidx_Employee_Code] ON [Employee] ([Code]);

-- �����
Create Table [Product](
	[Id] uniqueidentifier NOT NULL PRIMARY KEY, 
	[Code] varchar(50) NOT NULL, 
	[Name] nvarchar(50) NOT NULL,
	[Stock] int NOT NULL,
	[SafeStock] int NOT NULL,
	[SalePrice] decimal NOT NULL,
	[CostPrice] decimal NOT NULL,
	[Remark] nvarchar(1000), 
	[CreatedOn] datetime NOT NULL
);
CREATE UNIQUE INDEX [uidx_Product_Code] ON [Product] ([Code]);

-- �������¼��
Create Table ProductStockRecord(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY, 
	[Type] tinyint NOT NULL,
	[RelationId] uniqueidentifier NOT NULL,
	[ProductId] uniqueidentifier NOT NULL,
	[RecordOn] datetime NOT NULL,
	[QuantityBefore] int NOT NULL,
	[Quantity] int NOT NULL,
	[CreatedOn] datetime NOT NULL,
	FOREIGN KEY([ProductId]) REFERENCES [Product]([Id])
);

-- ά����Ŀ��
Create Table Project(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[Code] varchar(50) NOT NULL, 
	[Name] nvarchar(50) NOT NULL,
	[UnitPrice] decimal NOT NULL,
	[Remark] nvarchar(1000), 
	[CreatedOn] datetime NOT NULL
);
CREATE UNIQUE INDEX [uidx_Project_Code] ON [Project] ([Code]);

-- ά�޵���
Create Table RepairOrder(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[CustomerId] uniqueidentifier NOT NULL,
	[ReceptionById] uniqueidentifier NOT NULL,
	[Status] tinyint NOT NULL,
	[Amount] decimal NOT NULL,
	[RepairOn] datetime NOT NULL,
	[CompleteOn] datetime NOT NULL,
	[SettlementStatus] tinyint NOT NULL,
	[SettlementOn] datetime NULL,
	[SettlementAmount] decimal NULL,
	[Remark] nvarchar(1000), 
	[CreatedById] uniqueidentifier NOT NULL,
	[CreatedOn] datetime NOT NULL,
	FOREIGN KEY([CustomerId]) REFERENCES [Customer]([Id]),
	FOREIGN KEY([ReceptionById]) REFERENCES [Employee]([Id]),
	FOREIGN KEY([CreatedById]) REFERENCES [User]([Id])
);

-- ά�޵������
Create Table RepairOrderProduct(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[RepairOrderId] uniqueidentifier NOT NULL,
	[ProductId] uniqueidentifier NOT NULL,
	[Quantity] int NOT NULL,
	[UnitPrice] decimal NOT NULL,
	[Remark] nvarchar(1000), 
	[CreatedOn] datetime NOT NULL,
	FOREIGN KEY([RepairOrderId]) REFERENCES [RepairOrder]([Id]),
	FOREIGN KEY([ProductId]) REFERENCES [Product]([Id])
);

-- ά�޵���Ŀ��
Create Table RepairOrderProject(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[RepairOrderId] uniqueidentifier NOT NULL,
	[ProjectId] uniqueidentifier NOT NULL,
	[EmployeeId] uniqueidentifier NOT NULL,
	[Quantity] int NOT NULL,
	[UnitPrice] decimal NOT NULL,
	[Remark] nvarchar(1000), 
	[CreatedOn] datetime NOT NULL,
	FOREIGN KEY([RepairOrderId]) REFERENCES [RepairOrder]([Id]),
	FOREIGN KEY([ProjectId]) REFERENCES [Project]([Id]),
	FOREIGN KEY([EmployeeId]) REFERENCES [Employee]([Id])
);

-- ���۵���
Create Table SaleOrder(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[SaleById] uniqueidentifier NOT NULL,
	[CustomerId] uniqueidentifier NOT NULL,
	[Status] tinyint NOT NULL,
	[Amount] decimal NOT NULL,
	[SaleOn] datetime NOT NULL,
	[OutboundOn] datetime NOT NULL,
	[SettlementStatus] tinyint NOT NULL,
	[SettlementOn] datetime NULL,
	[SettlementAmount] decimal NULL,
	[Remark] nvarchar(1000), 
	[CreatedById] uniqueidentifier NOT NULL,
	[CreatedOn] datetime NOT NULL,
	FOREIGN KEY([SaleById]) REFERENCES [Employee]([Id]),
	FOREIGN KEY([CustomerId]) REFERENCES [Customer]([Id]),
	FOREIGN KEY([CreatedById]) REFERENCES [User]([Id])
);

-- ���۵������
Create Table SaleOrderProduct(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[SaleOrderId] uniqueidentifier NOT NULL,
	[ProductId] uniqueidentifier NOT NULL,
	[UnitPrice] decimal NOT NULL,
	[Quantity] int NOT NULL,
	[CreatedOn] datetime NOT NULL,
	FOREIGN KEY([SaleOrderId]) REFERENCES [SaleOrder]([Id]),
	FOREIGN KEY([ProductId]) REFERENCES [Product]([Id])
);

-- �ɹ�����
Create Table PurchaseOrder(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[PurchaseById] uniqueidentifier NOT NULL,
	[SupplierId] uniqueidentifier NOT NULL,
	[Status] tinyint NOT NULL,
	[Amount] decimal NOT NULL,
	[PurchaseOn] datetime NOT NULL,
	[ArrivalOn] datetime NOT NULL,
	[SettlementStatus] tinyint NOT NULL,
	[SettlementOn] datetime NULL,
	[SettlementAmount] decimal NULL,
	[Remark] nvarchar(1000), 
	[CreatedById] uniqueidentifier NOT NULL,
	[CreatedOn] datetime NOT NULL,
	FOREIGN KEY([PurchaseById]) REFERENCES [Employee]([Id]),
	FOREIGN KEY([SupplierId]) REFERENCES [Supplier]([Id]),
	FOREIGN KEY([CreatedById]) REFERENCES [User]([Id])
);

-- �ɹ��������
Create Table PurchaseOrderProduct(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[PurchaseOrderId] uniqueidentifier NOT NULL,
	[ProductId] uniqueidentifier NOT NULL,
	[UnitPrice] decimal NOT NULL,
	[Quantity] int NOT NULL,
	[CreatedOn] datetime NOT NULL,
	FOREIGN KEY([PurchaseOrderId]) REFERENCES [PurchaseOrder]([Id]),
	FOREIGN KEY([ProductId]) REFERENCES [Product]([Id])
);

-- ���񵥱�
Create Table FinanceOrder(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[RelationId] uniqueidentifier NOT NULL,
	[Type] tinyint NOT NULL,
	[Amount] decimal NOT NULL,
	[Remark] nvarchar(1000) NULL,
	[CreatedOn] datetime NOT NULL
);

-- ϵͳ���ñ�
Create Table SystemConfig(
	[Id] integer NOT NULL PRIMARY KEY AUTOINCREMENT,
	[Key] varchar(254) NOT NULL,
	[Value] nvarchar(8000) NOT NULL
);