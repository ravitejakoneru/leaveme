CREATE PROCEDURE [dbo].[usp_UsersReporting_GetByRepotingToUserID]
@RepotingToUserID UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	SELECT 
	UserID,
	dbo.ufn_vw_Users_GetByUserID(UserID) AS 'UserDisplayName',
	RepotingToUserID,
	dbo.ufn_vw_Users_GetByUserID(RepotingToUserID) AS 'RepotingToUserDisplayName',
	IsDirectRepoting,IsActive,CreatedBy,CreatedDate
	FROM [dbo].[UsersReporting]
	WHERE RepotingToUserID=@RepotingToUserID
	
END
