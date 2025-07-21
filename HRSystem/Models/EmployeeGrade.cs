using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{
    [Table("employeegrades")]
    public class EmployeeGrade
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("employeegradeid")]
        public int EmployeeGradeID { get; set; }

        [Column("employeeid")]
        public int EmployeeID { get; set; }

        [Column("gradeid")]
        public int GradeID { get; set; }

        [Column("startdate")]
        public DateTime StartDate { get; set; }

        [Column("enddate")]
        public DateTime EndDate { get; set; }

    }
}