CREATE FUNCTION [dbo].[ufn_WorkTitles_GetWorkTitleByWorkTitleID]
(
	@WorkTitleID INT
)
RETURNS VARCHAR(500)
AS
BEGIN
	DECLARE @WorkTitle varchar(500)

	SELECT @WorkTitle = WorkTitle 
	FROM WorkTitles  (nolock)
	WHERE ID = @WorkTitleID

	RETURN @WorkTitle
END
