USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spGetAllOrderOfCustomer] Script Date: 21-12-2023 18:43:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure spGetAllOrderOfCustomer
(@id int
)
as
Begin
Select * from Orders where CustomerId=@id;

End
