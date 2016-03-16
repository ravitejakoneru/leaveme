CREATE FUNCTION [dbo].[ufn_vw_Users_GetByUserID]
(
	@UserID UNIQUEIDENTIFIER
)
RETURNS VARCHAR(500)
AS
BEGIN
	DECLARE @UserDetails varchar(500)

	SELECT @UserDetails = 	CASE WHEN UP.MiddleName IS NULL THEN UP.FirstName+' '+UP.LastName ELSE UP.FirstName+' '+ UP.MiddleName+' '+UP.LastName END
	FROM UsersProfile UP  (nolock)
	WHERE UserID = @UserID

	RETURN @UserDetails
END

GO



