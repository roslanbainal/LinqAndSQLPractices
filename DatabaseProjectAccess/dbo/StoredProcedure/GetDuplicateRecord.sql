CREATE PROCEDURE [dbo].[GetDuplicateRecord]
AS
	WITH CTE AS(SELECT *, ROW_NUMBER() OVER(PARTITION BY User_Name, Email ORDER BY User_Id) RN FROM[dbo].[Users])
	 SELECT User_Id, User_Name, Email FROM CTE WHERE RN = 2
RETURN
