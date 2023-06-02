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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE TABLE [Endereco] (
        [Id] int NOT NULL IDENTITY,
        [EnderecoLinha] nvarchar(max) NULL,
        [Numero] int NOT NULL,
        [Cep] nvarchar(max) NULL,
        [Bairro] nvarchar(max) NULL,
        [Cidade] nvarchar(max) NULL,
        [Estado] nvarchar(max) NULL,
        [Pais] nvarchar(max) NULL,
        [Latitude] nvarchar(max) NULL,
        [Longitude] nvarchar(max) NULL,
        [CriadoEm] datetime2 NOT NULL,
        CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE TABLE [OngFinanceiros] (
        [Id] int NOT NULL IDENTITY,
        [IdOng] int NOT NULL,
        [Tipo] nvarchar(max) NULL,
        [Data] datetime2 NOT NULL,
        [Valor] decimal(18,2) NOT NULL,
        [Origem] nvarchar(max) NULL,
        [CriadoEm] datetime2 NOT NULL,
        CONSTRAINT [PK_OngFinanceiros] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE TABLE [Voluntarios] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NULL,
        [CPF] nvarchar(max) NULL,
        [DataNascimento] datetime2 NOT NULL,
        [Escolaridade] nvarchar(max) NULL,
        [Genero] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Telefone] nvarchar(max) NULL,
        [Habilidade] nvarchar(max) NULL,
        [Avaliacao] float NOT NULL,
        [HorasVoluntaria] int NOT NULL,
        [QuantidadeExperiencias] int NOT NULL,
        [EnderecoId] int NULL,
        [CriadoEm] datetime2 NOT NULL,
        CONSTRAINT [PK_Voluntarios] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Voluntarios_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE TABLE [Ongs] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NULL,
        [CNPJ] nvarchar(max) NULL,
        [Telefone] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [AreaAtuacao] nvarchar(max) NULL,
        [QuantidadeEmpregados] int NOT NULL,
        [FinanceiroId] int NOT NULL,
        [EnderecoId] int NULL,
        [CriadoEm] datetime2 NOT NULL,
        CONSTRAINT [PK_Ongs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Ongs_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id]),
        CONSTRAINT [FK_Ongs_OngFinanceiros_FinanceiroId] FOREIGN KEY ([FinanceiroId]) REFERENCES [OngFinanceiros] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE TABLE [Experiencias] (
        [Id] int NOT NULL IDENTITY,
        [IdVoluntario] int NOT NULL,
        [VoluntarioId] int NULL,
        [IdOng] int NOT NULL,
        [OngId] int NULL,
        [NomeVoluntario] nvarchar(max) NULL,
        [NomeOng] nvarchar(max) NULL,
        [ProjetoEnvolvido] nvarchar(max) NULL,
        [Opiniao] nvarchar(max) NULL,
        [DataPostagem] datetime2 NOT NULL,
        [DataExperienciaInicio] datetime2 NOT NULL,
        [DataExperienciaFim] datetime2 NOT NULL,
        [CriadoEm] datetime2 NOT NULL,
        CONSTRAINT [PK_Experiencias] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Experiencias_Ongs_OngId] FOREIGN KEY ([OngId]) REFERENCES [Ongs] ([Id]),
        CONSTRAINT [FK_Experiencias_Voluntarios_VoluntarioId] FOREIGN KEY ([VoluntarioId]) REFERENCES [Voluntarios] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE TABLE [Vagas] (
        [Id] int NOT NULL IDENTITY,
        [VoluntarioId] int NOT NULL,
        [OngId] int NOT NULL,
        [Tipo] nvarchar(max) NULL,
        [Turno] nvarchar(max) NULL,
        [Descricao] nvarchar(max) NULL,
        [Habilidade] nvarchar(max) NULL,
        [DataInicio] datetime2 NOT NULL,
        [DataFim] datetime2 NOT NULL,
        [CriadoEm] datetime2 NOT NULL,
        CONSTRAINT [PK_Vagas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Vagas_Ongs_OngId] FOREIGN KEY ([OngId]) REFERENCES [Ongs] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Vagas_Voluntarios_VoluntarioId] FOREIGN KEY ([VoluntarioId]) REFERENCES [Voluntarios] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE INDEX [IX_Experiencias_OngId] ON [Experiencias] ([OngId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE INDEX [IX_Experiencias_VoluntarioId] ON [Experiencias] ([VoluntarioId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE INDEX [IX_Ongs_EnderecoId] ON [Ongs] ([EnderecoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE INDEX [IX_Ongs_FinanceiroId] ON [Ongs] ([FinanceiroId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE INDEX [IX_Vagas_OngId] ON [Vagas] ([OngId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE INDEX [IX_Vagas_VoluntarioId] ON [Vagas] ([VoluntarioId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    CREATE INDEX [IX_Voluntarios_EnderecoId] ON [Voluntarios] ([EnderecoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519002527_FirstMigration_v2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230519002527_FirstMigration_v2', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519030229_FixOngColumn')
BEGIN
    ALTER TABLE [Ongs] DROP CONSTRAINT [FK_Ongs_OngFinanceiros_FinanceiroId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519030229_FixOngColumn')
BEGIN
    DROP INDEX [IX_Ongs_FinanceiroId] ON [Ongs];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519030229_FixOngColumn')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ongs]') AND [c].[name] = N'FinanceiroId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Ongs] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Ongs] DROP COLUMN [FinanceiroId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519030229_FixOngColumn')
BEGIN
    ALTER TABLE [OngFinanceiros] ADD [OngId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519030229_FixOngColumn')
BEGIN
    CREATE INDEX [IX_OngFinanceiros_OngId] ON [OngFinanceiros] ([OngId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519030229_FixOngColumn')
BEGIN
    ALTER TABLE [OngFinanceiros] ADD CONSTRAINT [FK_OngFinanceiros_Ongs_OngId] FOREIGN KEY ([OngId]) REFERENCES [Ongs] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519030229_FixOngColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230519030229_FixOngColumn', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519031651_AddDeletionRestricted')
BEGIN
    ALTER TABLE [Voluntarios] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519031651_AddDeletionRestricted')
BEGIN
    ALTER TABLE [Vagas] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519031651_AddDeletionRestricted')
BEGIN
    ALTER TABLE [Ongs] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519031651_AddDeletionRestricted')
BEGIN
    ALTER TABLE [OngFinanceiros] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519031651_AddDeletionRestricted')
BEGIN
    ALTER TABLE [Experiencias] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519031651_AddDeletionRestricted')
BEGIN
    ALTER TABLE [Endereco] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519031651_AddDeletionRestricted')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230519031651_AddDeletionRestricted', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519032559_FixAddressColumn')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Endereco]') AND [c].[name] = N'Actived');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Endereco] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Endereco] DROP COLUMN [Actived];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519032559_FixAddressColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230519032559_FixAddressColumn', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519154054_FixAddressColumn_v2')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Endereco]') AND [c].[name] = N'CriadoEm');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Endereco] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Endereco] DROP COLUMN [CriadoEm];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519154054_FixAddressColumn_v2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230519154054_FixAddressColumn_v2', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519155301_FixVagaColumn')
BEGIN
    ALTER TABLE [Vagas] DROP CONSTRAINT [FK_Vagas_Ongs_OngId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519155301_FixVagaColumn')
BEGIN
    ALTER TABLE [Vagas] DROP CONSTRAINT [FK_Vagas_Voluntarios_VoluntarioId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519155301_FixVagaColumn')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Vagas]') AND [c].[name] = N'VoluntarioId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Vagas] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Vagas] ALTER COLUMN [VoluntarioId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519155301_FixVagaColumn')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Vagas]') AND [c].[name] = N'OngId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Vagas] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Vagas] ALTER COLUMN [OngId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519155301_FixVagaColumn')
BEGIN
    ALTER TABLE [Vagas] ADD [IdOng] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519155301_FixVagaColumn')
BEGIN
    ALTER TABLE [Vagas] ADD [IdVoluntario] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519155301_FixVagaColumn')
BEGIN
    ALTER TABLE [Vagas] ADD CONSTRAINT [FK_Vagas_Ongs_OngId] FOREIGN KEY ([OngId]) REFERENCES [Ongs] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519155301_FixVagaColumn')
BEGIN
    ALTER TABLE [Vagas] ADD CONSTRAINT [FK_Vagas_Voluntarios_VoluntarioId] FOREIGN KEY ([VoluntarioId]) REFERENCES [Voluntarios] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519155301_FixVagaColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230519155301_FixVagaColumn', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526015043_AddUserColumn')
BEGIN
    CREATE TABLE [TB_Usuarios] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NOT NULL,
        [Login] nvarchar(max) NOT NULL,
        [Senha] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Perfil] int NOT NULL,
        [CriadoEm] datetime2 NOT NULL,
        [Actived] bit NOT NULL,
        CONSTRAINT [PK_TB_Usuarios] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526015043_AddUserColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230526015043_AddUserColumn', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [Experiencias] DROP CONSTRAINT [FK_Experiencias_Ongs_OngId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [Experiencias] DROP CONSTRAINT [FK_Experiencias_Voluntarios_VoluntarioId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [Ongs] DROP CONSTRAINT [FK_Ongs_Endereco_EnderecoId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [Vagas] DROP CONSTRAINT [FK_Vagas_Ongs_OngId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [Vagas] DROP CONSTRAINT [FK_Vagas_Voluntarios_VoluntarioId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [Voluntarios] DROP CONSTRAINT [FK_Voluntarios_Endereco_EnderecoId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    DROP TABLE [OngFinanceiros];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [Voluntarios] DROP CONSTRAINT [PK_Voluntarios];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [Vagas] DROP CONSTRAINT [PK_Vagas];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [Ongs] DROP CONSTRAINT [PK_Ongs];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [Experiencias] DROP CONSTRAINT [PK_Experiencias];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [Endereco] DROP CONSTRAINT [PK_Endereco];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    EXEC sp_rename N'[Voluntarios]', N'TB_Voluntarios';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    EXEC sp_rename N'[Vagas]', N'TB_Vagas';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    EXEC sp_rename N'[Ongs]', N'TB_Ongs';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    EXEC sp_rename N'[Experiencias]', N'TB_Experiencias';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    EXEC sp_rename N'[Endereco]', N'TB_Enderecos';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    EXEC sp_rename N'[TB_Voluntarios].[IX_Voluntarios_EnderecoId]', N'IX_TB_Voluntarios_EnderecoId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    EXEC sp_rename N'[TB_Vagas].[IX_Vagas_VoluntarioId]', N'IX_TB_Vagas_VoluntarioId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    EXEC sp_rename N'[TB_Vagas].[IX_Vagas_OngId]', N'IX_TB_Vagas_OngId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    EXEC sp_rename N'[TB_Ongs].[IX_Ongs_EnderecoId]', N'IX_TB_Ongs_EnderecoId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    EXEC sp_rename N'[TB_Experiencias].[IX_Experiencias_VoluntarioId]', N'IX_TB_Experiencias_VoluntarioId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    EXEC sp_rename N'[TB_Experiencias].[IX_Experiencias_OngId]', N'IX_TB_Experiencias_OngId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [TB_Voluntarios] ADD CONSTRAINT [PK_TB_Voluntarios] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [TB_Vagas] ADD CONSTRAINT [PK_TB_Vagas] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [TB_Ongs] ADD CONSTRAINT [PK_TB_Ongs] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [TB_Experiencias] ADD CONSTRAINT [PK_TB_Experiencias] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [TB_Enderecos] ADD CONSTRAINT [PK_TB_Enderecos] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    CREATE TABLE [TB_OngFinanceiros] (
        [Id] int NOT NULL IDENTITY,
        [IdOng] int NOT NULL,
        [Tipo] nvarchar(max) NULL,
        [Data] datetime2 NOT NULL,
        [Valor] decimal(18,2) NOT NULL,
        [Origem] nvarchar(max) NULL,
        [CriadoEm] datetime2 NOT NULL,
        [OngId] int NULL,
        [Actived] bit NOT NULL,
        CONSTRAINT [PK_TB_OngFinanceiros] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TB_OngFinanceiros_TB_Ongs_OngId] FOREIGN KEY ([OngId]) REFERENCES [TB_Ongs] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    CREATE INDEX [IX_TB_OngFinanceiros_OngId] ON [TB_OngFinanceiros] ([OngId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [TB_Experiencias] ADD CONSTRAINT [FK_TB_Experiencias_TB_Ongs_OngId] FOREIGN KEY ([OngId]) REFERENCES [TB_Ongs] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [TB_Experiencias] ADD CONSTRAINT [FK_TB_Experiencias_TB_Voluntarios_VoluntarioId] FOREIGN KEY ([VoluntarioId]) REFERENCES [TB_Voluntarios] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [TB_Ongs] ADD CONSTRAINT [FK_TB_Ongs_TB_Enderecos_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [TB_Enderecos] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [TB_Vagas] ADD CONSTRAINT [FK_TB_Vagas_TB_Ongs_OngId] FOREIGN KEY ([OngId]) REFERENCES [TB_Ongs] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [TB_Vagas] ADD CONSTRAINT [FK_TB_Vagas_TB_Voluntarios_VoluntarioId] FOREIGN KEY ([VoluntarioId]) REFERENCES [TB_Voluntarios] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    ALTER TABLE [TB_Voluntarios] ADD CONSTRAINT [FK_TB_Voluntarios_TB_Enderecos_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [TB_Enderecos] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526020247_FixColumnNames')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230526020247_FixColumnNames', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526025839_FixUserColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230526025839_FixUserColumn', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230528173243_AddImagemConfiguration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230528173243_AddImagemConfiguration', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230531140024_ChangeExpAndVaga')
BEGIN
    ALTER TABLE [TB_Vagas] ADD [Disponivel] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230531140024_ChangeExpAndVaga')
BEGIN
    ALTER TABLE [TB_Experiencias] ADD [Nota] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230531140024_ChangeExpAndVaga')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230531140024_ChangeExpAndVaga', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601151842_ChangeImagemColumn')
BEGIN
    ALTER TABLE [TB_Voluntarios] ADD [ImagemId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601151842_ChangeImagemColumn')
BEGIN
    ALTER TABLE [TB_Ongs] ADD [ImagemId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601151842_ChangeImagemColumn')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Imagens]') AND [c].[name] = N'Nome');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [TB_Imagens] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [TB_Imagens] ALTER COLUMN [Nome] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601151842_ChangeImagemColumn')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Imagens]') AND [c].[name] = N'Conteudo');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [TB_Imagens] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [TB_Imagens] ALTER COLUMN [Conteudo] varbinary(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601151842_ChangeImagemColumn')
BEGIN
    ALTER TABLE [TB_Imagens] ADD [IdDono] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601151842_ChangeImagemColumn')
BEGIN
    CREATE INDEX [IX_TB_Voluntarios_ImagemId] ON [TB_Voluntarios] ([ImagemId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601151842_ChangeImagemColumn')
BEGIN
    CREATE INDEX [IX_TB_Ongs_ImagemId] ON [TB_Ongs] ([ImagemId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601151842_ChangeImagemColumn')
BEGIN
    ALTER TABLE [TB_Ongs] ADD CONSTRAINT [FK_TB_Ongs_TB_Imagens_ImagemId] FOREIGN KEY ([ImagemId]) REFERENCES [TB_Imagens] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601151842_ChangeImagemColumn')
BEGIN
    ALTER TABLE [TB_Voluntarios] ADD CONSTRAINT [FK_TB_Voluntarios_TB_Imagens_ImagemId] FOREIGN KEY ([ImagemId]) REFERENCES [TB_Imagens] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601151842_ChangeImagemColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230601151842_ChangeImagemColumn', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601152531_ChangeImagemColumn_v2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230601152531_ChangeImagemColumn_v2', N'7.0.5');
END;
GO

COMMIT;
GO

