using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.WebAPI.Models
{
    [Table("employeesalaries")]
    public class EmployeeSalary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
