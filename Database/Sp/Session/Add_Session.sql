CREATE PROCEDURE Add_Session
    @Id UNIQUEIDENTIFIER,
    @StartTime DATETIME,
    @EndTime DATETIME = NULL,
    @UserId UNIQUEIDENTIFIER,
    @Active BIT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[Session] (Id, StartTime, EndTime, UserId, Active)
        VALUES (@Id, @StartTime, @EndTime, @UserId, @Active);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
