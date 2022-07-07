CREATE TABLE [dbo].[Doctors]
(
	Id int primary key,
	Name varchar(50) not null,
	Speciality varchar(100),
	Hospital varchar(50),
	City varchar(50),
	Consultation_fee int
)
