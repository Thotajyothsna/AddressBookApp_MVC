--Fetching the records by FirstName or LastName

CREATE PROC GetByAnyName
(
@Name VARCHAR(30)
)
AS
BEGIN
	SELECT * FROM Contacts WHERE Firstname=@Name OR LastName=@Name;
END
