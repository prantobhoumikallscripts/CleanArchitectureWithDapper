CREATE PROCEDURE [dbo].[spInsertOrder]
(@id int output,
 @ShippingAddress   nvarchar(50),
 @OrderDate datetime,
 @PaymentAmount int, @DelivaryStatus nvarchar(50),
 @PaymentDone bit, 
 @CustomerId int

 ) 
as
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Orders (ShippingAddress, OrderDate, PaymentAmount, DelivaryStatus, PaymentDone, CustomerId)
  
    Values ( @ShippingAddress, @OrderDate, @PaymentAmount, @DelivaryStatus, @PaymentDone, @CustomerId);
     Set @id = Cast(SCOPE_IDENTITY() as Int);
    
End