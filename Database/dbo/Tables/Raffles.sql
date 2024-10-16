CREATE TABLE [dbo].[Raffles] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [UserId]         UNIQUEIDENTIFIER NOT NULL,
    [CodeGenerate]   BIGINT           NOT NULL,
    [ClientId]       UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]      DATETIME2 (7)    NOT NULL,
    [LastModifiedOn] DATETIME2 (7)    NOT NULL,
    [State]          BIT              NOT NULL,
    CONSTRAINT [PK_Raffles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

