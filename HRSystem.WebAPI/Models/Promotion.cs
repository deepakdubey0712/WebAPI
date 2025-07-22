using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.WebAPI.Models
{
    [Table("promotions")]
    public class Promotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("promotionid")]
        public int PromotionID { get; set; }

        [Column("employeeid")]
        public int EmployeeID { get; set; }

        [Column("oldgradeid")]
        public int OldGradeID { get; set; }

        [Column("newgradeid")]
        public int NewGradeID { get; set; }

        [Column("promotiondate")]
        public DateTime PromotionDate { get; set; }

    }
}