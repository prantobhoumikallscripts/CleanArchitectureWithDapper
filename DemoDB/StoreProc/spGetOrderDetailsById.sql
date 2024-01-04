CREATE PROCEDURE [dbo].[spGetOrderDetailsById]
(@id int
)
as
Begin
SELECT o.* ,p.* From Products p inner Join OrderedProduct cl on p.Id=cl.ProductId right join Orders o on cl.OrderId=o.Id where  o.id=@id;

End
