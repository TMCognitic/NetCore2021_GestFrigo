CREATE PROCEDURE [dbo].[CSP_DeleteContent]
	@ContentId BIGINT,
	@UserId int
AS
BEGIN
	DELETE FROM [Content] WHERE [Id] = @ContentId AND UserId = @UserId;
	RETURN 0;
END
