using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{
    [Table("salarycomponents")]
    public class SalaryComponent
    {
        [Key]
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("componentid")]
        public int ComponentID { get; set; }

        [Required]
        [Column("componentname")]
        public string ComponentName { get; set; } = string.Empty;

        [Required]
        [Column("componenttype")]
        public string ComponentType { get; set; } = string.Empty;

        [Required]
        [Column("istaxable")]
        public bool IsTaxable { get; set; }

        // Optional: Navigation property for related employee salaries
        public ICollection<EmployeeSalary>? EmployeeSalaries { get; set; }
    }
}
