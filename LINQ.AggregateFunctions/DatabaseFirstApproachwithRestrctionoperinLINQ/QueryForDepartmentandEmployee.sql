Select * from Departments
Select * from Employee
------------------------Qurey-------------------
create table Departments
(
ID int	primary key identity,
Name Nvarchar(50),
Location Nvarchar(50)
)

create table Employee
(
ID int	primary key identity,
FirstName nvarchar(50),
LastName nvarchar(50),
Gender nvarchar(50),
Salary int,
DepartmentId int foreign key references Departments(Id)
)

insert into Departments values ('IT','Norfolk')
insert into Departments values ('HR','ENorfolk')
insert into Departments values ('Payroll','WNorfolk')

insert into Employee values ('Mark', 'Hastrings','Male', 60000,1)
insert into Employee values ('Mark2', 'Hastrings','Male', 70000,1)
insert into Employee values ('Mark3', 'Hastrings','Male', 80000,1)
insert into Employee values ('Mar4', 'Hastrings','Male', 50000,1)
insert into Employee values ('Mark5', 'Hastrings','Male', 80000,1)
insert into Employee values ('Mark', 'Hastrings','Female', 100000,1)