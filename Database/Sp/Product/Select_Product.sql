CREATE PROCEDURE Select_Product
    @Id UNIQUEIDENTIFIER= NULL,
    @Name VARCHAR(50)= NULL,
    @Description VARCHAR(MAX)= NULL,
    @Price DECIMAL= NULL,
    @IdUser UNIQUEIDENTIFIER= NULL,
    @CreatedOn DATETIME= NULL,
    @LastModifiedOn DATETIME = NULL,
    @State INT= NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,
        Name,
        Description,
        Price,
        IdUser,
        CreatedOn,
        LastModifiedOn,
        State
    FROM 
        [dbo].[Product]
    WHERE
        (Id = @Id OR @Id IS NULL) AND
        (Name = @Name OR @Name IS NULL) AND
        (Description = @Description OR @Description IS NULL) AND
        (Price = @Price OR @Price IS NULL) AND
        (IdUser = @IdUser OR @IdUser IS NULL) AND
        (CreatedOn = @CreatedOn OR @CreatedOn IS NULL) AND
        (LastModifiedOn = @LastModifiedOn OR @LastModifiedOn IS NULL) AND
        (State = @State OR @State IS NULL);
END
