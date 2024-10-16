CREATE PROCEDURE Update_PasswordResetRequest
    @Id UNIQUEIDENTIFIER,
    @Name VARCHAR(50) = NULL,
    @Code VARCHAR(50) = NULL,
    @LastModifiedOn DATETIME = NULL,
    @State INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [dbo].[Role]
        SET 
            Name = ISNULL(@Name, Name),
            Code = ISNULL(@Code, Code),
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
