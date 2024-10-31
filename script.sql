CREATE DATABASE [DapperTask];

USE [DapperTask];

CREATE TABLE [User]
(
    [Id] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    [Email] VARCHAR(100) NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
    [Address] NVARCHAR(MAX) NULL
);

CREATE TABLE [Order]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [ItemCount] INT NOT NULL,
    [TotalPrice] MONEY NOT NULL,
    [InsertDate] DATETIME NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_Order_AppUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
);

CREATE TABLE [OrderDetail]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(255) NOT NULL,
    [Quantity] INT NOT NULL,
    [Price] MONEY NOT NULL,
    [TotalPrice] AS ([Quantity] * [Price]) PERSISTED,
    [InsertDate] DATETIME NULL,
    [OrderId] INT NOT NULL,
    CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id]) ON DELETE CASCADE
);

CREATE TRIGGER [TRG_UpdateOrderTotalPriceAfterInsert]
    ON [OrderDetail]
    AFTER INSERT
    AS
    UPDATE [Order]
    SET [TotalPrice] = (SELECT SUM([TotalPrice]) FROM [OrderDetail] WHERE [OrderId] = [Order].[Id])
    FROM [Order]
    WHERE [Order].[Id] IN (SELECT DISTINCT [OrderId] FROM [INSERTED]);

CREATE TRIGGER [TRG_UpdateOrderTotalPriceAfterUpdate]
    ON [OrderDetail]
    AFTER UPDATE
    AS
    UPDATE [Order]
    SET [TotalPrice] = [TotalPrice] - ISNULL((SELECT SUM([TotalPrice]) FROM [DELETED] WHERE [OrderId] = [Order].[Id]), 0)
        + ISNULL((SELECT SUM([TotalPrice]) FROM [INSERTED] WHERE [OrderId] = [Order].[Id]), 0)
    FROM [Order]
    WHERE [Order].[Id] IN (SELECT DISTINCT [OrderId] FROM [INSERTED]);

CREATE TRIGGER [TRG_UpdateOrderTotalPriceAfterDelete]
    ON [OrderDetail]
    AFTER DELETE
    AS
    UPDATE [Order]
    SET [TotalPrice] = [TotalPrice] - ISNULL((SELECT SUM([TotalPrice]) FROM [DELETED] WHERE [OrderId] = [Order].[Id]), 0)
    FROM [Order]
    WHERE [Order].[Id] IN (SELECT DISTINCT [OrderId] FROM [DELETED]);
