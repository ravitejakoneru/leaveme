CREATE VIEW [dbo].[vw_Users_ViewUsers]
	AS 
 
SELECT US.UserID, US.Email,  
	UP.FirstName,
	ISNULL(UP.MiddleName,'-') AS 'MiddleName',  
	UP.LastName,
	UP.FirstName +' '+UP.LastName AS 'DisplayName',
	ISNULL(Up.DisplayID,'-') AS 'DisplayID', 
	CASE WHEN UP.MiddleName IS NULL THEN UP.FirstName+' '+UP.LastName ELSE UP.FirstName+' '+ UP.MiddleName+' '+UP.LastName END AS 'FullName',
	RS.RoleID,RS.RoleName, 
	UP.WorkTitleID,
	dbo.ufn_WorkTitles_GetWorkTitleByWorkTitleID(UP.WorkTitleID) AS 'WorkTitle',
	ISNULL( CONVERT(VARCHAR(50), UP.DOB,121),'') AS 'DOB',
	ISNULL( CONVERT(VARCHAR(50), UP.DOJ,121),'') AS 'DOJ',
	ISNULL(UP.Mobile,'-') AS 'Mobile',
	ISNULL(UP.OtherEmailAddress,'-') AS 'OtherEmailAddress',
	US.IsActive AS 'IsLoginActive',
	UP.IsActive AS 'IsUserActive'
FROM dbo.Users US
INNER JOIN dbo.UsersRole UR
ON US.UserID = UR.UserID
INNER JOIN UsersProfile UP
ON UP.UserID = US.UserID
INNER JOIN Roles RS 
ON RS.RoleID = UR.RoleID
