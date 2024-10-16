CREATE TABLE [dbo].[Product]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Price] DECIMAL NOT NULL, 
    [IdUser] UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn] DATETIME NULL, 
    [LastModifiedOn] DATETIME NULL, 
    [State] INT NULL, 
    CONSTRAINT FK_User_Product FOREIGN KEY (IdUser) REFERENCES [dbo].[User](id)
)
