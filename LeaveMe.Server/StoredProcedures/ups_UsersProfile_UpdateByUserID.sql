
CREATE PROCEDURE ups_UsersProfile_UpdateByUserID	
	@UserID  uniqueidentifier ,
	@FirstName VARCHAR(150),
	@MiddleName  VARCHAR(150),
	@LastName  VARCHAR(150),
	@WorkTitleID INT,
	@DOJ DATETIME,
	@DisplayID VARCHAR(150),
	@Gender BIT,
	@DOB DATETIME,
	@MartialStatus INT,
	@Address  VARCHAR(1000),
	@City  VARCHAR(150),
	@State VARCHAR(150),
	@ZipCode  VARCHAR(15),
	@Country VARCHAR(150),
	@Mobile VARCHAR(30),
	@OtherEmailAddress VARCHAR(300),
	@UpdatedBy uniqueidentifier
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN
	
	UPDATE dbo.[UsersProfile]
	SET
	FirstName =@FirstName,
	MiddleName =@MiddleName,
	LastName=@LastName,
	WorkTitleID=@WorkTitleID,
	DOJ = @DOJ,
	DisplayID=@DisplayID,
	Gender=@Gender,
	DOB=@DOB,
	MartialStatus=@MartialStatus,
	[Address]=@Address,
	City=@City,
	[State]=@State,
	ZipCode=@ZipCode,
	Country=@Country,
	Mobile=@Mobile,
	OtherEmailAddress=@OtherEmailAddress,
	UpdatedBy=@UpdatedBy,
	UpdatedDate = GETDATE()
	WHERE UserID = @UserID 
   
END	



