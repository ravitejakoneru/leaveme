CREATE PROCEDURE usp_UsersExperience_GetByUserID
@UserID UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	SELECT
	Id,UserID,WorkTitle,Company,FromDate,ToDate,Comments,IsActive,
	CreatedBy,UpdatedBy,CreatedDate,UpdatedDate FROM UsersExperience
	WHERE UserID=@UserID AND IsActive=1
		
END