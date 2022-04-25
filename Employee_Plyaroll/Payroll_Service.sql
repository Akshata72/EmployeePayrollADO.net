--UC1-Create_Payroll_Service_Database.
Create database payroll_service;
go
use payroll_service
go

--UC2-Create_Employee_Payroll_Table.
create Table Employee_Payroll(
ID INT identity(1,1) not null Primary key,
First_Name varchar(50),
Last_Name varchar(50),
Salary bigint,
StartDate Datetime
);

--UC3-Insert_Data_into_Employee_Payroll_Table.
insert into Employee_Payroll(First_Name,Last_Name,Salary,StartDate) values 
            ('Akshata','Panchal',15000,'2020-04-19'),
			('Aditya','Shinde',18000,'2021-04-19'),
			('Vishal','Gangane',20000,'2019-04-19'),
			('Vaishnavi','Sabale',17000,'2021-05-19'),
			('Supriya','Kadam',22000,'2021-08-19');

--UC4-Ability_ToRetrive_AllThe_Employee_Payroll.		
select * from Employee_Payroll;

--UC5-Ability to retrieve salary data for a particular employee as well as all employees who have joined in a particular data range.
select Salary from Employee_Payroll where First_Name = 'Vishal';

select Salary from Employee_payroll where StartDate between CAST('2020-04-19' as date) and GETDATE();


--UC6-Ability to add Gender to Employee Payroll Table.
alter table Employee_Payroll add Gender varchar(1);
UPDATE Employee_Payroll set Gender ='F';
UPDATE Employee_Payroll set Gender ='M' where First_Name = 'Aditya' or First_Name ='Vishal';

--UC7-Ability to find sum, average, min, max and number of male and female employees.
Select SUM(Salary) As Sum_Of_Salary_ForFemale, AVG(Salary)As Avrage_Of_Female_Salary,MIN(Salary)As Minimum_Salary_From_Female,MAX(Salary)As Maximum_Salary,COUNT(Gender)As No_Of_Females from Employee_Payroll where Gender = 'F' GROUP BY Gender;

Select SUM(Salary) As Sum_Of_Salary_ForMale, AVG(Salary)As Avrage_Of_Male_Salary,MIN(Salary)As Minimum_Salary_From_Male,MAX(Salary)As Maximum_Salary,COUNT(Gender)As No_Of_Males from Employee_Payroll where Gender = 'M' GROUP BY Gender;


--UC8-Ability to extend employee_payroll data to store employee information like employee phone, address and department.
Create Table Employee_Information
(Emp_Id int identity foreign key references Employee_Payroll(ID),
Department varchar(50) not null,
Address varchar(50) default'MAHARASTRA',
Phone_Number bigint);

insert into Employee_Information(Department,Phone_Number) values
('HR',7218465445),
('Manager',9834782454),
('Executive',7378318454),
('Asst.Manager',8809086453),
('Sale',8303005482);

select * from Employee_Information;


--UC9-Ability to extend employee_payroll table to have Basic Pay,Deductions,Taxable Pay,Income Tax, Net Pay.
alter table Employee_Payroll add Basic_Pay bigint;
alter table Employee_Payroll add Deducations bigint;
alter table Employee_Payroll add Taxable_Pay bigint;
alter table Employee_Payroll add Income_Tax bigint;
alter table Employee_Payroll add Net_Pay bigint;

UPDATE Employee_Payroll set Basic_Pay=20000;
UPDATE Employee_Payroll set Deducations = 2000;
UPDATE Employee_Payroll set Taxable_Pay = 1000;
UPDATE Employee_Payroll set Income_Tax = 200;
UPDATE Employee_Payroll set Net_Pay = 18000;

select * from Employee_Payroll;
