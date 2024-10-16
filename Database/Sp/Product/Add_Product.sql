CREATE PROCEDURE Add_Product
    @Id UNIQUEIDENTIFIER,
    @Name VARCHAR(50),
    @Description VARCHAR(MAX),
    @Price DECIMAL,
    @IdUser UNIQUEIDENTIFIER,
    @CreatedOn DATETIME,
    @LastModifiedOn DATETIME = NULL,
    @State INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[Product] (Id, Name, Description, Price, IdUser, CreatedOn, LastModifiedOn, State)
        VALUES (@Id, @Name, @Description, @Price, @IdUser, @CreatedOn, @LastModifiedOn, @State);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END