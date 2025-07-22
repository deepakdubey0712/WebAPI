using HRSystem.WebAPI.Models;

namespace HRSystem.WebAPI.Services
{
    public interface IPayslipComponentService
    {
        Task<IEnumerable<PayslipComponent>> GetByPayslipIdAsync(int payslipId);
        Task AddAsync(PayslipComponentDTO dto);
        Task DeleteAsync(int payslipId, int componentId);
    }
}