CREATE PROCEDURE [dbo].[usp_UsersReporting_Insert]
@UserID UNIQUEIDENTIFIER,
@RepotingToUserID UNIQUEIDENTIFIER,
@IsDirectRepoting BIT,
@CreatedBy UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	INSERT INTO [dbo].[UsersReporting]
	(UserID,RepotingToUserID,IsDirectRepoting,IsActive,CreatedBy,CreatedDate)
	VALUES(@UserID,@RepotingToUserID,@IsDirectRepoting,1,@CreatedBy,GETDATE())
		
END

