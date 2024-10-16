IF NOT EXISTS (SELECT 1 FROM [dbo].[Role])
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[Role] (Id, [Name], Code, CreatedOn, [State])
        VALUES
            (NEWID(), 'Administrador', 'ADMIN', GETDATE(), 1),
            (NEWID(), 'Cliente', 'CLIENT', GETDATE(), 1),
            (NEWID(), 'Usuario', 'USER', GETDATE(), 1);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[User])
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[User] (Id, UserName, [Password], RoleId, CreatedOn, [State])
        VALUES
            (NEWID(), 'AnGJzG9kTSXJwfqSS+tfrfKnqs5CKOZI0RmDkHMJWYJUd8/3h5HpZDQdF7a4m3CH', 
            'TJuMSK0zrZBIMc93Q9BKyw==', 
            (SELECT Id FROM [dbo].[Role] WHERE Code = 'ADMIN'),  GETDATE(),  1);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
