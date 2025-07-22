using HRSystem.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.WebAPI.Repositories
{

    public interface IPayslipComponentRepository
    {
        Task<IEnumerable<PayslipComponent>> GetByPayslipIdAsync(int payslipId);
        Task AddAsync(PayslipComponentDTO dto);
        Task DeleteAsync(int payslipId, int componentId);

    }
}