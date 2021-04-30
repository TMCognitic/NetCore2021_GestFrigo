CREATE VIEW [dbo].[V_Content]
	AS 
	SELECT [C].[Id], [P].[Id] as ProductId, [P].[Name], [C].[AddedDate], [C].[ExpirationDate], [C].[UserId]
	FROM [CONTENT] AS [C]
	JOIN [PRODUCT] AS [P] ON [P].[Id] = [C].[ProductId]
