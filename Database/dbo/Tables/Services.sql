CREATE TABLE [dbo].[Services] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Name]           NVARCHAR (50)    NOT NULL,
    [Description]    NVARCHAR (255)   NOT NULL,
    [Price]          DECIMAL (18, 4)  NOT NULL,
    [IdUser]         UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]      DATETIME2 (7)    NOT NULL,
    [LastModifiedOn] DATETIME2 (7)    NOT NULL,
    [State]          BIT              NOT NULL,
    CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED ([Id] ASC)
);

