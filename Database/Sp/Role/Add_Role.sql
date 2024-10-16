CREATE PROCEDURE Add_Role
    @Id UNIQUEIDENTIFIER,
    @Name VARCHAR(50),
    @Code VARCHAR(50),
    @CreatedOn DATETIME,
    @LastModifiedOn DATETIME = NULL,
    @State INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[Role] (Id, Name, Code, CreatedOn, LastModifiedOn, State)
        VALUES (@Id, @Name, @Code, @CreatedOn, @LastModifiedOn, @State);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
