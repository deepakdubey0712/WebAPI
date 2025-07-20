using HRSystem.Models;

public interface IPayslipService
{
    Task<Payslip?> GeneratePayslipAsync(PayslipDTO dto);
    Task<Payslip?> GetPayslipAsync(int employeeId, int month, int year);
    Task<IEnumerable<Payslip?>> GetAllPayslipsAsync();
}
