CREATE PROCEDURE [dbo].[usp_UsersExperience_GetByID]
@ID INT
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	SELECT
	Id,UserID,WorkTitle,Company,FromDate,ToDate,Comments,IsActive,
	CreatedBy,UpdatedBy,CreatedDate,UpdatedDate FROM UsersExperience
	WHERE ID=@ID 
		
END
