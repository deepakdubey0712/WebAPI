using HRSystem.Models;

public class PayslipComponent
{
    public int PayslipID { get; set; }
    public int ComponentID { get; set; }
    public decimal Amount { get; set; }

    public Payslip? Payslip { get; set; }
    public SalaryComponent? Component { get; set; }
}
