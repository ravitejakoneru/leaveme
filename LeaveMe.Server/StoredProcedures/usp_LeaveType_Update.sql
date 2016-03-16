CREATE PROCEDURE [dbo].[usp_LeaveType_Update]
@LeaveTypeID INT,
@LeaveTypeName NVARCHAR(250),
@LeaveTypeDescription NVARCHAR(450),
@ColorCode NVARCHAR(8),
@LeaveDays INT,
@IsActive BIT,
@UpdatedBy UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	UPDATE [dbo].[LeaveType]
	SET
	LeaveTypeName = @LeaveTypeName,
	LeaveTypeDescription = @LeaveTypeDescription,
	ColorCode = @ColorCode,
	LeaveDays = @LeaveDays,
	IsActive = @IsActive,
	UpdatedBy = @UpdatedBy,
	UpdatedDate = GETDATE()
	WHERE LeaveTypeID = @LeaveTypeID

END
