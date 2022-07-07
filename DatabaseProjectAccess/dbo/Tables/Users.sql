CREATE TABLE [dbo].[Users]
(
	user_id int not null primary key identity,
	user_name varchar(30) not null,
	email varchar(50)
)
