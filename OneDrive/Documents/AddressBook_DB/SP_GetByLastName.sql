--Getting the records based on LastName

CREATE PROC GetByLastName
(
@LastName VARCHAR(40)
)
AS
BEGIN
	SELECT * FROM Contacts WHERE LastName=@LastName;
END