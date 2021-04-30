CREATE PROCEDURE [dbo].[CSP_DeleteProduct]
	@Id int,
	@UserId int
AS
BEGIN
	DELETE FROM [Product] WHERE Id = @Id AND UserId = @UserId;
	RETURN 0
END
