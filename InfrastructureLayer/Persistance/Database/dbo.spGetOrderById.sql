USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spGetOrderById] Script Date: 21-12-2023 18:44:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure spGetOrderById
(@cusid int
,@id int
)
as
Begin
SELECT * FROM Orders Where CustomerId=@cusid and Id=@id;

End
