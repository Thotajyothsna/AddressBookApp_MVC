--Getting Contact with given FirstName and LastName
CREATE PROC GetByName
(
@FirstName VARCHAR(30),
@LastName VARCHAR(30)
)
AS
BEGIN
	SELECT * FROM Contacts WHERE FirstName=@FirstName and LastName=@LastName;
END
EXEC GetByName @FirstName='Jyothsna',@LastName='Thota';