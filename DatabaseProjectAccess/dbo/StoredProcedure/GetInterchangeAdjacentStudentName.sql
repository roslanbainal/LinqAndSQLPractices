CREATE PROCEDURE [dbo].[GetInterchangeAdjacentStudentName]
AS
	select 
	Id,
	Student_Name,
	case when
		id%2 <> 0 
	then lead(student_name,1,student_name) over(order by id)
	when 
		id%2 = 0 
	then lag(student_name) over(order by id) 
	end as new_student_name
from students;
RETURN 
