using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using HRSystem.Models;
public class EmployeeDepartment
{
    public int EmpDeptID { get; set; }
    public int EmployeeID { get; set; }
    public int DepartmentID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    // Navigation properties (optional)
    public Employee? Employee { get; set; }
    public Department? Department { get; set; }
}
