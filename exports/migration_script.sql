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

BEGIN TRANSACTION;
GO

DROP INDEX [IX_ClientData_ClientName_DataType] ON [ClientData];
DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClientData]') AND [c].[name] = N'DataType');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ClientData] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ClientData] ALTER COLUMN [DataType] nvarchar(255) NOT NULL;
CREATE UNIQUE INDEX [IX_ClientData_ClientName_DataType] ON [ClientData] ([ClientName], [DataType]);
GO

DROP INDEX [IX_ClientData_ClientName_DataType] ON [ClientData];
DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClientData]') AND [c].[name] = N'ClientName');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ClientData] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [ClientData] ALTER COLUMN [ClientName] nvarchar(255) NOT NULL;
CREATE UNIQUE INDEX [IX_ClientData_ClientName_DataType] ON [ClientData] ([ClientName], [DataType]);
GO

ALTER TABLE [ClientData] ADD [TimeAdded] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [ClientData] ADD [TimeModified] datetime2 NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230525115901_UpdateClientDataSchema', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClientData]') AND [c].[name] = N'TimeModified');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ClientData] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [ClientData] DROP COLUMN [TimeModified];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230525120126_UpdateClientDataSchema_1', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_ClientData_ClientName_DataType] ON [ClientData];
GO

CREATE UNIQUE INDEX [IX_ClientData_ClientName_DataType_TimeAdded] ON [ClientData] ([ClientName], [DataType], [TimeAdded]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230525123133_UpdateClientDataSchema_2', N'7.0.5');
GO

COMMIT;
GO

