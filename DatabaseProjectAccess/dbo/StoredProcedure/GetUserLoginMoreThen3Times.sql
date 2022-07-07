CREATE PROCEDURE [dbo].[GetUserLoginMoreThen3Times]
	@param varchar(50)
AS
BEGIN
if(@param = 'GroupMethod')
	BEGIN
		select 
			user_name as 'Repeated_Names'
		from Login_Details
		group by User_Name
		having count(user_name) > 3
		order by user_name desc
	RETURN 
	END
else if(@param = 'LeadMethod')
	BEGIN
	select 
		distinct Repeated_Names
		from (
		select *,
			case when 
				user_name = lead(user_name) over(order by login_id)
				and 
				user_name = lead(user_name,2) over(order by login_id)
			then 
				user_name 
		else null 
		end as Repeated_Names
		from login_details) x
	where x.Repeated_Names is not null;
	RETURN
	END
END
