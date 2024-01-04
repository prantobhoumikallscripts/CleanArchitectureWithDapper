CREATE PROCEDURE [dbo].[spGetAllCustomer]
as
begin
		Select * from Customers s 
		left join Regions r on s.RegionId=r.Id;
end
