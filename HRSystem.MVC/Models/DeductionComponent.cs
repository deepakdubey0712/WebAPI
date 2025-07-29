using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.MVC.Models
{
    [Table("deductioncomponents")]
    public class DeductionComponent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("deductionid")]
        public int DeductionID { get; set; }

        [Column("deductionname")]
        public string? DeductionName { get; set; }

        [Column("rule")]
        public string? Rule { get; set; }
    }
}