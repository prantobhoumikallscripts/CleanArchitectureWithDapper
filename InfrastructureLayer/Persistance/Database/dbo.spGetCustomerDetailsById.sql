USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spGetCustomerDetailsById] Script Date: 21-12-2023 18:44:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spGetCustomerDetailsById]
(@id int
)
as
Begin
SELECT * FROM Customers c 
                         LEFT JOIN Accounts a ON c.Id = a.CustomerId
                         LEFT JOIN Orders o ON c.Id = o.CustomerId Where c.Id=@id;

End
