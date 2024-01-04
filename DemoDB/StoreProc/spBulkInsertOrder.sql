

CREATE PROCEDURE spBulkInsertOrder
    @Orders dbo.OrderAddModelTableType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @InsertedOrderIds TABLE (Id INT);

    INSERT INTO Orders (ShippingAddress, OrderDate, PaymentAmount, DelivaryStatus, PaymentDone, CustomerId)
    OUTPUT inserted.Id INTO @InsertedOrderIds(Id)
    SELECT ShippingAddress, OrderDate, PaymentAmount, DelivaryStatus, PaymentDone, CustomerId
    FROM @Orders;

    -- Select the generated OrderIds
    SELECT Id FROM @InsertedOrderIds;
END;