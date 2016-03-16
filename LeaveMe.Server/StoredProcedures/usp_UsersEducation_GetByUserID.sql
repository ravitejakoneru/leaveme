CREATE PROCEDURE usp_UsersEducation_GetByUserID
@UserID UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	SELECT
	Id,UserID,Institute,CourseSpecialization,GPA,StartPeriod,
	EndPeriod,Comments,IsActive,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate
	FROM UsersEducation
	WHERE UserID=@UserID AND IsActive=1
		
END