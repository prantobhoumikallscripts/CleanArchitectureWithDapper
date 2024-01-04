CREATE PROCEDURE [dbo].[spGetCustomerDetailsbyId]
(@id int
)
as
Begin
SELECT * FROM Customers c 
                         LEFT JOIN Accounts a ON c.Id = a.CustomerId
                         LEFT JOIN Orders o ON c.Id = o.CustomerId Where c.Id=@id;

End
