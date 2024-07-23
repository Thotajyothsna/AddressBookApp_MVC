CREATE PROC InsertContact

@FirstName VARCHAR(30),
@LastName VARCHAR(30),
@Type VARCHAR(40),
@PhoneNumber VARCHAR(20),
@Email VARCHAR(50),
@Address VARCHAR(100),
@City VARCHAR(50),
@State VARCHAR(50),
@Zipcode VARCHAR(10)

AS
BEGIN
	INSERT INTO Contacts 
	VALUES(@FirstName,@LastName,@Type,@PhoneNumber,@Email,@Address,@City,@State,@Zipcode);
END

