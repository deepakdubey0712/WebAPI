using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.WebAPI.Models
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

        private DateTime _startDate;
        private DateTime? _endDate;

        [Column("startdate")]
        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        [Column("enddate")]
        public DateTime? EndDate
        {
            get => _endDate;
            set => _endDate = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : (DateTime?)null;
        }

        // Navigation properties (optional, if using EF Core relationships)
        public Employee? Employee { get; set; }
        public Department? Department { get; set; }
    }
}
