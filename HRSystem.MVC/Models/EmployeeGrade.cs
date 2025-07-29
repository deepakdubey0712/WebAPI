using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.MVC.Models
{
    [Table("employeegrades")]
    public class EmployeeGrade
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("empgradeid")]
        public int EmployeeGradeID { get; set; }

        [Column("employeeid")]
        public int EmployeeID { get; set; }

        [Column("gradeid")]
        public int GradeID { get; set; }

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
        public Grade? Grade { get; set; }

    }
}