CREATE PROCEDURE [dbo].[usp_UsersEmergencyContact_GetByID]
@ID INT
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	SELECT
	Id,UserID,Name,Relationship,Mobile,WorkMobile,Notes,CreatedBy,CreatedDate,
	UpdatedBy,UpdatedDate,IsActive
	FROM UsersEmergencyContact
	WHERE ID=@ID 
		
END
