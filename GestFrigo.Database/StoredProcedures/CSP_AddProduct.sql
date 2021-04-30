CREATE PROCEDURE [dbo].[CSP_AddProduct]
	@Name NVARCHAR(150),
	@UserId int
AS
BEGIN
	INSERT INTO [Product] ([Name], [UserId]) VALUES (@Name, @UserId);
	RETURN 0
END
