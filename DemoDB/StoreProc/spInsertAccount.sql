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