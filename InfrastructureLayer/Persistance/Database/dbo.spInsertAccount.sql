USE [DB]
GO

/****** Object: SqlProcedure [dbo].[spInsertAccount] Script Date: 21-12-2023 18:45:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure spInsertAccount
(@id int output,
 @BranchName nvarchar(50),
 @BankName nvarchar(50),
 @Balance int,
 @CustomerId int
 ) 
 As
begin
		Insert into Accounts (BranchName,Bankname,Balance,CustomerId) Values(@BranchName,@BankName,@Balance,@CustomerId); 
        Set @id= Cast(SCOPE_IDENTITY() as Int);

end
