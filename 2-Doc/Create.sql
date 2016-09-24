-- �û���
DROP TABLE [User];
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
DROP TABLE [Supplier];
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
DROP TABLE [Customer];
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
DROP TABLE [Employee];
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
DROP TABLE [Product];
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
DROP TABLE [ProductStockRecord];
Create Table [ProductStockRecord](
	[Id] uniqueidentifier NOT NULL PRIMARY KEY, 
	[Type] tinyint NOT NULL,
	[RelationId] uniqueidentifier NOT NULL,
	[ProductId] uniqueidentifier NOT NULL,
	[RecordOn] datetime NOT NULL,
	[QuantityBefore] int NOT NULL,
	[Quantity] int NOT NULL,
	[CreatedOn] datetime NOT NULL,
	[Remark] nvarchar(1000) NULL,
	FOREIGN KEY([ProductId]) REFERENCES [Product]([Id])
);

-- ά����Ŀ��
DROP TABLE [Project];
Create Table [Project](
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[Code] varchar(50) NOT NULL, 
	[Name] nvarchar(50) NOT NULL,
	[UnitPrice] decimal NOT NULL,
	[Remark] nvarchar(1000), 
	[CreatedOn] datetime NOT NULL
);
CREATE UNIQUE INDEX [uidx_Project_Code] ON [Project] ([Code]);

-- ά�޵���
DROP TABLE [RepairOrder];
Create Table [RepairOrder](
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[Code] varchar(50) NOT NULL, 
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
DROP TABLE [RepairOrderProduct];
Create Table [RepairOrderProduct](
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
DROP TABLE [RepairOrderProject];
Create Table [RepairOrderProject](
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
DROP TABLE [SaleOrder];
Create Table [SaleOrder](
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[Code] varchar(50) NOT NULL, 
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
DROP TABLE [SaleOrderProduct];
Create Table [SaleOrderProduct](
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
DROP TABLE [PurchaseOrder];
Create Table [PurchaseOrder](
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[Code] varchar(50) NOT NULL,
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
DROP TABLE [PurchaseOrderProduct];
Create Table [PurchaseOrderProduct](
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
DROP TABLE [FinanceOrder];
Create Table [FinanceOrder](
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[Code] varchar(50) NOT NULL,
	[RelationId] uniqueidentifier NOT NULL,
	[Type] tinyint NOT NULL,
	[Amount] decimal NOT NULL,
	[Remark] nvarchar(1000) NULL,
	[CreatedOn] datetime NOT NULL
);

-- ���б�
DROP TABLE [Sequence];
Create Table [Sequence](
	[Type] int NOT NULL PRIMARY KEY,
	[MinValue] bigint NOT NULL,
	[MaxValue] bigint NOT NULL,
	[Increment] bigint NOT NULL,
	[CurrentValue] bigint NOT NULL,
	[Cycle] bigint NOT NULL,
	[ModifiedOn] datetime NOT NULL,
	[Description] nvarchar(1000) NULL
)

-- ϵͳ���ñ�
DROP TABLE [SystemConfig];
Create Table [SystemConfig](
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[Key] varchar(254) NOT NULL,
	[Value] nvarchar(8000) NOT NULL,
	[CreatedOn] datetime NOT NULL
);

-- ��ʼ������
-- ��ʼ���û�����
INSERT INTO [User] ([Id], [TrueName], [LoginName], [Password], [IDCard], [Tel], [Address], [Status], [Remark], [CreatedOn])
VALUES ('00000000-0000-0000-0000-000000000001', 'admin', 'admin', '21232F297A57A5A743894A0E4A801FC3', NULL, NULL, NULL, 1, 'Ĭ��ϵͳ����Ա', DATETIME(CURRENT_TIMESTAMP, 'LOCALTIME'));
-- ��ʼ����������
INSERT INTO [Sequence] ([Type], [MinValue], [MaxValue], [Increment], [CurrentValue], [Cycle], [ModifiedOn], [Description])
VALUES (1, 0, 9999, 1, 0, 1, '1970-01-01', 'ά�޵���������');
INSERT INTO [Sequence] ([Type], [MinValue], [MaxValue], [Increment], [CurrentValue], [Cycle], [ModifiedOn], [Description])
VALUES (2, 0, 9999, 1, 0, 1, '1970-01-01', '���۵���������');
INSERT INTO [Sequence] ([Type], [MinValue], [MaxValue], [Increment], [CurrentValue], [Cycle], [ModifiedOn], [Description])
VALUES (3, 0, 9999, 1, 0, 1, '1970-01-01', '�ɹ�����������');
INSERT INTO [Sequence] ([Type], [MinValue], [MaxValue], [Increment], [CurrentValue], [Cycle], [ModifiedOn], [Description])
VALUES (4, 0, 9999, 1, 0, 1, '1970-01-01', '���񵥱�������');