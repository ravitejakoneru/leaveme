CREATE PROCEDURE [dbo].[usp_LeaveType_Insert]
@LeaveTypeName NVARCHAR(250),
@LeaveTypeDescription NVARCHAR(450),
@ColorCode NVARCHAR(8),
@LeaveDays INT,
@CreatedBy UNIQUEIDENTIFIER
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	INSERT INTO [dbo].[LeaveType]
	(LeaveTypeName,LeaveTypeDescription,ColorCode,LeaveDays,IsActive,CreatedBy,CreatedDate)
	VALUES(@LeaveTypeName,@LeaveTypeDescription,@ColorCode,@LeaveDays,1,@CreatedBy,GETDATE())
		
END