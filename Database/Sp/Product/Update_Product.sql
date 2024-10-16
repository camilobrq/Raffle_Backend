CREATE PROCEDURE Update_Product
    @Id UNIQUEIDENTIFIER,
    @Name VARCHAR(50)=NULL,
    @Description VARCHAR(MAX)=NULL,
    @Price DECIMAL = NULL,
    @IdUser UNIQUEIDENTIFIER,
    @LastModifiedOn DATETIME = NULL,
    @State INT=NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [dbo].[Product]
        SET 
            Name = ISNULL(@Name, Name),
            Description = ISNULL(@Description, Description),
            Price = ISNULL(@Price, Price),
            IdUser = ISNULL(@IdUser, IdUser),
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
