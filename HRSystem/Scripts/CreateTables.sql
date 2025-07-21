-- Creating the Employees table
CREATE TABLE IF NOT EXISTS Employees (
    EmployeeID INT GENERATED ALWAYS AS IDENTITY (START WITH 101 INCREMENT BY 1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    DOB DATE NOT NULL,
    DOJ DATE NOT NULL
);

-- Creating the Departments table
CREATE TABLE IF NOT EXISTS Departments (
    DepartmentID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);

-- Creating the Grades table
CREATE TABLE IF NOT EXISTS Grades (
    GradeID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    GradeName CHAR(1) CHECK (GradeName IN ('A', 'B', 'C')),
    PromotionCycle VARCHAR(20)
);

-- Creating the EmployeeDepartments table
CREATE TABLE IF NOT EXISTS EmployeeDepartments (
    EmpDeptID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    EmployeeID INT NOT NULL REFERENCES Employees(EmployeeID),
    DepartmentID INT NOT NULL REFERENCES Departments(DepartmentID),
    StartDate DATE,
    EndDate DATE
);

-- Creating the EmployeeGrades table
CREATE TABLE IF NOT EXISTS EmployeeGrades (
    EmpGradeID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    EmployeeID INT NOT NULL REFERENCES Employees(EmployeeID),
    GradeID INT NOT NULL REFERENCES Grades(GradeID),
    StartDate DATE,
    EndDate DATE
);

-- Creating the SalaryComponents table
CREATE TABLE IF NOT EXISTS SalaryComponents (
    ComponentID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    ComponentName VARCHAR(50) NOT NULL,
    ComponentType VARCHAR(100) NOT NULL,
    IsTaxable BOOLEAN DEFAULT FALSE
);

-- Creating the EmployeeSalaries table
CREATE TABLE IF NOT EXISTS EmployeeSalaries (
    EmployeeSalaryID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    EmployeeID INT NOT NULL REFERENCES Employees(EmployeeID),
    ComponentID INT NOT NULL REFERENCES SalaryComponents(ComponentID),
    Amount DECIMAL(10,2) NOT NULL
);

-- Creating the Promotions table
CREATE TABLE IF NOT EXISTS Promotions (
    PromotionID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    EmployeeID INT NOT NULL REFERENCES Employees(EmployeeID),
    OldGradeID INT REFERENCES Grades(GradeID),
    NewGradeID INT NOT NULL REFERENCES Grades(GradeID),
    PromotionDate DATE
);

-- Creating the Payslips table
CREATE TABLE IF NOT EXISTS Payslips (
    PayslipID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    EmployeeID INT NOT NULL REFERENCES Employees(EmployeeID),
    Month INT CHECK (Month BETWEEN 1 AND 12),
    Year INT CHECK (Year >= 2000),
    PayslipDate DATE NOT NULL,
    TotalEarnings DECIMAL(10,2),
    TotalDeductions DECIMAL(10,2),
    NetPay DECIMAL(10,2)
);

-- Creating the PayslipComponents table
CREATE TABLE IF NOT EXISTS PayslipComponents (
    PayslipID INT REFERENCES Payslips(PayslipID),
    ComponentID INT REFERENCES SalaryComponents(ComponentID),
    Amount DECIMAL(10,2),
    PRIMARY KEY (PayslipID, ComponentID)
);

-- Creating the DeductionComponents table
CREATE TABLE IF NOT EXISTS DeductionComponents (
    DeductionID INT GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    DeductionName VARCHAR(50),
    Rule VARCHAR(100)
);