CREATE PROCEDURE dbo.CreateOwner @FirstName varchar(25), @LastName varchar(25), 
@Address varchar(15), @City varchar(25), @Telephone int
AS
SET NOCOUNT ON

INSERT INTO [dbo].[Owners]
           ([first_name]
           ,[last_name]
           ,[address]
           ,[city]
           ,[telephone])
     VALUES
           (@FirstName
           ,@LastName
           ,@Address
           ,@City
           ,@Telephone)
GO