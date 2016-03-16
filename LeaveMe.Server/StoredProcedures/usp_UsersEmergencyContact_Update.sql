CREATE PROCEDURE [dbo].[usp_UsersEmergencyContact_Update]
@Id INT,
@UserID UNIQUEIDENTIFIER,
@Name NVARCHAR(150),
@Relationship NVARCHAR(150),
@Mobile NVARCHAR(25),
@WorkMobile NVARCHAR(25),
@Notes NVARCHAR(400),
@UpdatedBy UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	UPDATE UsersEmergencyContact SET
	Name=@Name,
	Relationship=@Relationship,
	Mobile=@Mobile,
	WorkMobile=@WorkMobile,
	Notes = @Notes,
	UpdatedBy=@UpdatedBy,
	UpdatedDate=GETDATE()
	WHERE Id=@Id AND UserID=@UserID

		
END
