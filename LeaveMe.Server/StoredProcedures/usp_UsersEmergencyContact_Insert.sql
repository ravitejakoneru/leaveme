CREATE PROCEDURE [dbo].[usp_UsersEmergencyContact_Insert]
@UserID UNIQUEIDENTIFIER,
@Name NVARCHAR(150),
@Relationship NVARCHAR(150),
@Mobile NVARCHAR(25),
@WorkMobile NVARCHAR(25),
@Notes NVARCHAR(400),
@CreatedBy UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	INSERT INTO [dbo].[UsersEmergencyContact]
	(UserID,Name,Relationship,Mobile,WorkMobile,Notes,IsActive,CreatedBy,CreatedDate)
	VALUES(@UserID,@Name,@Relationship,@Mobile,@WorkMobile,@Notes,1,@CreatedBy,GETDATE())
		
END

