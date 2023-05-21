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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    CREATE TABLE [Endereco] (
        [Id] INTEGER NOT NULL,
        [Cep] TEXT NULL,
        [EnderecoLinha] TEXT NULL,
        [Numero] INTEGER NOT NULL,
        [Bairro] TEXT NULL,
        [Cidade] TEXT NULL,
        [Estado] TEXT NULL,
        [Pais] TEXT NULL,
        CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    CREATE TABLE [Experiencias] (
        [Id] INTEGER NOT NULL,
        [IdVoluntario] INTEGER NOT NULL,
        [IdOng] INTEGER NOT NULL,
        [NomeVoluntario] TEXT NULL,
        [SobrenomeVoluntario] TEXT NULL,
        [NomeOng] TEXT NULL,
        [ProjetoEnvolvido] TEXT NULL,
        [Opiniao] TEXT NULL,
        [DataPostagem] TEXT NOT NULL,
        [DataExperienciaInicio] TEXT NOT NULL,
        [DataExperienciaFim] TEXT NOT NULL,
        CONSTRAINT [PK_Experiencias] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    CREATE TABLE [OngFinanceiro] (
        [Id] INTEGER NOT NULL,
        [IdOng] INTEGER NOT NULL,
        [Tipo] TEXT NULL,
        [Data] TEXT NOT NULL,
        [Valor] TEXT NOT NULL,
        [Origem] TEXT NULL,
        CONSTRAINT [PK_OngFinanceiro] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    CREATE TABLE [Voluntarios] (
        [Id] INTEGER NOT NULL,
        [Nome] TEXT NULL,
        [Sobrenome] TEXT NULL,
        [CPF] TEXT NULL,
        [DataNascimento] TEXT NOT NULL,
        [Escolaridade] TEXT NULL,
        [Genero] TEXT NULL,
        [Email] TEXT NULL,
        [Telefone] TEXT NULL,
        [Habilidade] TEXT NULL,
        [Avaliacao] REAL NOT NULL,
        [HorasVoluntaria] INTEGER NOT NULL,
        [QuantidadeExperiencias] INTEGER NOT NULL,
        [EnderecoId] INTEGER NULL,
        CONSTRAINT [PK_Voluntarios] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Voluntarios_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    CREATE TABLE [Ongs] (
        [Id] INTEGER NOT NULL,
        [Nome] TEXT NULL,
        [CNPJ] TEXT NULL,
        [Telefone] TEXT NULL,
        [Email] TEXT NULL,
        [AreaAtuacao] TEXT NULL,
        [QuantidadeEmpregados] INTEGER NOT NULL,
        [FinanceiroId] INTEGER NOT NULL,
        [EnderecoId] INTEGER NULL,
        CONSTRAINT [PK_Ongs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Ongs_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id]),
        CONSTRAINT [FK_Ongs_OngFinanceiro_FinanceiroId] FOREIGN KEY ([FinanceiroId]) REFERENCES [OngFinanceiro] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    CREATE TABLE [Vagas] (
        [Id] INTEGER NOT NULL,
        [VoluntarioId] INTEGER NOT NULL,
        [OngId] INTEGER NOT NULL,
        [Tipo] TEXT NULL,
        [Turno] TEXT NULL,
        [Descricao] TEXT NULL,
        [Habilidade] TEXT NULL,
        [DataInicio] TEXT NOT NULL,
        [DataFim] TEXT NOT NULL,
        CONSTRAINT [PK_Vagas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Vagas_Ongs_OngId] FOREIGN KEY ([OngId]) REFERENCES [Ongs] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Vagas_Voluntarios_VoluntarioId] FOREIGN KEY ([VoluntarioId]) REFERENCES [Voluntarios] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    CREATE INDEX [IX_Ongs_EnderecoId] ON [Ongs] ([EnderecoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    CREATE INDEX [IX_Ongs_FinanceiroId] ON [Ongs] ([FinanceiroId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    CREATE INDEX [IX_Vagas_OngId] ON [Vagas] ([OngId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    CREATE INDEX [IX_Vagas_VoluntarioId] ON [Vagas] ([VoluntarioId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    CREATE INDEX [IX_Voluntarios_EnderecoId] ON [Voluntarios] ([EnderecoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504225936_FirstMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230504225936_FirstMigration', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230516160012_FixSomeColums')
BEGIN
    ALTER TABLE [Ongs] DROP CONSTRAINT [FK_Ongs_OngFinanceiro_FinanceiroId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230516160012_FixSomeColums')
BEGIN
    ALTER TABLE [OngFinanceiro] DROP CONSTRAINT [PK_OngFinanceiro];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230516160012_FixSomeColums')
BEGIN
    EXEC sp_rename N'[OngFinanceiro]', N'OngFinanceiros';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230516160012_FixSomeColums')
BEGIN
    ALTER TABLE [OngFinanceiros] ADD CONSTRAINT [PK_OngFinanceiros] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230516160012_FixSomeColums')
BEGIN
    ALTER TABLE [Ongs] ADD CONSTRAINT [FK_Ongs_OngFinanceiros_FinanceiroId] FOREIGN KEY ([FinanceiroId]) REFERENCES [OngFinanceiros] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230516160012_FixSomeColums')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230516160012_FixSomeColums', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230516160301_FixVoluntararioColumn')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Voluntarios]') AND [c].[name] = N'Sobrenome');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Voluntarios] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Voluntarios] DROP COLUMN [Sobrenome];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230516160301_FixVoluntararioColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230516160301_FixVoluntararioColumn', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Experiencias]') AND [c].[name] = N'SobrenomeVoluntario');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Experiencias] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Experiencias] DROP COLUMN [SobrenomeVoluntario];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [Voluntarios] ADD [CriadoEm] TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [Vagas] ADD [CriadoEm] TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [Ongs] ADD [CriadoEm] TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [OngFinanceiros] ADD [CriadoEm] TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [Experiencias] ADD [CriadoEm] TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [Experiencias] ADD [OngId] INTEGER NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [Experiencias] ADD [VoluntarioId] INTEGER NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [Endereco] ADD [CriadoEm] TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [Endereco] ADD [Latitude] TEXT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [Endereco] ADD [Longitude] TEXT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    CREATE INDEX [IX_Experiencias_OngId] ON [Experiencias] ([OngId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    CREATE INDEX [IX_Experiencias_VoluntarioId] ON [Experiencias] ([VoluntarioId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [Experiencias] ADD CONSTRAINT [FK_Experiencias_Ongs_OngId] FOREIGN KEY ([OngId]) REFERENCES [Ongs] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    ALTER TABLE [Experiencias] ADD CONSTRAINT [FK_Experiencias_Voluntarios_VoluntarioId] FOREIGN KEY ([VoluntarioId]) REFERENCES [Voluntarios] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230518024044_AlteraEstruturaTabelas')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230518024044_AlteraEstruturaTabelas', N'7.0.5');
END;
GO

COMMIT;
GO

