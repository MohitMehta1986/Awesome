CREATE PROCEDURE FindOwner @Ownerid int
AS
SET NOCOUNT ON
	SELECT
	id as 'OwnerId',
	first_name as 'FirstName'
	,last_name as 'LastName'
	,address as 'Address'
	,city as 'City'
	,telephone as 'Telephone'
	 FROM [dbo].[Owners] WHERE id=@Ownerid
Go