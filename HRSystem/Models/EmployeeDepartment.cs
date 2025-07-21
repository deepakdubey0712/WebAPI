using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{

    [Table("employeedepartments")]
    public class EmployeeDepartment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("empdeptid")]
        public int EmpDeptID { get; set; }

        [Column("employeeid")]
        public int EmployeeID { get; set; }

        [Column("departmentid")]
        public int DepartmentID { get; set; }

        [Column("startdate")]
        public DateTime StartDate { get; set; }

        [Column("enddate")]
        public DateTime? EndDate { get; set; }

        // Navigation properties (optional, if using EF Core relationships)
        public Employee? Employee { get; set; }
        public Department? Department { get; set; }
        
    }

}