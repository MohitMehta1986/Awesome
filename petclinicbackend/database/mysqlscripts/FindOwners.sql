DELIMITER //
 CREATE PROCEDURE FindOwner(in Ownerid INT)
   BEGIN
   SELECT id as 'OwnerId',
	first_name as 'FirstName'
	,last_name as 'LastName'
	,address as 'Address'
	,city as 'City'
	,telephone as 'Telephone'
	FROM owners where id=Ownerid;
   END //
 DELIMITER ;