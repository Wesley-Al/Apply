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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012635_Att_1.2')
BEGIN
    CREATE TABLE [Card] (
        [CodCard] bigint NOT NULL IDENTITY,
        [NotPayment] bit NOT NULL,
        [Amount] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Time] datetime2 NOT NULL,
        [TimeString] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [CodWallet] bigint NOT NULL,
        CONSTRAINT [PK_Card] PRIMARY KEY ([CodCard])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012635_Att_1.2')
BEGIN
    CREATE TABLE [FlowClosed] (
        [CodFlowClosed] bigint NOT NULL IDENTITY,
        [Amount] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Time] datetime2 NOT NULL,
        [TimeString] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [CodWallet] bigint NOT NULL,
        CONSTRAINT [PK_FlowClosed] PRIMARY KEY ([CodFlowClosed])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012635_Att_1.2')
BEGIN
    CREATE TABLE [Payment] (
        [CodPayment] bigint NOT NULL IDENTITY,
        [Amount] nvarchar(max) NULL,
        [Time] datetime2 NOT NULL,
        [TimeString] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [CodWallet] bigint NOT NULL,
        CONSTRAINT [PK_Payment] PRIMARY KEY ([CodPayment])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012635_Att_1.2')
BEGIN
    CREATE TABLE [Usuario] (
        [CodUsuario] bigint NOT NULL IDENTITY,
        [DtCadastro] datetime2 NOT NULL,
        [Nome] nvarchar(max) NULL,
        CONSTRAINT [PK_Usuario] PRIMARY KEY ([CodUsuario])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012635_Att_1.2')
BEGIN
    CREATE TABLE [Wallet] (
        [CodWallet] bigint NOT NULL IDENTITY,
        [DtCadastro] datetime2 NOT NULL,
        [CodUsuario] int NOT NULL,
        [UsuarioNavigationCodUsuario] bigint NULL,
        [CodPayment] int NOT NULL,
        [PaymentNavigationCodPayment] bigint NULL,
        [CodCards] int NOT NULL,
        [CardsNavigationCodCard] bigint NULL,
        [CodFlowClosed] int NOT NULL,
        [FlowClosedNavigationCodFlowClosed] bigint NULL,
        CONSTRAINT [PK_Wallet] PRIMARY KEY ([CodWallet]),
        CONSTRAINT [FK_Wallet_Card_CardsNavigationCodCard] FOREIGN KEY ([CardsNavigationCodCard]) REFERENCES [Card] ([CodCard]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Wallet_FlowClosed_FlowClosedNavigationCodFlowClosed] FOREIGN KEY ([FlowClosedNavigationCodFlowClosed]) REFERENCES [FlowClosed] ([CodFlowClosed]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Wallet_Payment_PaymentNavigationCodPayment] FOREIGN KEY ([PaymentNavigationCodPayment]) REFERENCES [Payment] ([CodPayment]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Wallet_Usuario_UsuarioNavigationCodUsuario] FOREIGN KEY ([UsuarioNavigationCodUsuario]) REFERENCES [Usuario] ([CodUsuario]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012635_Att_1.2')
BEGIN
    CREATE INDEX [IX_Wallet_CardsNavigationCodCard] ON [Wallet] ([CardsNavigationCodCard]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012635_Att_1.2')
BEGIN
    CREATE INDEX [IX_Wallet_FlowClosedNavigationCodFlowClosed] ON [Wallet] ([FlowClosedNavigationCodFlowClosed]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012635_Att_1.2')
BEGIN
    CREATE INDEX [IX_Wallet_PaymentNavigationCodPayment] ON [Wallet] ([PaymentNavigationCodPayment]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012635_Att_1.2')
BEGIN
    CREATE INDEX [IX_Wallet_UsuarioNavigationCodUsuario] ON [Wallet] ([UsuarioNavigationCodUsuario]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012635_Att_1.2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210810012635_Att_1.2', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012706_Att_1.3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210810012706_Att_1.3', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810012835_Att_1.4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210810012835_Att_1.4', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    ALTER TABLE [Wallet] DROP CONSTRAINT [FK_Wallet_Card_CardsNavigationCodCard];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    ALTER TABLE [Wallet] DROP CONSTRAINT [FK_Wallet_FlowClosed_FlowClosedNavigationCodFlowClosed];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    ALTER TABLE [Wallet] DROP CONSTRAINT [FK_Wallet_Payment_PaymentNavigationCodPayment];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    DROP INDEX [IX_Wallet_CardsNavigationCodCard] ON [Wallet];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    DROP INDEX [IX_Wallet_FlowClosedNavigationCodFlowClosed] ON [Wallet];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    DROP INDEX [IX_Wallet_PaymentNavigationCodPayment] ON [Wallet];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Wallet]') AND [c].[name] = N'CardsNavigationCodCard');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Wallet] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Wallet] DROP COLUMN [CardsNavigationCodCard];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Wallet]') AND [c].[name] = N'FlowClosedNavigationCodFlowClosed');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Wallet] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Wallet] DROP COLUMN [FlowClosedNavigationCodFlowClosed];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Wallet]') AND [c].[name] = N'PaymentNavigationCodPayment');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Wallet] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Wallet] DROP COLUMN [PaymentNavigationCodPayment];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    ALTER TABLE [Payment] ADD [WalletCodWallet] bigint NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    ALTER TABLE [FlowClosed] ADD [WalletCodWallet] bigint NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    ALTER TABLE [Card] ADD [WalletCodWallet] bigint NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    CREATE INDEX [IX_Payment_WalletCodWallet] ON [Payment] ([WalletCodWallet]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    CREATE INDEX [IX_FlowClosed_WalletCodWallet] ON [FlowClosed] ([WalletCodWallet]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    CREATE INDEX [IX_Card_WalletCodWallet] ON [Card] ([WalletCodWallet]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    ALTER TABLE [Card] ADD CONSTRAINT [FK_Card_Wallet_WalletCodWallet] FOREIGN KEY ([WalletCodWallet]) REFERENCES [Wallet] ([CodWallet]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    ALTER TABLE [FlowClosed] ADD CONSTRAINT [FK_FlowClosed_Wallet_WalletCodWallet] FOREIGN KEY ([WalletCodWallet]) REFERENCES [Wallet] ([CodWallet]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    ALTER TABLE [Payment] ADD CONSTRAINT [FK_Payment_Wallet_WalletCodWallet] FOREIGN KEY ([WalletCodWallet]) REFERENCES [Wallet] ([CodWallet]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210810014936_Att_6')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210810014936_Att_6', N'5.0.8');
END;
GO

COMMIT;
GO

