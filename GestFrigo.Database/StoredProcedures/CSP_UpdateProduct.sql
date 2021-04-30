CREATE PROCEDURE [dbo].[CSP_UpdateProduct]
	@ProductId int,
	@Name NVARCHAR(150),
	@UserId int
AS
BEGIN
	IF (EXISTS(Select * FROM [Content] WHERE [ProductId] = @ProductId AND [UserId] = @UserId))
	BEGIN
		RAISERROR (N'This product is currently in use.', -- Message text.  
           10, -- Severity,  
           1); -- State,
		RETURN -1;
	END

	UPDATE [Product] SET [Name] = @Name WHERE Id = @ProductId AND UserId = @UserId; 
	RETURN 0;
END
