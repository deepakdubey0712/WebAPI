--Creating the Employees table with an auto-incrementing EmployeeID starting from 101.
CREATE TABLE public.Employees (
    EmployeeID INT GENERATED ALWAYS AS IDENTITY (START WITH 101 INCREMENT BY 1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    DOB DATE NOT NULL,
    DOJ DATE NOT NULL
);

--Creating the Departments table with an auto-incrementing DepartmentID starting from 1.
CREATE TABLE Departments (
    DepartmentID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);

--Creating the Grades table with an auto-incrementing GradeID starting from 1.
CREATE TABLE Grades (
    GradeID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    GradeName CHAR(1) CHECK (GradeName IN ('A', 'B', 'C')),
    PromotionCycle VARCHAR(20)
);

--Creating the EmployeeDepartment table to link Employees and department with an auto-incrementing EmpDeptID starting from 1.
CREATE TABLE EmployeeDepartments (
    EmpDeptID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    EmployeeID INT NOT NULL REFERENCES Employees(EmployeeID),
    DepartmentID INT NOT NULL REFERENCES Departments(DepartmentID),
    StartDate DATE,
    EndDate DATE
);

--Creating the EmployeeGrade table to link Employees and Grades with an auto-incrementing EmpGradeID starting from 1.
CREATE TABLE EmployeeGrades (
    EmpGradeID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    EmployeeID INT NOT NULL REFERENCES Employees(EmployeeID),
    GradeID INT NOT NULL REFERENCES Grades(GradeID),
    StartDate DATE,
    EndDate DATE
);

--Creating the SalaryComponent table with an auto-incrementing ComponentID starting from 1.
CREATE TABLE SalaryComponents (
    ComponentID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    ComponentName VARCHAR(50) NOT NULL,
    IsTaxable BOOLEAN DEFAULT FALSE
);

--Creating the EmployeeSalary table to link Employees and Salary Components with an auto-incrementing EmployeeSalaryID starting from 1.
CREATE TABLE EmployeeSalaries (
    EmployeeSalaryID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    EmployeeID INT NOT NULL REFERENCES Employees(EmployeeID),
    ComponentID INT NOT NULL REFERENCES SalaryComponent(ComponentID),
    Amount DECIMAL(10,2) NOT NULL
);

--Creating the Promotion table to track employee promotions with an auto-incrementing PromotionID starting from 1.
CREATE TABLE Promotions (
    PromotionID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    EmployeeID INT NOT NULL REFERENCES Employees(EmployeeID),
    OldGradeID INT REFERENCES Grades(GradeID),
    NewGradeID INT NOT NULL REFERENCES Grades(GradeID),
    PromotionDate DATE
);
 
--Creating the Payslip table to store payslip information with an auto-incrementing PayslipID starting from 1.
CREATE TABLE Payslips (
    PayslipID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    EmployeeID INT NOT NULL REFERENCES Employees(EmployeeID),
    Month INT CHECK (Month BETWEEN 1 AND 12),
    Year INT CHECK (Year >= 2000),
    PayslipDate DATE NOT NULL,
    TotalEarnings DECIMAL(10,2),
    TotalDeductions DECIMAL(10,2),
	NetPay DECIMAL(10,2)
);

--Creating the PayslipComponent table to link Payslips and Salary Components with an auto-incrementing PayslipComponentID starting from 1.
CREATE TABLE PayslipComponents (
    PayslipID INT REFERENCES Payslip(PayslipID),
    ComponentID INT REFERENCES SalaryComponent(ComponentID),
    Amount DECIMAL(10,2),
    PRIMARY KEY (PayslipID, ComponentID)
);

--Creating the DeductionComponent table with an auto-incrementing DeductionID starting from 1.
CREATE TABLE DeductionComponents (
    DeductionID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    DeductionName VARCHAR(50),
    Rule VARCHAR(100)
);