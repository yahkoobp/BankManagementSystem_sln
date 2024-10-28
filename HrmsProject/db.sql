Create Database HrmsAppDb;
Use HrmsAppDb;
CREATE TABLE Employee (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Age INT CHECK(Age BETWEEN 19 AND 60),
    Salary DECIMAL(18, 2),
    JobTitle NVARCHAR(20),
    ActiveStatus BIT
);

Select * From Employee;

Insert Into Employee
(Name, Age, Salary, JobTitle, ActiveStatus)
Values ('Dravid', 50, 10000, 'Coach', 1),
('Rohit', 35, 8000, 'Batsman', 1);