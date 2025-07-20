using HRSystem.Models;

public class Payslip
{
    public int PayslipID { get; set; }
    public int EmployeeID { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal TotalEarnings { get; set; }
    public decimal TotalDeductions { get; set; }
    public decimal NetPay { get; set; }



    public Employee Employee { get; set; }
    public ICollection<PayslipComponent> PayslipComponents { get; set; }

}
