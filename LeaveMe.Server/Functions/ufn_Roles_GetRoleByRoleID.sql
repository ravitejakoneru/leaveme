CREATE FUNCTION [dbo].[ufn_Roles_GetRoleByRoleID]
(
	@RoleID INT
)
RETURNS VARCHAR(500)
AS
BEGIN
	DECLARE @RoleName varchar(500)

	SELECT @RoleName = RoleName 
	FROM Roles  (nolock)
	WHERE RoleID = @RoleID

	RETURN @RoleName
END