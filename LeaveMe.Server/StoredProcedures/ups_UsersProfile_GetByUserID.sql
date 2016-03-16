
CREATE PROCEDURE ups_UsersProfile_GetByUserID	
	@UserID  uniqueidentifier 
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN
	
	SELECT  
	UserID,FirstName,MiddleName,LastName,WorkTitleID, 
	dbo.ufn_WorkTitles_GetWorkTitleByWorkTitleID(WorkTitleID) as 'WorkTitle',
	DisplayID,DOJ,Gender,DOB,MartialStatus,[Address],City,[State],ZipCode,
	Country,Mobile,OtherEmailAddress,IsActive,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate

	FROM dbo.[UsersProfile]
	WHERE UserID = @UserID 
   
END	



