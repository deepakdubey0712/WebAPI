using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{
    [Table("employeesalarys")]
    public class EmployeeSalary
    {
        [Key]
        [Column("employeesalaryid")]
        public int EmployeeSalaryID { get; set; }

        [Required]
        [Column("employeeid")]
        public int EmployeeID { get; set; }

        [Required]
        [Column("componentid")]
        public int ComponentID { get; set; }

        [Required]
        [Column("amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        // Navigation properties (optional, if using EF Core relationships)
        public Employee? Employee { get; set; }
        public SalaryComponent? SalaryComponent { get; set; }
    }
}
