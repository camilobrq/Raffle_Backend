CREATE PROCEDURE Add_User
    @Id UNIQUEIDENTIFIER,
    @UserName VARCHAR(MAX),
    @Password VARCHAR(MAX),
    @RoleId UNIQUEIDENTIFIER = NULL,
    @CreatedOn DATETIME,
    @LastModifiedOn DATETIME = NULL,
    @State INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[User] (Id, UserName, Password, RoleId, CreatedOn, LastModifiedOn, State)
        VALUES (@Id, @UserName, @Password, @RoleId, @CreatedOn, @LastModifiedOn, @State);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
