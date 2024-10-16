CREATE PROCEDURE Select_Session
    @Id UNIQUEIDENTIFIER = NULL,
    @StartTime DATETIME = NULL,
    @EndTime DATETIME = NULL,
    @UserId UNIQUEIDENTIFIER = NULL,
    @Active BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,
        StartTime,
        EndTime,
        UserId,
        Active
    FROM 
        [dbo].[Session]
    WHERE
        (Id = @Id OR @Id IS NULL) AND
        (StartTime = @StartTime OR @StartTime IS NULL) AND
        (EndTime = @EndTime OR @EndTime IS NULL) AND
        (UserId = @UserId OR @UserId IS NULL) AND
        (Active = @Active OR @Active IS NULL);
END
