IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ClientData] (
    [ID] int NOT NULL IDENTITY,
    [ClientName] nvarchar(450) NOT NULL,
    [DataType] nvarchar(450) NOT NULL,
    [JSONData] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ClientData] PRIMARY KEY ([ID])
);
GO

CREATE UNIQUE INDEX [IX_ClientData_ClientName_DataType] ON [ClientData] ([ClientName], [DataType]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230518112616_InitialCreate', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230518112647_UpdateClientDataJson', N'7.0.5');
GO

COMMIT;
GO

