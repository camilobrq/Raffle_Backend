CREATE PROCEDURE Update_Session
    @Id UNIQUEIDENTIFIER,
    @StartTime DATETIME = NULL,
    @EndTime DATETIME = NULL,
    @UserId UNIQUEIDENTIFIER = NULL,
    @Active BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [dbo].[Session]
        SET 
            StartTime = ISNULL(@StartTime, StartTime),
            EndTime = ISNULL(@EndTime, EndTime),
            UserId = ISNULL(@UserId, UserId),
            Active = ISNULL(@Active, Active)
        WHERE
            Id = @Id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
