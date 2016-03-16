CREATE VIEW [dbo].[vw_Users_Info]
	AS 
SELECT US.UserID, US.UserName, US.Email, US.[Password], 
		RS.RoleID,RS.RoleName, 
		UP.FirstName, UP.MiddleName, UP.LastName,
		UP.FirstName +' '+UP.LastName AS 'DisplayName',
		Up.DisplayID,
		US.IsTerminated,US.IsLockedOut,US.IsActive
FROM dbo.Users US
INNER JOIN dbo.UsersRole UR
ON US.UserID = UR.UserID
INNER JOIN UsersProfile UP
ON UP.UserID = US.UserID
INNER JOIN Roles RS 
ON RS.RoleID = UR.RoleID
