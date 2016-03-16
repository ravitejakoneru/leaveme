CREATE TABLE [dbo].[LeaveType]
(
	[LeaveTypeID] INT NOT NULL PRIMARY KEY IDENTITY,
	[LeaveTypeName] VARCHAR(250) NOT NULL, 
	[LeaveTypeDescription] VARCHAR(500), 
	[ColorCode] VARCHAR(8), 
	[LeaveDays] INT NOT NULL DEFAULT 0, 
	[IsActive] BIT NULL DEFAULT 1, 
	[CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
	[UpdatedBy] UNIQUEIDENTIFIER NULL, 
	[CreatedDate] DATETIME NOT NULL DEFAULT (getdate()) , 
	[UpdatedDate] DATETIME NULL 
	CONSTRAINT [CK_LeaveType_LeaveTypeName] UNIQUE (LeaveTypeName) 

)
