CREATE Procedure [dbo].[spInsertCustomer]
(@id int output,
 @FullName   varchar(50),
 @PhoneNumber nvarchar(50),
 @Address varchar(50),
 @Email Varchar(50),
 @DOB Datetime,
 @Gender varchar(50),
 @RegionID int 

 ) 
 As
begin
		Insert into Customers ( FullName, Email,PhoneNumber,Address,DOB,Gender,RegionId) Values ( @FullName,@Email,@PhoneNumber,@Address,@DOB,@Gender,@RegionId) ;
        Set @id = Cast(SCOPE_IDENTITY() as Int);

end