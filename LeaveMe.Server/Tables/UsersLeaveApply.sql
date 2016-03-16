CREATE TABLE [dbo].[UsersLeaveApply]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[UserID] UNIQUEIDENTIFIER NOT NULL,
	[LeaveTypeID] INT NOT NULL ,
	[LeaveFromDate] datetime NOT NULL,
	[LeaveToDate] datetime NOT NULL,
	[ApprovedDays] INT  NULL , 
	[ApprovedBy] UNIQUEIDENTIFIER  NULL , 
	[ApprovedDate] datetime  NULL , 
	[Reason] VARCHAR(MAX) NOT NULL,
	[IsApproved] BIT NOT NULL DEFAULT 0,
	[IsActive] BIT NULL DEFAULT 1, 
	[CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
	[UpdatedBy] UNIQUEIDENTIFIER NULL, 
	[CreatedDate] DATETIME NOT NULL DEFAULT (getdate()) , 
	[UpdatedDate] DATETIME NULL 
	CONSTRAINT [FK_LeaveApply_ToUser] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID])
	CONSTRAINT [FK_LeaveApply_ToLeaveType] FOREIGN KEY ([LeaveTypeID]) REFERENCES [LeaveType]([LeaveTypeID])
	CONSTRAINT [FK_LeaveApply_ApprovedBy_ToUser] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID])


)
