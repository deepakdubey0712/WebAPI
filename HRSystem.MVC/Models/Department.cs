using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.MVC.Models
{
    [Table("departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("departmentid")]
        public int DepartmentID { get; set; }

        [Column("departmentname")]
        public string? DepartmentName { get; set; }
    }
}