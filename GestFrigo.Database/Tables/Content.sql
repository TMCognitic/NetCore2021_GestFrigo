CREATE TABLE [dbo].[Content]
(
	[Id] BIGINT NOT NULL IDENTITY,
	[UserId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[AddedDate] DATE NOT NULL,
	[ExpirationDate] DATE NOT NULL,
    CONSTRAINT [PK_Content] PRIMARY KEY ([Id]), 
    CONSTRAINT [CK_Content_Dates] CHECK ([ExpirationDate] >= [AddedDate]), 
    CONSTRAINT [FK_Content_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Content_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
