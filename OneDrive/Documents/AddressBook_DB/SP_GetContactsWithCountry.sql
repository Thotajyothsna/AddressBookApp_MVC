--Fetching Contacts Table by Joining with StateWithCountry Table

CREATE PROC GetContactsWithCountry
AS
BEGIN
	SELECT C.FirstName,C.LastName,C.PhoneNumber,C.State,S.Country
	FROM Contacts C JOIN StateWithCountry S ON C.State=S.State;
END