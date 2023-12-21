USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spDeleteOrderById] Script Date: 21-12-2023 18:42:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure spDeleteOrderById
(@id int
)
as
Begin
Delete From Orders where Id=@id;

End
