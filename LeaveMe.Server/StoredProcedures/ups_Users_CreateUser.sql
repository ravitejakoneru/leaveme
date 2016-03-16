
CREATE PROCEDURE ups_Users_CreateUser	
	 @Email nvarchar(300)
	,@Password nvarchar(300)
	,@CreatedBy uniqueidentifier
	,@FirstName nvarchar(300)
	,@MiddleName nvarchar(300)
	,@LastName nvarchar(300)
	,@WorkTitleID INT
	,@RoleID INT
	
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN
	
	DECLARE @UserID UNIQUEIDENTIFIER
	SET @UserID = NEWID()

	--- creates users  
	INSERT INTO [dbo].[Users] (UserID,Email,[Password],AccessFailedCount,IsLockedOut,IsActive
		,CreatedBy,CreatedDate)
	VALUES(@UserID,@Email,@Password,0,0,1,@CreatedBy,GETDATE())
    
	---creates UsersProfile
	INSERT INTO [dbo].[UsersProfile] (UserID,FirstName,MiddleName,LastName,WorkTitleID,CreatedBy,CreatedDate,IsActive)
	VALUES(@UserID,@FirstName,@MiddleName,@LastName,@WorkTitleID,@CreatedBy,GETDATE(),1)
	
	---assigns Users Role
	INSERT INTO UsersRole(UserID,RoleID,CreatedBy)
	VALUES (@UserID,@RoleID,@CreatedBy)
END	



