USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spGetCustomerById] Script Date: 21-12-2023 18:44:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[spGetCustomerById] (@id   int ) 
 As
begin
		Select * from Customers where Id=@id;
end
