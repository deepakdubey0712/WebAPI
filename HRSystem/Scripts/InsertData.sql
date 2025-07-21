INSERT INTO Departments (DepartmentName) VALUES
('HR'), ('Finance'), ('Engineering'), ('Marketing'), ('Sales');

INSERT INTO Grades (GradeName, PromotionCycle) VALUES
('A', 'Annual'), ('B', 'Bi-Annual'), ('C', 'Quarterly');

INSERT INTO Employees (Name, DOB, DOJ) VALUES
('Alice Sharma', '1990-05-12', '2020-01-15'),
('Bob Mehta', '1985-08-23', '2018-03-10'),
('Charlie Patel', '1992-11-30', '2021-07-01'),
('Diana Roy', '1988-02-14', '2019-09-20'),
('Ethan Desai', '1995-06-05', '2022-04-25');

INSERT INTO EmployeeDepartments (EmployeeID, DepartmentID, StartDate) VALUES
(101, 1, '2020-01-15'),
(102, 2, '2018-03-10'),
(103, 3, '2021-07-01'),
(104, 4, '2019-09-20'),
(105, 5, '2022-04-25');

INSERT INTO EmployeeGrades (EmployeeID, GradeID, StartDate) VALUES
(101, 1, '2020-01-15'),
(102, 2, '2018-03-10'),
(103, 3, '2021-07-01'),
(104, 2, '2019-09-20'),
(105, 1, '2022-04-25');

INSERT INTO SalaryComponents (ComponentName, IsTaxable) VALUES
('Basic Pay', TRUE),
('HRA', TRUE),
('Transport Allowance', FALSE),
('Medical Allowance', FALSE),
('Bonus', TRUE);

INSERT INTO EmployeeSalaries (EmployeeID, ComponentID, Amount) VALUES
(101, 1, 30000.00),
(101, 2, 10000.00),
(102, 1, 35000.00),
(103, 3, 5000.00),
(104, 4, 3000.00);

INSERT INTO Promotions (EmployeeID, OldGradeID, NewGradeID, PromotionDate) VALUES
(101, 2, 1, '2021-01-01'),
(102, 3, 2, '2019-06-01'),
(103, NULL, 3, '2021-07-01'),
(104, 3, 2, '2020-09-20'),
(105, NULL, 1, '2022-04-25');

INSERT INTO Payslips (EmployeeID, Month, Year, PayslipDate, TotalEarnings, TotalDeductions, NetPay) VALUES
(101, 6, 2025, '2025-06-30', 40000.00, 5000.00, 35000.00),
(102, 6, 2025, '2025-06-30', 45000.00, 7000.00, 38000.00),
(103, 6, 2025, '2025-06-30', 30000.00, 3000.00, 27000.00),
(104, 6, 2025, '2025-06-30', 32000.00, 4000.00, 28000.00),
(105, 6, 2025, '2025-06-30', 28000.00, 2000.00, 26000.00);

INSERT INTO PayslipComponents (PayslipID, ComponentID, Amount) VALUES
(1, 1, 30000.00),
(1, 2, 10000.00),
(2, 1, 35000.00),
(2, 2, 10000.00),
(3, 3, 5000.00);

INSERT INTO DeductionComponents (DeductionName, Rule) VALUES
('PF', '12% of Basic'),
('Professional Tax', 'Fixed 200'),
('Income Tax', 'As per slab'),
('ESI', '1.75% of Gross'),
('Loan EMI', 'Fixed 1000');