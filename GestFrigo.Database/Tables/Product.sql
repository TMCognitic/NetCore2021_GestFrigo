CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] NVARCHAR(150) NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_Product_NameByUserId] UNIQUE ([Name], [UserId]), 
    CONSTRAINT [FK_Product_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]) 
)
