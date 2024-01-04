Create Procedure [spDeleteCustomer](@id int)
as
begin
		Delete from Customers where Id=@id
end
