CREATE PROCEDURE [dbo].[CSP_CheckUser]
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20)
AS
BEGIN
	SELECT [Id], [LastName], [FirstName], [Email] FROM [User] WHERE Email = @Email AND Passwd = HASHBYTES('SHA2_512', dbo.CSF_GetPreSalt() + @Passwd + dbo.CSF_GetPostSalt());
	RETURN 0
END
