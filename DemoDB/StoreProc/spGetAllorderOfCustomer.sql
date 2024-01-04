CREATE PROCEDURE [dbo].[spGetAllorderOfCustomer]
(@id int
)
as
Begin
Select * from Orders where CustomerId=@id;

End