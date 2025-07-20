using HRSystem.Models;

namespace HRSystem.Repositories
{
    public interface IPayslipRepository
    {

        Task<Payslip?> GeneratePayslipAsync(PayslipDTO dto);
        Task<Payslip?> GetPayslipAsync(int employeeId, int month, int year);
        Task<IEnumerable<Payslip?>> GetAllPayslipsAsync();

    }
}
