USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spBulkInsertOrder] Script Date: 21-12-2023 18:40:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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
