--Getting the records based on FirstName

CREATE PROC GetByFirstName
(
@FirstName VARCHAR(40)
)
AS
BEGIN
	SELECT * FROM Contacts WHERE FirstName=@FirstName;
END