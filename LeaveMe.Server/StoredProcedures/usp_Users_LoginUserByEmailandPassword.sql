
CREATE PROCEDURE usp_Users_LoginUserByEmailandPassword	
	@Email varchar(150),
	@Password varchar(150)
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN
	
	SELECT 
	UserID, UserName, Email, [Password], RoleName, 
	FirstName, MiddleName, LastName,DisplayName,DisplayID
	FROM dbo.vw_Users_Info 
	WHERE Email = @Email AND [Password]=@Password  
	AND IsTerminated=0 AND IsLockedOut=0 AND IsActive=1
END	



