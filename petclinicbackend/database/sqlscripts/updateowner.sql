CREATE PROCEDURE UpdateOwner @OwnerId int, @FirstName varchar(30), @LastName varchar(30), 
@Address varchar(255), @City varchar(80), @Telephone varchar(20)
AS
SET NOCOUNT ON
Update [dbo].[Owners] Set 
first_name=@FirstName,
last_name=@LastName, 
address=@Address, 
city=@City, 
telephone=@Telephone
where id=@OwnerId
GO