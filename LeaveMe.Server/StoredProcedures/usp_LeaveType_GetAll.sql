CREATE PROCEDURE [dbo].[usp_LeaveType_GetAll]
@LeaveTypeID INT = 0
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN

	SELECT
	LeaveTypeID,LeaveTypeName,LeaveTypeDescription,ColorCode,LeaveDays,IsActive,CreatedBy,CreatedDate
	,UpdatedBy,UpdatedDate FROM LeaveType
	WHERE LeaveTypeID = CASE WHEN ISNULL(@LeaveTypeID,0) = 0 THEN LeaveTypeID ELSE @LeaveTypeID END
		
END