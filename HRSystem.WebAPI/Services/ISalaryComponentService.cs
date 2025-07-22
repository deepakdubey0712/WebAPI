using HRSystem.WebAPI.Models;

namespace HRSystem.WebAPI.Services
{
    public interface ISalaryComponentService
    {
        Task<IEnumerable<SalaryComponent>> GetAllAsync();
        Task<SalaryComponent?> GetByIdAsync(int id);
        Task<SalaryComponent> AddAsync(SalaryComponent salaryComponent);
        Task<SalaryComponent> UpdateAsync(SalaryComponent salaryComponent);
        Task<bool> DeleteAsync(int id);
    }
}