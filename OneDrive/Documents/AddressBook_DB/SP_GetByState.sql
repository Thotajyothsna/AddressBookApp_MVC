--Getting the records based on State

CREATE PROC GetByState
(
@State VARCHAR(40)
)
AS
BEGIN
	SELECT * FROM Contacts WHERE State=@State;
END
