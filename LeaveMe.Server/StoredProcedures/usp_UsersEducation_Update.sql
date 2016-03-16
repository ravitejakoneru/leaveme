CREATE PROCEDURE [dbo].[usp_UsersEducation_Update]
@Id INT,
@UserID UNIQUEIDENTIFIER,
@Institute NVARCHAR(250),
@CourseSpecialization NVARCHAR(250),
@GPA decimal,
@StartPeriod NVARCHAR(10),
@EndPeriod NVARCHAR(10),
@Comments NVARCHAR(800),
@UpdatedBy UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	UPDATE UsersEducation SET
	Institute=@Institute,
	CourseSpecialization=@CourseSpecialization,
	GPA=@GPA,
	StartPeriod = @StartPeriod,
	EndPeriod = @EndPeriod,
	UpdatedBy=@UpdatedBy,
	Comments = @Comments,
	UpdatedDate=GETDATE()
	WHERE Id=@Id AND UserID=@UserID

		
END
