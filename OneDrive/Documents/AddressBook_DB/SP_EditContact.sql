
ALTER PROC EditContact
(
@FirstName VARCHAR(30),
@LastName VARCHAR(30),
@Type VARCHAR(40),
@PhoneNumber VARCHAR(20),
@Email VARCHAR(50),
@Address VARCHAR(100),
@City VARCHAR(50),
@State VARCHAR(50),
@Zipcode VARCHAR(10),
@id1 VARCHAR(30),
@id2 VARCHAR(30)
)
AS
BEGIN
	UPDATE Contacts SET FirstName=@FirstName,LastName=@LastName,Type=@Type,
	PhoneNumber=@PhoneNumber,Email=@Email,Address=@Address,City=@City,
	State=@State,Zipcode=@Zipcode
	WHERE FirstName=@id1 AND LastName=@id2;
END

select * from Contacts;

update contacts set FirstName='Aruna', LastName='Amma' WHERE FirstName='Harshini' and LastName='Thota';