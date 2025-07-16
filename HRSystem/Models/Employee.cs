using System.ComponentModel.DataAnnotations.Schema;
namespace HRSystem.Models
{



    [Table("employees")]

    public class Employee
    {

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
