CREATE TABLE [dbo].[Roles]
(
	[RoleID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[RoleName] NVARCHAR(200) NULL, 
	[RoleDescription] NVARCHAR(250) NULL, 
	[IsActive] BIT NULL DEFAULT 1, 
	[CreatedBy] UNIQUEIDENTIFIER NOT NULL , 
	[UpdatedBy] UNIQUEIDENTIFIER NULL, 
	[CreatedDate] DATETIME NOT NULL DEFAULT (getdate()) , 
	[UpdatedDate] DATETIME NULL,
	CONSTRAINT [CK_Roles_LeaveTypeName] UNIQUE (RoleName) 
 
)
