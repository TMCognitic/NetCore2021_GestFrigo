CREATE PROCEDURE [dbo].[CSP_AddContent]
	@ProductId int,
	@UserId int,
	@AddedDate date,
	@ExpirationDate date
AS
BEGIN
	INSERT INTO [Content] ([ProductId], [UserId], [AddedDate], [ExpirationDate]) VALUES (@ProductId, @UserId, @AddedDate, @ExpirationDate);
	RETURN 0;
END
