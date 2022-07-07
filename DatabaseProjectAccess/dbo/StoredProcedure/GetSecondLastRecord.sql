CREATE PROCEDURE [dbo].[GetSecondLastRecord]
AS
	WITH CTE AS(SELECT *, ROW_NUMBER() OVER ( ORDER BY Emp_Id DESC) as RN FROM Employees)
	SELECT Emp_Id,Emp_Name,Dept_Name,Salary FROM CTE WHERE RN = 2
RETURN 
