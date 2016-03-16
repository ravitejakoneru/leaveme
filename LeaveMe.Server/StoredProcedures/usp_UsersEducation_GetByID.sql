CREATE PROCEDURE usp_UsersEducation_GetByID
@ID INT
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	SELECT
	Id,UserID,Institute,CourseSpecialization,GPA,StartPeriod,
	EndPeriod,Comments,IsActive,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate
	FROM UsersEducation
	WHERE ID=@ID 
		
END