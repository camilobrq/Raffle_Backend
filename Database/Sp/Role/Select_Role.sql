CREATE PROCEDURE Select_Role
    @Id UNIQUEIDENTIFIER = NULL,
    @Name VARCHAR(50) = NULL,
    @Code VARCHAR(50) = NULL,
    @CreatedOn DATETIME = NULL,
    @LastModifiedOn DATETIME = NULL,
    @State INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,
        Name,
        Code,
        CreatedOn,
        LastModifiedOn,
        State
    FROM 
        [dbo].[Role]
    WHERE
        (Id = @Id OR @Id IS NULL) AND
        (Name = @Name OR @Name IS NULL) AND
        (Code = @Code OR @Code IS NULL) AND
        (CreatedOn = @CreatedOn OR @CreatedOn IS NULL) AND
        (LastModifiedOn = @LastModifiedOn OR @LastModifiedOn IS NULL) AND
        (State = @State OR @State IS NULL);
END
