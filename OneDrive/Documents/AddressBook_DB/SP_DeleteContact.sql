--Deleting the record based on FirstName and LastName
CREATE PROC DeleteContact
(
@id1 VARCHAR(30),
@id2 VARCHAR(30)
)
AS
BEGIN
	DELETE Contacts WHERE FirstName=@id1 AND LastName=@id2;
END

