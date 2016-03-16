CREATE TABLE [dbo].[WorkTitles]
(
	[ID] INT NOT NULL IDENTITY PRIMARY KEY, 
	[WorkTitle] NVARCHAR(500) NULL, 
	[WorkDescription] NVARCHAR(800) NULL, 
	[IsActive] BIT NULL DEFAULT 1, 
	[CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
	[UpdatedBy] UNIQUEIDENTIFIER NULL, 
	[CreatedDate] DATETIME NOT NULL DEFAULT (getdate()) , 
	[UpdatedDate] DATETIME NULL 
	CONSTRAINT [CK_WorkTitles_WorkTitle] UNIQUE (WorkTitle) 
)
