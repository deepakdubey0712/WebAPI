using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{
 [Table("employees")]
    public class Grade
    {
        [Column("gradeid")]
        public int GradeID { get; set; }

        [Column("gradename")]
        public char? GradeName { get; set; }

        [Column("promotioncycle")]
        public string? PromotionCycle { get; set; }
    }
}