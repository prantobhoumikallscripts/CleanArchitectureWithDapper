USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spGetAllCustomer] Script Date: 21-12-2023 18:43:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[spGetAllCustomer]
as
begin
		Select * from Customers;
end
