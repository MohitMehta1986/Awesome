DELIMITER //
CREATE PROCEDURE CreateOwner(IN FirstName VARCHAR(25),IN LastName VARCHAR(25),IN Address VARCHAR(15),IN City VARCHAR(25),IN Telephone INT)
BEGIN
INSERT INTO owners(first_name,last_name,address,city,telephone) VALUES(FirstName,LastName,Address,City,Telephone);
END //
 DELIMITER ;
