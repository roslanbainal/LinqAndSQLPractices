if not exists (select 1 from dbo.Users)
begin
	insert into users values
	('Sumit', 'sumit@gmail.com'),
	('Reshma', 'reshma@gmail.com'),
	('Farhana', 'farhana@gmail.com'),
	('Robin', 'robin@gmail.com'),
	('Robin', 'robin@gmail.com');
end

if not exists (select 1 from dbo.Employees)
begin
	insert into Employees values(101, 'Mohan', 'Admin', 4000);
	insert into Employees values(102, 'Rajkumar', 'HR', 3000);
	insert into Employees values(103, 'Akbar', 'IT', 4000);
	insert into Employees values(104, 'Dorvin', 'Finance', 6500);
	insert into Employees values(105, 'Rohit', 'HR', 3000);
	insert into Employees values(106, 'Rajesh',  'Finance', 5000);
	insert into Employees values(107, 'Preet', 'HR', 7000);
	insert into Employees values(108, 'Maryam', 'Admin', 4000);
	insert into Employees values(109, 'Sanjay', 'IT', 6500);
	insert into Employees values(110, 'Vasudha', 'IT', 7000);
	insert into Employees values(111, 'Melinda', 'IT', 8000);
	insert into Employees values(112, 'Komal', 'IT', 10000);
	insert into Employees values(113, 'Gautham', 'Admin', 2000);
	insert into Employees values(114, 'Manisha', 'HR', 3000);
	insert into Employees values(115, 'Chandni', 'IT', 4500);
	insert into Employees values(116, 'Satya', 'Finance', 6500);
	insert into Employees values(117, 'Adarsh', 'HR', 3500);
	insert into Employees values(118, 'Tejaswi', 'Finance', 5500);
	insert into Employees values(119, 'Cory', 'HR', 8000);
	insert into Employees values(120, 'Monica', 'Admin', 5000);
	insert into Employees values(121, 'Rosalin', 'IT', 6000);
	insert into Employees values(122, 'Ibrahim', 'IT', 8000);
	insert into Employees values(123, 'Vikram', 'IT', 8000);
	insert into Employees values(124, 'Dheeraj', 'IT', 11000);
end

if not exists (select 1 from dbo.Doctors)
begin
insert into Doctors values
(1, 'Dr. Shashank', 'Ayurveda', 'Apollo Hospital', 'Bangalore', 2500),
(2, 'Dr. Abdul', 'Homeopathy', 'Fortis Hospital', 'Bangalore', 2000),
(3, 'Dr. Shwetha', 'Homeopathy', 'KMC Hospital', 'Manipal', 1000),
(4, 'Dr. Murphy', 'Dermatology', 'KMC Hospital', 'Manipal', 1500),
(5, 'Dr. Farhana', 'Physician', 'Gleneagles Hospital', 'Bangalore', 1700),
(6, 'Dr. Maryam', 'Physician', 'Gleneagles Hospital', 'Bangalore', 1500);
end

if not exists (select 1 from dbo.Login_Details)
begin
insert into login_details values
(101, 'Michael', CURRENT_TIMESTAMP),
(102, 'James', CURRENT_TIMESTAMP),
(103, 'Stewart', CURRENT_TIMESTAMP+1),
(104, 'Stewart', CURRENT_TIMESTAMP+1),
(105, 'Stewart', CURRENT_TIMESTAMP+1),
(106, 'Michael', CURRENT_TIMESTAMP+2),
(107, 'Michael', CURRENT_TIMESTAMP+2),
(108, 'Stewart', CURRENT_TIMESTAMP+3),
(109, 'Stewart', CURRENT_TIMESTAMP+3),
(110, 'James', CURRENT_TIMESTAMP+4),
(111, 'James', CURRENT_TIMESTAMP+4),
(112, 'James', CURRENT_TIMESTAMP+5),
(113, 'James', CURRENT_TIMESTAMP+6);
end
