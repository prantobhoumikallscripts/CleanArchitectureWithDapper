CREATE PROCEDURE [dbo].[spDeleteOrderById]
(@id int
)
as
Begin
Delete From Orders where Id=@id;

End