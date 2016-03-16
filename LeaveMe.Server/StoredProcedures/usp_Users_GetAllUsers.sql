CREATE PROCEDURE [dbo].[usp_Users_GetAllUsers]
	@IsActive bit = 1
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN
	SELECT 
		UserID, Email, FirstName, MiddleName, 
		LastName, DisplayName, DisplayID, RoleID,
		RoleName, WorkTitleID, WorkTitle, DOB,
		DOJ, Mobile, OtherEmailAddress,
		IsLoginActive,IsUserActive
	FROM vw_Users_ViewUsers WHERE IsUserActive=@IsActive

END
	

