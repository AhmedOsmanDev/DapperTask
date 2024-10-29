CREATE DATABASE [DapperTask];

USE [DapperTask];

CREATE TABLE [AppUser]
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
    [InsertDate] DATETIME NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_Order_AppUser] FOREIGN KEY ([UserId]) REFERENCES [AppUser]([Id])
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
    CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id])
);

-- ALTER TABLE [Order] ADD [TotalPrice] AS (SELECT SUM([TotalPrice]) FROM [OrderDetail] WHERE [OrderDetail].[OrderId] = [Orders].[Id]) PERSISTED;

-- -- Trigger to update TotalPrice after insert
-- CREATE TRIGGER trg_UpdateOrderTotalPriceAfterInsert
-- ON [OrderDetail]
-- AFTER INSERT
-- AS
-- BEGIN
--     SET NOCOUNT ON;
--     UPDATE o
--     SET TotalPrice = (SELECT SUM(TotalPrice)
--     FROM [OrderDetail]
--     WHERE OrderId = o.Id)
--     FROM [Order] o
--         JOIN inserted i ON o.Id = i.OrderId;
-- END;

-- -- Trigger to update TotalPrice after update
-- CREATE TRIGGER trg_UpdateOrderTotalPriceAfterUpdate
-- ON [OrderDetail]
-- AFTER UPDATE
-- AS
-- BEGIN
--     SET NOCOUNT ON;
--     UPDATE o
--     SET TotalPrice = (SELECT SUM(TotalPrice)
--     FROM [OrderDetail]
--     WHERE OrderId = o.Id)
--     FROM [Order] o
--         JOIN inserted i ON o.Id = i.OrderId;
-- END;

-- -- Trigger to update TotalPrice after delete
-- CREATE TRIGGER trg_UpdateOrderTotalPriceAfterDelete
-- ON [OrderDetail]
-- AFTER DELETE
-- AS
-- BEGIN
--     SET NOCOUNT ON;
--     UPDATE o
--     SET TotalPrice = (SELECT SUM(TotalPrice)
--     FROM [OrderDetail]
--     WHERE OrderId = o.Id)
--     FROM [Order] o
--         JOIN deleted d ON o.Id = d.OrderId;
-- END;
