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
GO

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
GO

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
GO

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
GO

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
GO

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
GO

CREATE INDEX [IX_Experiencias_OngId] ON [Experiencias] ([OngId]);
GO

CREATE INDEX [IX_Experiencias_VoluntarioId] ON [Experiencias] ([VoluntarioId]);
GO

CREATE INDEX [IX_Ongs_EnderecoId] ON [Ongs] ([EnderecoId]);
GO

CREATE INDEX [IX_Ongs_FinanceiroId] ON [Ongs] ([FinanceiroId]);
GO

CREATE INDEX [IX_Vagas_OngId] ON [Vagas] ([OngId]);
GO

CREATE INDEX [IX_Vagas_VoluntarioId] ON [Vagas] ([VoluntarioId]);
GO

CREATE INDEX [IX_Voluntarios_EnderecoId] ON [Voluntarios] ([EnderecoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230519002527_FirstMigration_v2', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Ongs] DROP CONSTRAINT [FK_Ongs_OngFinanceiros_FinanceiroId];
GO

DROP INDEX [IX_Ongs_FinanceiroId] ON [Ongs];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ongs]') AND [c].[name] = N'FinanceiroId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Ongs] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Ongs] DROP COLUMN [FinanceiroId];
GO

ALTER TABLE [OngFinanceiros] ADD [OngId] int NULL;
GO

CREATE INDEX [IX_OngFinanceiros_OngId] ON [OngFinanceiros] ([OngId]);
GO

ALTER TABLE [OngFinanceiros] ADD CONSTRAINT [FK_OngFinanceiros_Ongs_OngId] FOREIGN KEY ([OngId]) REFERENCES [Ongs] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230519030229_FixOngColumn', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Voluntarios] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [Vagas] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [Ongs] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [OngFinanceiros] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [Experiencias] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [Endereco] ADD [Actived] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230519031651_AddDeletionRestricted', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Endereco]') AND [c].[name] = N'Actived');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Endereco] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Endereco] DROP COLUMN [Actived];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230519032559_FixAddressColumn', N'7.0.5');
GO

COMMIT;
GO

