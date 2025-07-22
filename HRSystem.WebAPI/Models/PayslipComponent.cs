using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.WebAPI.Models
{
    [Table("payslipcomponents")]
    public class PayslipComponent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("payslipid")]
        public int PayslipID { get; set; }

        [Column("componentid")]
        public int ComponentID { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }


        public Payslip? Payslip { get; set; }
        public SalaryComponent? Component { get; set; }
    }
}