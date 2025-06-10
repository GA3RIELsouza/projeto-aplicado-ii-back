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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [branch_size] (
        [id] bigint NOT NULL IDENTITY,
        [description] nvarchar(32) NOT NULL,
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        CONSTRAINT [PK_branch_size] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [company] (
        [id] bigint NOT NULL IDENTITY,
        [legal_name] nvarchar(128) NOT NULL,
        [business_name] nvarchar(128) NOT NULL,
        [email] nvarchar(254) NOT NULL,
        [phone] nvarchar(32) NOT NULL,
        [tax_id] nvarchar(64) NOT NULL,
        [is_active] bit NOT NULL DEFAULT CAST(1 AS bit),
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        CONSTRAINT [PK_company] PRIMARY KEY ([id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Razão Social';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'company', 'COLUMN', N'legal_name';
    SET @description = N'Nome Fantasia';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'company', 'COLUMN', N'business_name';
    SET @description = N'CNPJ';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'company', 'COLUMN', N'tax_id';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [unity_of_measure] (
        [id] bigint NOT NULL IDENTITY,
        [Description] nvarchar(64) NOT NULL,
        [Symbol] nvarchar(8) NOT NULL,
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        CONSTRAINT [PK_unity_of_measure] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [user] (
        [id] bigint NOT NULL IDENTITY,
        [name] nvarchar(64) NOT NULL,
        [email] nvarchar(254) NOT NULL,
        [password_hash] binary(32) NOT NULL,
        [password_salt_hash] binary(16) NOT NULL,
        [is_admin] bit NOT NULL DEFAULT CAST(0 AS bit),
        [is_active] bit NOT NULL DEFAULT CAST(1 AS bit),
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        CONSTRAINT [PK_user] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [branch] (
        [id] bigint NOT NULL IDENTITY,
        [name] nvarchar(128) NOT NULL,
        [street] nvarchar(256) NOT NULL,
        [number] nvarchar(16) NOT NULL,
        [neighborhood] nvarchar(128) NOT NULL,
        [city] nvarchar(128) NOT NULL,
        [state] nvarchar(128) NOT NULL,
        [country] nvarchar(128) NOT NULL,
        [branch_size_id] bigint NOT NULL,
        [is_active] bit NOT NULL DEFAULT CAST(1 AS bit),
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        [company_id] bigint NOT NULL,
        CONSTRAINT [PK_branch] PRIMARY KEY ([id]),
        CONSTRAINT [FK_branch_branch_size_branch_size_id] FOREIGN KEY ([branch_size_id]) REFERENCES [branch_size] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_branch_company_company_id] FOREIGN KEY ([company_id]) REFERENCES [company] ([id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [product_category] (
        [id] bigint NOT NULL IDENTITY,
        [description] nvarchar(128) NOT NULL,
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        [company_id] bigint NOT NULL,
        CONSTRAINT [PK_product_category] PRIMARY KEY ([id]),
        CONSTRAINT [FK_product_category_company_company_id] FOREIGN KEY ([company_id]) REFERENCES [company] ([id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [supplier] (
        [id] bigint NOT NULL IDENTITY,
        [legal_name] nvarchar(128) NOT NULL,
        [business_name] nvarchar(128) NOT NULL,
        [tax_id] nvarchar(20) NOT NULL,
        [street] nvarchar(256) NOT NULL,
        [number] nvarchar(16) NOT NULL,
        [neighborhood] nvarchar(128) NOT NULL,
        [city] nvarchar(128) NOT NULL,
        [state] nvarchar(128) NOT NULL,
        [country] nvarchar(128) NOT NULL,
        [email] nvarchar(254) NOT NULL,
        [phone] nvarchar(15) NOT NULL,
        [is_active] bit NOT NULL DEFAULT CAST(1 AS bit),
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        [company_id] bigint NOT NULL,
        CONSTRAINT [PK_supplier] PRIMARY KEY ([id]),
        CONSTRAINT [FK_supplier_company_company_id] FOREIGN KEY ([company_id]) REFERENCES [company] ([id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [user_branch] (
        [id] bigint NOT NULL IDENTITY,
        [user_id] bigint NOT NULL,
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        [company_id] bigint NOT NULL,
        CONSTRAINT [PK_user_branch] PRIMARY KEY ([id]),
        CONSTRAINT [FK_user_branch_branch_company_id] FOREIGN KEY ([company_id]) REFERENCES [branch] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_user_branch_user_user_id] FOREIGN KEY ([user_id]) REFERENCES [user] ([id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [product] (
        [id] bigint NOT NULL IDENTITY,
        [name] nvarchar(128) NOT NULL,
        [ean_13_bar_code] nchar(13) NOT NULL,
        [image_url] nvarchar(256) NULL,
        [product_category_id] bigint NOT NULL,
        [unitary_selling_price] decimal(8,2) NOT NULL,
        [unity_of_measure_id] bigint NOT NULL,
        [minimal_inventory_quantity] int NOT NULL DEFAULT 10,
        [is_active] bit NOT NULL DEFAULT CAST(1 AS bit),
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        [company_id] bigint NOT NULL,
        CONSTRAINT [PK_product] PRIMARY KEY ([id]),
        CONSTRAINT [FK_product_company_company_id] FOREIGN KEY ([company_id]) REFERENCES [company] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_product_product_category_product_category_id] FOREIGN KEY ([product_category_id]) REFERENCES [product_category] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_product_unity_of_measure_unity_of_measure_id] FOREIGN KEY ([unity_of_measure_id]) REFERENCES [unity_of_measure] ([id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [sale] (
        [id] bigint NOT NULL IDENTITY,
        [sale_date_time] datetime2 NOT NULL,
        [SupplierId] bigint NULL,
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        [company_id] bigint NOT NULL,
        CONSTRAINT [PK_sale] PRIMARY KEY ([id]),
        CONSTRAINT [FK_sale_branch_company_id] FOREIGN KEY ([company_id]) REFERENCES [branch] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_sale_supplier_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [supplier] ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [supplier_product] (
        [id] bigint NOT NULL IDENTITY,
        [supplier_id] bigint NOT NULL,
        [product_id] bigint NOT NULL,
        [unitary_price] decimal(8,2) NOT NULL,
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        CONSTRAINT [PK_supplier_product] PRIMARY KEY ([id]),
        CONSTRAINT [FK_supplier_product_product_product_id] FOREIGN KEY ([product_id]) REFERENCES [product] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_supplier_product_supplier_supplier_id] FOREIGN KEY ([supplier_id]) REFERENCES [supplier] ([id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [sale_item] (
        [id] bigint NOT NULL IDENTITY,
        [sale_id] bigint NOT NULL,
        [product_id] bigint NOT NULL,
        [quantity] int NOT NULL,
        [SupplierId] bigint NULL,
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        CONSTRAINT [PK_sale_item] PRIMARY KEY ([id]),
        CONSTRAINT [FK_sale_item_product_product_id] FOREIGN KEY ([product_id]) REFERENCES [product] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_sale_item_sale_sale_id] FOREIGN KEY ([sale_id]) REFERENCES [sale] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_sale_item_supplier_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [supplier] ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE TABLE [product_in_inventory] (
        [id] bigint NOT NULL IDENTITY,
        [product_id] bigint NOT NULL,
        [SupplierId] bigint NOT NULL,
        [ManufacturingDate] date NOT NULL,
        [sale_item_id] bigint NULL,
        [created_at] datetime2 NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        [updated_at] datetime2 NULL,
        [branch_id] bigint NOT NULL,
        CONSTRAINT [PK_product_in_inventory] PRIMARY KEY ([id]),
        CONSTRAINT [FK_product_in_inventory_branch_branch_id] FOREIGN KEY ([branch_id]) REFERENCES [branch] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_product_in_inventory_product_product_id] FOREIGN KEY ([product_id]) REFERENCES [product] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_product_in_inventory_sale_item_sale_item_id] FOREIGN KEY ([sale_item_id]) REFERENCES [sale_item] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_product_in_inventory_supplier_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [supplier] ([id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'created_at', N'description', N'updated_at') AND [object_id] = OBJECT_ID(N'[branch_size]'))
        SET IDENTITY_INSERT [branch_size] ON;
    EXEC(N'INSERT INTO [branch_size] ([id], [created_at], [description], [updated_at])
    VALUES (CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', N''Pequena'', NULL),
    (CAST(2 AS bigint), ''2025-09-06T12:30:00.0000000Z'', N''Média'', NULL),
    (CAST(3 AS bigint), ''2025-09-06T12:30:00.0000000Z'', N''Grande'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'created_at', N'description', N'updated_at') AND [object_id] = OBJECT_ID(N'[branch_size]'))
        SET IDENTITY_INSERT [branch_size] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'business_name', N'email', N'is_active', N'legal_name', N'phone', N'tax_id', N'updated_at') AND [object_id] = OBJECT_ID(N'[company]'))
        SET IDENTITY_INSERT [company] ON;
    EXEC(N'INSERT INTO [company] ([id], [business_name], [email], [is_active], [legal_name], [phone], [tax_id], [updated_at])
    VALUES (CAST(1 AS bigint), N''Empresa Padrão LTDA'', N''empresa.padrao@company.com'', CAST(1 AS bit), N''Empresa Padrão'', N''55 47 0001-0001'', N''00.000.000/0001-01'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'business_name', N'email', N'is_active', N'legal_name', N'phone', N'tax_id', N'updated_at') AND [object_id] = OBJECT_ID(N'[company]'))
        SET IDENTITY_INSERT [company] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'Description', N'Symbol', N'updated_at') AND [object_id] = OBJECT_ID(N'[unity_of_measure]'))
        SET IDENTITY_INSERT [unity_of_measure] ON;
    EXEC(N'INSERT INTO [unity_of_measure] ([id], [Description], [Symbol], [updated_at])
    VALUES (CAST(1 AS bigint), N''Unidade'', N''UN'', NULL),
    (CAST(2 AS bigint), N''Quilograma'', N''kg'', NULL),
    (CAST(3 AS bigint), N''Grama'', N''g'', NULL),
    (CAST(4 AS bigint), N''Miligrama'', N''mg'', NULL),
    (CAST(5 AS bigint), N''Litro'', N''L'', NULL),
    (CAST(6 AS bigint), N''Mililitro'', N''mL'', NULL),
    (CAST(7 AS bigint), N''Quilômetro'', N''km'', NULL),
    (CAST(8 AS bigint), N''Metro'', N''m'', NULL),
    (CAST(9 AS bigint), N''Milímetro'', N''ml'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'Description', N'Symbol', N'updated_at') AND [object_id] = OBJECT_ID(N'[unity_of_measure]'))
        SET IDENTITY_INSERT [unity_of_measure] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'created_at', N'email', N'is_active', N'is_admin', N'name', N'password_hash', N'password_salt_hash', N'updated_at') AND [object_id] = OBJECT_ID(N'[user]'))
        SET IDENTITY_INSERT [user] ON;
    EXEC(N'INSERT INTO [user] ([id], [created_at], [email], [is_active], [is_admin], [name], [password_hash], [password_salt_hash], [updated_at])
    VALUES (CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', N''admin@admin.com'', CAST(1 AS bit), CAST(1 AS bit), N''Admin'', 0x6A512C504B9DDCCFB9FACA0D0A3B758AACE64ADFBD01984292B4AE096809037E, 0x63D45DC55D7F5697325E506C40E81698, NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'created_at', N'email', N'is_active', N'is_admin', N'name', N'password_hash', N'password_salt_hash', N'updated_at') AND [object_id] = OBJECT_ID(N'[user]'))
        SET IDENTITY_INSERT [user] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'branch_size_id', N'city', N'company_id', N'country', N'is_active', N'name', N'neighborhood', N'number', N'state', N'street', N'updated_at') AND [object_id] = OBJECT_ID(N'[branch]'))
        SET IDENTITY_INSERT [branch] ON;
    EXEC(N'INSERT INTO [branch] ([id], [branch_size_id], [city], [company_id], [country], [is_active], [name], [neighborhood], [number], [state], [street], [updated_at])
    VALUES (CAST(1 AS bigint), CAST(1 AS bigint), N''Cidade Exemplo'', CAST(1 AS bigint), N''Brasil'', CAST(1 AS bit), N''Filial Padrão 1'', N''Bairro Exemplo'', N''11'', N''EX'', N''Rua Exemplo 1'', NULL),
    (CAST(2 AS bigint), CAST(2 AS bigint), N''Cidade Exemplo'', CAST(1 AS bigint), N''Brasil'', CAST(1 AS bit), N''Filial Padrão 2'', N''Bairro Exemplo'', N''21'', N''EX'', N''Rua Exemplo 2'', NULL),
    (CAST(3 AS bigint), CAST(3 AS bigint), N''Cidade Exemplo'', CAST(1 AS bigint), N''Brasil'', CAST(1 AS bit), N''Filial Padrão 3'', N''Bairro Exemplo'', N''31'', N''EX'', N''Rua Exemplo 3'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'branch_size_id', N'city', N'company_id', N'country', N'is_active', N'name', N'neighborhood', N'number', N'state', N'street', N'updated_at') AND [object_id] = OBJECT_ID(N'[branch]'))
        SET IDENTITY_INSERT [branch] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'company_id', N'description', N'updated_at') AND [object_id] = OBJECT_ID(N'[product_category]'))
        SET IDENTITY_INSERT [product_category] ON;
    EXEC(N'INSERT INTO [product_category] ([id], [company_id], [description], [updated_at])
    VALUES (CAST(1 AS bigint), CAST(1 AS bigint), N''Hortifruti'', NULL),
    (CAST(2 AS bigint), CAST(1 AS bigint), N''Bebidas'', NULL),
    (CAST(3 AS bigint), CAST(1 AS bigint), N''Carnes, Aves e Peixes'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'company_id', N'description', N'updated_at') AND [object_id] = OBJECT_ID(N'[product_category]'))
        SET IDENTITY_INSERT [product_category] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'business_name', N'city', N'company_id', N'country', N'email', N'is_active', N'legal_name', N'neighborhood', N'number', N'phone', N'state', N'street', N'tax_id', N'updated_at') AND [object_id] = OBJECT_ID(N'[supplier]'))
        SET IDENTITY_INSERT [supplier] ON;
    EXEC(N'INSERT INTO [supplier] ([id], [business_name], [city], [company_id], [country], [email], [is_active], [legal_name], [neighborhood], [number], [phone], [state], [street], [tax_id], [updated_at])
    VALUES (CAST(1 AS bigint), N''Fornecedor Padrão 1'', N''Cidade Exemplo'', CAST(1 AS bigint), N''Brasil'', N''fornecedor.padrao1@supplier.com'', CAST(1 AS bit), N''Fornecedor Padrão 1'', N''Bairro Exemplo'', N''12'', N''55 47 0001-0002'', N''EX'', N''Rua Exemplo 1'', N''00.000.000/0001-02'', NULL),
    (CAST(2 AS bigint), N''Fornecedor Padrão 2'', N''Cidade Exemplo'', CAST(1 AS bigint), N''Brasil'', N''fornecedor.padrao2@supplier.com'', CAST(1 AS bit), N''Fornecedor Padrão 2'', N''Bairro Exemplo'', N''22'', N''55 47 0002-0002'', N''EX'', N''Rua Exemplo 2'', N''00.000.000/0002-02'', NULL),
    (CAST(3 AS bigint), N''Fornecedor Padrão 3'', N''Cidade Exemplo'', CAST(1 AS bigint), N''Brasil'', N''fornecedor.padrao3@supplier.com'', CAST(1 AS bit), N''Fornecedor Padrão 3'', N''Bairro Exemplo'', N''32'', N''55 47 0003-0002'', N''EX'', N''Rua Exemplo 3'', N''00.000.000/0003-02'', NULL),
    (CAST(4 AS bigint), N''Fornecedor Padrão 4'', N''Cidade Exemplo'', CAST(1 AS bigint), N''Brasil'', N''fornecedor.padrao4@supplier.com'', CAST(1 AS bit), N''Fornecedor Padrão 4'', N''Bairro Exemplo'', N''42'', N''55 47 0004-0002'', N''EX'', N''Rua Exemplo 4'', N''00.000.000/0004-02'', NULL),
    (CAST(5 AS bigint), N''Fornecedor Padrão 5'', N''Cidade Exemplo'', CAST(1 AS bigint), N''Brasil'', N''fornecedor.padrao5@supplier.com'', CAST(1 AS bit), N''Fornecedor Padrão 5'', N''Bairro Exemplo'', N''52'', N''55 47 0005-0002'', N''EX'', N''Rua Exemplo 5'', N''00.000.000/0005-02'', NULL),
    (CAST(6 AS bigint), N''Fornecedor Padrão 6'', N''Cidade Exemplo'', CAST(1 AS bigint), N''Brasil'', N''fornecedor.padrao6@supplier.com'', CAST(1 AS bit), N''Fornecedor Padrão 6'', N''Bairro Exemplo'', N''62'', N''55 47 0006-0002'', N''EX'', N''Rua Exemplo 6'', N''00.000.000/0006-02'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'business_name', N'city', N'company_id', N'country', N'email', N'is_active', N'legal_name', N'neighborhood', N'number', N'phone', N'state', N'street', N'tax_id', N'updated_at') AND [object_id] = OBJECT_ID(N'[supplier]'))
        SET IDENTITY_INSERT [supplier] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'company_id', N'ean_13_bar_code', N'image_url', N'is_active', N'minimal_inventory_quantity', N'name', N'product_category_id', N'unitary_selling_price', N'unity_of_measure_id', N'updated_at') AND [object_id] = OBJECT_ID(N'[product]'))
        SET IDENTITY_INSERT [product] ON;
    EXEC(N'INSERT INTO [product] ([id], [company_id], [ean_13_bar_code], [image_url], [is_active], [minimal_inventory_quantity], [name], [product_category_id], [unitary_selling_price], [unity_of_measure_id], [updated_at])
    VALUES (CAST(1 AS bigint), CAST(1 AS bigint), N''7890000010016'', N''https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/152c5248ec73694bf1cf8be92c1d8e4720240227033525/450/banana-prata-kg_2019.jpg'', CAST(1 AS bit), 10, N''Banana Prata'', CAST(1 AS bigint), 6.89, CAST(2 AS bigint), NULL),
    (CAST(2 AS bigint), CAST(1 AS bigint), N''7890000010026'', N''https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/fb1a588af874d79db3c0c6ae8512a83e20240226225359/450/batata-inglesa-lavada-kg_7172.jpg'', CAST(1 AS bit), 10, N''Batata Inglesa Lavada'', CAST(1 AS bigint), 5.98, CAST(2 AS bigint), NULL),
    (CAST(3 AS bigint), CAST(1 AS bigint), N''7890000010036'', N''https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/d72ca3f78b35715d1308a4cb6a6fcba220250520141235/450/suco-integral-laranja-prats-garrafa-1-5l_2294.jpg'', CAST(1 AS bit), 10, N''Suco Integral Laranja Prat''''s Garrafa 1,5l'', CAST(2 AS bigint), 23.99, CAST(1 AS bigint), NULL),
    (CAST(4 AS bigint), CAST(1 AS bigint), N''7890000010046'', N''https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/e7e4a170a063c2102b4470ce991b714a20250409101224/450/vinho-chileno-cabernet-sauvignon-montes-reserva-garrafa-750ml_8040.jpg'', CAST(1 AS bit), 10, N''Vinho Chileno Cabernet Sauvignon Montes Reserva Garrafa 750ml'', CAST(2 AS bigint), 99.9, CAST(1 AS bigint), NULL),
    (CAST(5 AS bigint), CAST(1 AS bigint), N''7890000010056'', N''https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/620ec78bf82c5deb224d95c0544a8f1e20250514171231/450/costela-bovina-precoce-verdi-kg_2380.jpg'', CAST(1 AS bit), 10, N''Costela Bovina Precoce Verdi'', CAST(3 AS bigint), 36.98, CAST(2 AS bigint), NULL),
    (CAST(6 AS bigint), CAST(1 AS bigint), N''7890000010066'', N''https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/8e15f72024db65d4faac6f3f07b2777920250509081238/450/file-simples-bovino-precoce-verdi-kg_4970.jpg'', CAST(1 AS bit), 10, N''Filé Simples Bovino Precoce Verdi'', CAST(3 AS bigint), 47.9, CAST(2 AS bigint), NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'company_id', N'ean_13_bar_code', N'image_url', N'is_active', N'minimal_inventory_quantity', N'name', N'product_category_id', N'unitary_selling_price', N'unity_of_measure_id', N'updated_at') AND [object_id] = OBJECT_ID(N'[product]'))
        SET IDENTITY_INSERT [product] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'company_id', N'sale_date_time', N'SupplierId', N'updated_at') AND [object_id] = OBJECT_ID(N'[sale]'))
        SET IDENTITY_INSERT [sale] ON;
    EXEC(N'INSERT INTO [sale] ([id], [company_id], [sale_date_time], [SupplierId], [updated_at])
    VALUES (CAST(1 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL),
    (CAST(2 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL),
    (CAST(3 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL),
    (CAST(4 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL),
    (CAST(5 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL),
    (CAST(6 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL),
    (CAST(7 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL),
    (CAST(8 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL),
    (CAST(9 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL),
    (CAST(10 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL),
    (CAST(11 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL),
    (CAST(12 AS bigint), CAST(1 AS bigint), ''2025-09-06T12:30:00.0000000Z'', NULL, NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'company_id', N'sale_date_time', N'SupplierId', N'updated_at') AND [object_id] = OBJECT_ID(N'[sale]'))
        SET IDENTITY_INSERT [sale] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'company_id', N'updated_at', N'user_id') AND [object_id] = OBJECT_ID(N'[user_branch]'))
        SET IDENTITY_INSERT [user_branch] ON;
    EXEC(N'INSERT INTO [user_branch] ([id], [company_id], [updated_at], [user_id])
    VALUES (CAST(1 AS bigint), CAST(1 AS bigint), NULL, CAST(1 AS bigint)),
    (CAST(2 AS bigint), CAST(2 AS bigint), NULL, CAST(1 AS bigint)),
    (CAST(3 AS bigint), CAST(3 AS bigint), NULL, CAST(1 AS bigint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'company_id', N'updated_at', N'user_id') AND [object_id] = OBJECT_ID(N'[user_branch]'))
        SET IDENTITY_INSERT [user_branch] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'branch_id', N'ManufacturingDate', N'product_id', N'sale_item_id', N'SupplierId', N'updated_at') AND [object_id] = OBJECT_ID(N'[product_in_inventory]'))
        SET IDENTITY_INSERT [product_in_inventory] ON;
    EXEC(N'INSERT INTO [product_in_inventory] ([id], [branch_id], [ManufacturingDate], [product_id], [sale_item_id], [SupplierId], [updated_at])
    VALUES (CAST(1 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), NULL, CAST(1 AS bigint), NULL),
    (CAST(2 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), NULL, CAST(1 AS bigint), NULL),
    (CAST(3 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), NULL, CAST(1 AS bigint), NULL),
    (CAST(4 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), NULL, CAST(1 AS bigint), NULL),
    (CAST(5 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), NULL, CAST(1 AS bigint), NULL),
    (CAST(6 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), NULL, CAST(1 AS bigint), NULL),
    (CAST(7 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), NULL, CAST(1 AS bigint), NULL),
    (CAST(8 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), NULL, CAST(1 AS bigint), NULL),
    (CAST(9 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), NULL, CAST(1 AS bigint), NULL),
    (CAST(10 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), NULL, CAST(1 AS bigint), NULL),
    (CAST(11 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), NULL, CAST(2 AS bigint), NULL),
    (CAST(12 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), NULL, CAST(2 AS bigint), NULL),
    (CAST(13 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), NULL, CAST(2 AS bigint), NULL),
    (CAST(14 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), NULL, CAST(2 AS bigint), NULL),
    (CAST(15 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), NULL, CAST(2 AS bigint), NULL),
    (CAST(16 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), NULL, CAST(2 AS bigint), NULL),
    (CAST(17 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), NULL, CAST(2 AS bigint), NULL),
    (CAST(18 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), NULL, CAST(2 AS bigint), NULL),
    (CAST(19 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), NULL, CAST(2 AS bigint), NULL),
    (CAST(20 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), NULL, CAST(2 AS bigint), NULL),
    (CAST(21 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), NULL, CAST(3 AS bigint), NULL),
    (CAST(22 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), NULL, CAST(3 AS bigint), NULL),
    (CAST(23 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), NULL, CAST(3 AS bigint), NULL),
    (CAST(24 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), NULL, CAST(3 AS bigint), NULL),
    (CAST(25 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), NULL, CAST(3 AS bigint), NULL),
    (CAST(26 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), NULL, CAST(3 AS bigint), NULL),
    (CAST(27 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), NULL, CAST(3 AS bigint), NULL),
    (CAST(28 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), NULL, CAST(3 AS bigint), NULL),
    (CAST(29 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), NULL, CAST(3 AS bigint), NULL),
    (CAST(30 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), NULL, CAST(3 AS bigint), NULL),
    (CAST(31 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), NULL, CAST(4 AS bigint), NULL),
    (CAST(32 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), NULL, CAST(4 AS bigint), NULL),
    (CAST(33 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), NULL, CAST(4 AS bigint), NULL),
    (CAST(34 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), NULL, CAST(4 AS bigint), NULL),
    (CAST(35 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), NULL, CAST(4 AS bigint), NULL),
    (CAST(36 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), NULL, CAST(4 AS bigint), NULL),
    (CAST(37 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), NULL, CAST(4 AS bigint), NULL),
    (CAST(38 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), NULL, CAST(4 AS bigint), NULL),
    (CAST(39 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), NULL, CAST(4 AS bigint), NULL),
    (CAST(40 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), NULL, CAST(4 AS bigint), NULL),
    (CAST(41 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), NULL, CAST(5 AS bigint), NULL),
    (CAST(42 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), NULL, CAST(5 AS bigint), NULL);
    INSERT INTO [product_in_inventory] ([id], [branch_id], [ManufacturingDate], [product_id], [sale_item_id], [SupplierId], [updated_at])
    VALUES (CAST(43 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), NULL, CAST(5 AS bigint), NULL),
    (CAST(44 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), NULL, CAST(5 AS bigint), NULL),
    (CAST(45 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), NULL, CAST(5 AS bigint), NULL),
    (CAST(46 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), NULL, CAST(5 AS bigint), NULL),
    (CAST(47 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), NULL, CAST(5 AS bigint), NULL),
    (CAST(48 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), NULL, CAST(5 AS bigint), NULL),
    (CAST(49 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), NULL, CAST(5 AS bigint), NULL),
    (CAST(50 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), NULL, CAST(5 AS bigint), NULL),
    (CAST(51 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), NULL, CAST(6 AS bigint), NULL),
    (CAST(52 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), NULL, CAST(6 AS bigint), NULL),
    (CAST(53 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), NULL, CAST(6 AS bigint), NULL),
    (CAST(54 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), NULL, CAST(6 AS bigint), NULL),
    (CAST(55 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), NULL, CAST(6 AS bigint), NULL),
    (CAST(56 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), NULL, CAST(6 AS bigint), NULL),
    (CAST(57 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), NULL, CAST(6 AS bigint), NULL),
    (CAST(58 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), NULL, CAST(6 AS bigint), NULL),
    (CAST(59 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), NULL, CAST(6 AS bigint), NULL),
    (CAST(60 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), NULL, CAST(6 AS bigint), NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'branch_id', N'ManufacturingDate', N'product_id', N'sale_item_id', N'SupplierId', N'updated_at') AND [object_id] = OBJECT_ID(N'[product_in_inventory]'))
        SET IDENTITY_INSERT [product_in_inventory] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'product_id', N'quantity', N'sale_id', N'SupplierId', N'updated_at') AND [object_id] = OBJECT_ID(N'[sale_item]'))
        SET IDENTITY_INSERT [sale_item] ON;
    EXEC(N'INSERT INTO [sale_item] ([id], [product_id], [quantity], [sale_id], [SupplierId], [updated_at])
    VALUES (CAST(1 AS bigint), CAST(1 AS bigint), 2, CAST(1 AS bigint), NULL, NULL),
    (CAST(2 AS bigint), CAST(1 AS bigint), 2, CAST(2 AS bigint), NULL, NULL),
    (CAST(3 AS bigint), CAST(2 AS bigint), 2, CAST(3 AS bigint), NULL, NULL),
    (CAST(4 AS bigint), CAST(2 AS bigint), 2, CAST(4 AS bigint), NULL, NULL),
    (CAST(5 AS bigint), CAST(3 AS bigint), 2, CAST(5 AS bigint), NULL, NULL),
    (CAST(6 AS bigint), CAST(3 AS bigint), 2, CAST(6 AS bigint), NULL, NULL),
    (CAST(7 AS bigint), CAST(4 AS bigint), 2, CAST(7 AS bigint), NULL, NULL),
    (CAST(8 AS bigint), CAST(4 AS bigint), 2, CAST(8 AS bigint), NULL, NULL),
    (CAST(9 AS bigint), CAST(5 AS bigint), 2, CAST(9 AS bigint), NULL, NULL),
    (CAST(10 AS bigint), CAST(5 AS bigint), 2, CAST(10 AS bigint), NULL, NULL),
    (CAST(11 AS bigint), CAST(6 AS bigint), 2, CAST(11 AS bigint), NULL, NULL),
    (CAST(12 AS bigint), CAST(6 AS bigint), 2, CAST(12 AS bigint), NULL, NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'product_id', N'quantity', N'sale_id', N'SupplierId', N'updated_at') AND [object_id] = OBJECT_ID(N'[sale_item]'))
        SET IDENTITY_INSERT [sale_item] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'product_id', N'supplier_id', N'unitary_price', N'updated_at') AND [object_id] = OBJECT_ID(N'[supplier_product]'))
        SET IDENTITY_INSERT [supplier_product] ON;
    EXEC(N'INSERT INTO [supplier_product] ([id], [product_id], [supplier_id], [unitary_price], [updated_at])
    VALUES (CAST(1 AS bigint), CAST(1 AS bigint), CAST(1 AS bigint), 0.99, NULL),
    (CAST(2 AS bigint), CAST(2 AS bigint), CAST(2 AS bigint), 1.98, NULL),
    (CAST(3 AS bigint), CAST(3 AS bigint), CAST(3 AS bigint), 2.97, NULL),
    (CAST(4 AS bigint), CAST(4 AS bigint), CAST(4 AS bigint), 3.96, NULL),
    (CAST(5 AS bigint), CAST(5 AS bigint), CAST(5 AS bigint), 4.95, NULL),
    (CAST(6 AS bigint), CAST(6 AS bigint), CAST(6 AS bigint), 5.94, NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'product_id', N'supplier_id', N'unitary_price', N'updated_at') AND [object_id] = OBJECT_ID(N'[supplier_product]'))
        SET IDENTITY_INSERT [supplier_product] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'branch_id', N'ManufacturingDate', N'product_id', N'sale_item_id', N'SupplierId', N'updated_at') AND [object_id] = OBJECT_ID(N'[product_in_inventory]'))
        SET IDENTITY_INSERT [product_in_inventory] ON;
    EXEC(N'INSERT INTO [product_in_inventory] ([id], [branch_id], [ManufacturingDate], [product_id], [sale_item_id], [SupplierId], [updated_at])
    VALUES (CAST(61 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), CAST(1 AS bigint), CAST(1 AS bigint), NULL),
    (CAST(62 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), CAST(1 AS bigint), CAST(1 AS bigint), NULL),
    (CAST(63 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), CAST(2 AS bigint), CAST(1 AS bigint), NULL),
    (CAST(64 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(1 AS bigint), CAST(2 AS bigint), CAST(1 AS bigint), NULL),
    (CAST(65 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), CAST(3 AS bigint), CAST(2 AS bigint), NULL),
    (CAST(66 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), CAST(3 AS bigint), CAST(2 AS bigint), NULL),
    (CAST(67 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), CAST(4 AS bigint), CAST(2 AS bigint), NULL),
    (CAST(68 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(2 AS bigint), CAST(4 AS bigint), CAST(2 AS bigint), NULL),
    (CAST(69 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), CAST(5 AS bigint), CAST(3 AS bigint), NULL),
    (CAST(70 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), CAST(5 AS bigint), CAST(3 AS bigint), NULL),
    (CAST(71 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), CAST(6 AS bigint), CAST(3 AS bigint), NULL),
    (CAST(72 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(3 AS bigint), CAST(6 AS bigint), CAST(3 AS bigint), NULL),
    (CAST(73 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), CAST(7 AS bigint), CAST(4 AS bigint), NULL),
    (CAST(74 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), CAST(7 AS bigint), CAST(4 AS bigint), NULL),
    (CAST(75 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), CAST(8 AS bigint), CAST(4 AS bigint), NULL),
    (CAST(76 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(4 AS bigint), CAST(8 AS bigint), CAST(4 AS bigint), NULL),
    (CAST(77 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), CAST(9 AS bigint), CAST(5 AS bigint), NULL),
    (CAST(78 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), CAST(9 AS bigint), CAST(5 AS bigint), NULL),
    (CAST(79 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), CAST(10 AS bigint), CAST(5 AS bigint), NULL),
    (CAST(80 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(5 AS bigint), CAST(10 AS bigint), CAST(5 AS bigint), NULL),
    (CAST(81 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), CAST(11 AS bigint), CAST(6 AS bigint), NULL),
    (CAST(82 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), CAST(11 AS bigint), CAST(6 AS bigint), NULL),
    (CAST(83 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), CAST(12 AS bigint), CAST(6 AS bigint), NULL),
    (CAST(84 AS bigint), CAST(1 AS bigint), ''0001-01-01'', CAST(6 AS bigint), CAST(12 AS bigint), CAST(6 AS bigint), NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'branch_id', N'ManufacturingDate', N'product_id', N'sale_item_id', N'SupplierId', N'updated_at') AND [object_id] = OBJECT_ID(N'[product_in_inventory]'))
        SET IDENTITY_INSERT [product_in_inventory] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_branch_branch_size_id] ON [branch] ([branch_size_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_branch_company_id] ON [branch] ([company_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE UNIQUE INDEX [IX_company_tax_id] ON [company] ([tax_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_product_company_id] ON [product] ([company_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE UNIQUE INDEX [IX_product_ean_13_bar_code] ON [product] ([ean_13_bar_code]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_product_product_category_id] ON [product] ([product_category_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_product_unity_of_measure_id] ON [product] ([unity_of_measure_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_product_category_company_id] ON [product_category] ([company_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_product_in_inventory_branch_id] ON [product_in_inventory] ([branch_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_product_in_inventory_product_id] ON [product_in_inventory] ([product_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_product_in_inventory_sale_item_id] ON [product_in_inventory] ([sale_item_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_product_in_inventory_SupplierId] ON [product_in_inventory] ([SupplierId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_sale_company_id] ON [sale] ([company_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_sale_SupplierId] ON [sale] ([SupplierId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_sale_item_product_id] ON [sale_item] ([product_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_sale_item_sale_id] ON [sale_item] ([sale_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_sale_item_SupplierId] ON [sale_item] ([SupplierId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_supplier_company_id] ON [supplier] ([company_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_supplier_product_product_id] ON [supplier_product] ([product_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE UNIQUE INDEX [IX_supplier_product_supplier_id_product_id] ON [supplier_product] ([supplier_id], [product_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE UNIQUE INDEX [IX_user_email] ON [user] ([email]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE INDEX [IX_user_branch_company_id] ON [user_branch] ([company_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    CREATE UNIQUE INDEX [IX_user_branch_user_id_company_id] ON [user_branch] ([user_id], [company_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250609110534_mssql.onprem_migration_921'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250609110534_mssql.onprem_migration_921', N'9.0.5');
END;

COMMIT;
GO

