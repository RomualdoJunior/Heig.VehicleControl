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

CREATE TABLE [ChecklistTemplates] (
    [Id] uniqueidentifier NOT NULL,
    [Number] int NOT NULL IDENTITY,
    [Title] varchar(255) NOT NULL,
    [CreatedOn] datetime2 NULL,
    [UpdatedOn] datetime2 NULL,
    CONSTRAINT [PK_ChecklistTemplates] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Vehicles] (
    [Id] uniqueidentifier NOT NULL,
    [Description] varchar(255) NOT NULL,
    [LicensePlate] varchar(7) NOT NULL,
    [CreatedOn] datetime2 NULL,
    [UpdatedOn] datetime2 NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [QuestionTemplates] (
    [Id] uniqueidentifier NOT NULL,
    [Title] varchar(255) NOT NULL,
    [FullDescription] varchar(2000) NOT NULL,
    [ChecklistTemplateId] uniqueidentifier NOT NULL,
    [CreatedOn] datetime2 NULL,
    [UpdatedOn] datetime2 NULL,
    CONSTRAINT [PK_QuestionTemplates] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_QuestionTemplates_ChecklistTemplates_ChecklistTemplateId] FOREIGN KEY ([ChecklistTemplateId]) REFERENCES [ChecklistTemplates] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Checklists] (
    [Id] uniqueidentifier NOT NULL,
    [Status] int NOT NULL,
    [OwnerUserId] uniqueidentifier NOT NULL,
    [VehicleId] uniqueidentifier NOT NULL,
    [OriginalChecklistTemplateId] uniqueidentifier NOT NULL,
    [CreatedOn] datetime2 NULL,
    [UpdatedOn] datetime2 NULL,
    CONSTRAINT [PK_Checklists] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Checklists_ChecklistTemplates_OriginalChecklistTemplateId] FOREIGN KEY ([OriginalChecklistTemplateId]) REFERENCES [ChecklistTemplates] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Checklists_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Answers] (
    [Id] uniqueidentifier NOT NULL,
    [Title] varchar(100) NOT NULL,
    [AdditionalObservation] varchar(4000) NULL,
    [Ok] bit NOT NULL,
    [ChecklistId] uniqueidentifier NOT NULL,
    [CreatedOn] datetime2 NULL,
    [UpdatedOn] datetime2 NULL,
    CONSTRAINT [PK_Answers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Answers_Checklists_ChecklistId] FOREIGN KEY ([ChecklistId]) REFERENCES [Checklists] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Answers_ChecklistId] ON [Answers] ([ChecklistId]);
GO

CREATE INDEX [IX_Checklists_OriginalChecklistTemplateId] ON [Checklists] ([OriginalChecklistTemplateId]);
GO

CREATE INDEX [IX_Checklists_VehicleId] ON [Checklists] ([VehicleId]);
GO

CREATE INDEX [IX_QuestionTemplates_ChecklistTemplateId] ON [QuestionTemplates] ([ChecklistTemplateId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240222232104_Initial', N'8.0.1');
GO

COMMIT;
GO

