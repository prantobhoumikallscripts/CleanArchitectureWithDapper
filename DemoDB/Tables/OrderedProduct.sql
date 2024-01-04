CREATE TABLE [dbo].[OrderedProduct]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [ProductId] INT NOT NULL, 
    [OrderId] INT NOT NULL
)
