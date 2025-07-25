using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRSystem.MVC.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("employeeid")]
        public int EmployeeID { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("dob")]
        public DateTime DOB { get; set; }

        [Column("doj")]
        public DateTime DOJ { get; set; }

    }
}
