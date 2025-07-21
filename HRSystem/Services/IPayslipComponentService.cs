using HRSystem.Models;

namespace HRSystem.Services
{
    public interface IPayslipComponentService
    {
        Task<IEnumerable<PayslipComponent>> GetAllPayslipComponentsAsync();
        Task<PayslipComponent> GetPayslipComponentByIdAsync(int id);
        Task<PayslipComponent> CreatePayslipComponentAsync(PayslipComponent payslipComponent);
        Task<PayslipComponent> UpdatePayslipComponentAsync(PayslipComponent payslipComponent);
        Task<bool> DeletePayslipComponentAsync(int id);
    }
}