USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spInsertorder] Script Date: 21-12-2023 18:50:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure spInsertorder
(@id int output,
@ShippingAddress nvarchar(50),
@orderdate DateTime,
@PaymentAmount int,
@DelivaryStatus nvarchar(50),
@PaymentDone Bit,
@CustomerId int
 ) 
 As
begin
		Insert into Orders (ShippingAddress ,OrderDate,PaymentAmount,DelivaryStatus,PaymentDone,CustomerId) VALUES (@ShippingAddress,@orderdate,@PaymentAmount,@DelivaryStatus,@PaymentDone,@CustomerId)
        Set @id= Cast(SCOPE_IDENTITY() as Int);

end
