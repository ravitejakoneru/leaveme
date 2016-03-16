CREATE PROCEDURE [dbo].[usp_UsersEmergencyContact_GetByUserID]
@UserID UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	SELECT
	Id,UserID,Name,Relationship,Mobile,WorkMobile,Notes,CreatedBy,CreatedDate,
	UpdatedBy,UpdatedDate,IsActive
	FROM UsersEmergencyContact
	WHERE UserID=@UserID AND IsActive=1
		
END
