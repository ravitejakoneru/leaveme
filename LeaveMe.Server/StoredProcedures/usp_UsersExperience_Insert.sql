CREATE PROCEDURE [dbo].[usp_UsersExperience_Insert]
@UserID UNIQUEIDENTIFIER,
@WorkTitle NVARCHAR(250),
@Company NVARCHAR(250),
@FromDate DATETIME,
@ToDate DATETIME,
@Comments NVARCHAR(800),
@CreatedBy UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	INSERT INTO [dbo].[UsersExperience]
	(UserID,WorkTitle,Company,FromDate,ToDate,Comments,IsActive,CreatedBy,CreatedDate)
	VALUES(@UserID,@WorkTitle,@Company,@FromDate,@ToDate,@Comments,1,@CreatedBy,GETDATE())
		
END

