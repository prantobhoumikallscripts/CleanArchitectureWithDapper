USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spInsertOrderedProduct] Script Date: 21-12-2023 18:50:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spInsertOrderedProduct]
(@OrderId int
,@productId int
)
as
Begin
Insert into OrderedProduct (OrderId,ProductId) values (@OrderId,@productId);

End
