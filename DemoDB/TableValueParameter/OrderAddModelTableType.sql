CREATE TYPE [dbo].[OrderAddModelTableType] AS TABLE
(ShippingAddress nvarchar(50),
orderdate DateTime,
PaymentAmount int,
DelivaryStatus nvarchar(50),
PaymentDone Bit,
CustomerId int
)
