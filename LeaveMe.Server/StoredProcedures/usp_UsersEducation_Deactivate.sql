CREATE PROCEDURE [dbo].[usp_UsersEducation_Deactivate]
@Id INT,
@UpdatedBy UNIQUEIDENTIFIER,
@IsActive BIT =0
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	UPDATE UsersEducation SET
	UpdatedBy=@UpdatedBy,
	UpdatedDate=GETDATE(),
	IsActive=@IsActive
	WHERE Id=@Id 
END

