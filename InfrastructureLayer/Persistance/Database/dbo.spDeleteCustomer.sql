USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spDeleteCustomer] Script Date: 21-12-2023 18:42:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [spDeleteCustomer](@id int)
as
begin
		Delete from Customers where Id=@id
end
