using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{
    [Table("promotions")]
    public class Promotion
    {
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