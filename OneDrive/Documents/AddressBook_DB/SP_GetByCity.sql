--Getting the records based on City

CREATE PROC GetByCity
(
@City VARCHAR(40)
)
AS
BEGIN
	SELECT * FROM Contacts WHERE City=@City;
END