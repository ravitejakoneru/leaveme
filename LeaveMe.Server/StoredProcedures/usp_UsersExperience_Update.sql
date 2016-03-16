CREATE PROCEDURE [dbo].[usp_UsersExperience_Update]
@Id INT,
@UserID UNIQUEIDENTIFIER,
@WorkTitle NVARCHAR(250),
@Company NVARCHAR(250),
@FromDate DATETIME,
@ToDate DATETIME,
@Comments NVARCHAR(800),
@UpdatedBy UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	UPDATE UsersExperience SET
	WorkTitle=@WorkTitle,
	Company=@Company,
	FromDate=@FromDate,
	ToDate=@ToDate,
	Comments=@Comments,
	UpdatedBy=@UpdatedBy,
	UpdatedDate = GETDATE()
	WHERE Id=@Id AND UserID=@UserID

		
END
