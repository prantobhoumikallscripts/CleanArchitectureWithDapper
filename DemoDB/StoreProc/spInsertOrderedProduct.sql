CREATE PROCEDURE [dbo].[spInsertOrderedProduct]
(@OrderId int
,@productId int
)
as
Begin
Insert into OrderedProduct (OrderId,ProductId) values (@OrderId,@productId);

End
