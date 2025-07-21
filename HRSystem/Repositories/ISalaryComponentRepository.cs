using HRSystem.Models;

namespace HRSystem.Repositories
{
    public interface ISalaryComponentRepository
    {
        Task<IEnumerable<SalaryComponent>> GetAllAsync();
        Task<SalaryComponent?> GetByIdAsync(int id);
        Task<SalaryComponent> AddAsync(SalaryComponent salaryComponent);
        Task<SalaryComponent> UpdateAsync(SalaryComponent salaryComponent);
        Task<bool> DeleteAsync(int id);
    }
}