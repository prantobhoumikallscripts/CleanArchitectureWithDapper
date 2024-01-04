CREATE PROCEDURE [dbo].[spGetOrderById]

(@cusid int
,@id int
)
as
Begin
SELECT * FROM Orders Where CustomerId=@cusid and Id=@id;

End
