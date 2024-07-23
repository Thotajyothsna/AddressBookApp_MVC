--Getting the records based on Type

CREATE PROC GetByType
(
@Type VARCHAR(40)
)
AS
BEGIN
	SELECT * FROM Contacts WHERE Type=@Type;
END