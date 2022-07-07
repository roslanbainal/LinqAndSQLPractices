CREATE PROCEDURE [dbo].[GetHighestAndLowestSalary]
AS
	select s.*
from employees e
join (
	select 
	*,
	max(salary) over (partition by dept_name) as max_salary,
	min(salary) over (partition by dept_name) as min_salary
	from employees
	) as s
on e.emp_id = s.emp_id
and (e.salary = s.max_salary or e.salary = s.min_salary)

RETURN
