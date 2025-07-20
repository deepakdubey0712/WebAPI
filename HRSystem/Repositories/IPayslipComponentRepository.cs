using HRSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Repositories
{

    public interface IPayslipComponentRepository
    {
        Task<IEnumerable<PayslipComponent>> GetByPayslipIdAsync(int payslipId);
        Task AddAsync(PayslipComponentDTO dto);
        Task DeleteAsync(int payslipId, int componentId);

    }
}