CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [ShippingAddress] NVARCHAR(50) NOT NULL, 
    [OrderDate] DATETIME NOT NULL, 
    [PaymentAmount] INT NOT NULL, 
    [DelivaryStatus] NVARCHAR(50) NOT NULL, 
    [PaymentDone] BIT NOT NULL, 
    [CustomerId] INT NULL, 
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])
)
