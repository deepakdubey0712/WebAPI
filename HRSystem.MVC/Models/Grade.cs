using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.MVC.Models
{
 [Table("grades")]
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("gradeid")]
        public int GradeID { get; set; }

        [Column("gradename")]
        public char? GradeName { get; set; }

        [Column("promotioncycle")]
        public string? PromotionCycle { get; set; }
    }
}