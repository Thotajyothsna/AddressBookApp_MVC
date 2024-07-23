--
CREATE PROC ContactsAllInfo
AS
BEGIN
select c.FirstName,c.LastName,c.PhoneNumber,c.State,s.Country,t.typedescription from Contacts c 
join StateWithCountry s on c.State=s.State 
join TypeDescription t on c.Type=t.TypeName;
END

