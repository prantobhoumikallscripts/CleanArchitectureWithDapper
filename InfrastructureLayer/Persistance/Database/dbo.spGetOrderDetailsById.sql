USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spGetOrderDetailsById] Script Date: 21-12-2023 18:44:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure spGetOrderDetailsById
(@id int
)
as
Begin
SELECT o.* ,p.* From Products p inner Join OrderedProduct cl on p.Id=cl.ProductId right join Orders o on cl.OrderId=o.Id where  o.id=@id;

End
