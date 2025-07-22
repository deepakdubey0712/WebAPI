using HRSystem.WebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.WebAPI.Models
{
    [Table("payslips")]
    public class Payslip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("payslipid")]
        public int PayslipID { get; set; }

        [Column("employeeid")]
        public int EmployeeID { get; set; }

        [Column("month")]
        public int Month { get; set; }

        [Column("year")]
        public int Year { get; set; }
        [Column("payslipdate")]
        public DateTime PayslipDate { get; set; }
        [Column("totalearnings")]
        public decimal TotalEarnings { get; set; }
        [Column("totaldeductions")]
        public decimal TotalDeductions { get; set; }
        [Column("netpay")]
        public decimal NetPay { get; set; }



        public Employee? Employee { get; set; }
        public ICollection<PayslipComponent>? PayslipComponents { get; set; }

    }
}