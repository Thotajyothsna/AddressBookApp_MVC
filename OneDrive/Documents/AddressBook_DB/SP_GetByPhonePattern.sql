--

CREATE PROC GetByPhonePattern
(
@PhoneNumber VARCHAR(20)
)
AS
BEGIN
DECLARE @Pattern VARCHAR(25);
SET @Pattern='%'+@PhoneNumber+'%';
select * from contacts where PhoneNumber like @Pattern;
END
