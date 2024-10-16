CREATE PROCEDURE Select_User
    @Id UNIQUEIDENTIFIER = NULL,
    @UserName VARCHAR(MAX) = NULL,
    @Password VARCHAR(MAX) = NULL,
    @RoleId UNIQUEIDENTIFIER = NULL,
    @CreatedOn DATETIME = NULL,
    @LastModifiedOn DATETIME = NULL,
    @State INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,
        UserName,
        Password,
        RoleId,
        CreatedOn,
        LastModifiedOn,
        State
    FROM 
        [dbo].[User]
    WHERE
        (Id = @Id OR @Id IS NULL) AND
        (UserName = @UserName OR @UserName IS NULL) AND
        (Password = @Password OR @Password IS NULL) AND
        (RoleId = @RoleId OR @RoleId IS NULL) AND
        (CreatedOn = @CreatedOn OR @CreatedOn IS NULL) AND
        (LastModifiedOn = @LastModifiedOn OR @LastModifiedOn IS NULL) AND
        (State = @State OR @State IS NULL);
END
