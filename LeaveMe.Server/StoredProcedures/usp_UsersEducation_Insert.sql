CREATE PROCEDURE [dbo].[usp_UsersEducation_Insert]
@UserID UNIQUEIDENTIFIER,
@Institute NVARCHAR(250),
@CourseSpecialization NVARCHAR(250),
@GPA decimal,
@StartPeriod NVARCHAR(10),
@EndPeriod NVARCHAR(10),
@Comments NVARCHAR(800),
@CreatedBy UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	INSERT INTO [dbo].[UsersEducation]
	(UserID,Institute,CourseSpecialization,GPA,StartPeriod,EndPeriod,Comments,IsActive,CreatedBy,CreatedDate)
	VALUES(@UserID,@Institute,@CourseSpecialization,@GPA,@StartPeriod,@EndPeriod,@Comments,1,@CreatedBy,GETDATE())
		
END

