Create procedure spDeleteProduct
(@id int
)
as
Begin
Delete From Products where Id=@id;

End