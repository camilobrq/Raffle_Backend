CREATE PROCEDURE Update_User
    @Id UNIQUEIDENTIFIER,
    @UserName VARCHAR(MAX) = NULL,
    @Password VARCHAR(MAX) = NULL,
    @RoleId UNIQUEIDENTIFIER = NULL,
    @LastModifiedOn DATETIME = NULL,
    @State INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [dbo].[User]
        SET 
            UserName = ISNULL(@UserName, UserName),
            Password = ISNULL(@Password, Password),
            RoleId = ISNULL(@RoleId, RoleId),
            LastModifiedOn = ISNULL(@LastModifiedOn, LastModifiedOn),
            State = ISNULL(@State, State)
        WHERE
            Id = @Id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
