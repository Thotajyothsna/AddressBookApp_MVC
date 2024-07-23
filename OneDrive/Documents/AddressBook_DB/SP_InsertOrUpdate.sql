
--Update if Data is Already Present else Insert Data

ALTER PROC InsertOrUpdate
(
@FirstName VARCHAR(30),
@LastName VARCHAR(30),
@Type VARCHAR(40),
@PhoneNumber VARCHAR(20),
@Email VARCHAR(50),
@Address VARCHAR(100),
@City VARCHAR(50),
@State VARCHAR(50),
@Zipcode VARCHAR(10)
)
AS
BEGIN
Declare @RecordExists INT
SET @RecordExists=(Select Count(*) From Contacts WHERE FirstName=@FirstName AND LastName=@LastName);

IF(@RecordExists=0)
	BEGIN
		INSERT INTO Contacts 
		VALUES(@FirstName,@LastName,@Type,@PhoneNumber,@Email,@Address,@City,@State,@Zipcode);
	END
ELSE
	BEGIN
		UPDATE Contacts SET Type=@Type,PhoneNumber=@PhoneNumber
		,Email=@Email,Address=@Address,City=@City,State=@State,Zipcode=@Zipcode
		WHERE FirstName=@FirstName AND LastName=@LastName;
	END
END


--exec InsertOrUpdate 'Jyothsna','Thota','Troublemaker','6577585994','jyo@email','dhfgfkjd','Tirupati','Kerala','345667';