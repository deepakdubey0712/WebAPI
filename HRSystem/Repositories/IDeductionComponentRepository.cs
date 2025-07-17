using HRSystem.Models;
using HRSystem.Repositories;

namespace HRSystem.Repositories
{
    public interface IDeductionComponentRepository
    {
        Task<IEnumerable<DeductionComponent>> GetAllAsync();
        Task<DeductionComponent?> GetByIdAsync(int id);
        Task<DeductionComponent> AddAsync(DeductionComponent deductionComponent);
        Task<DeductionComponent> UpdateAsync(DeductionComponent deductionComponent);
        Task<bool> DeleteAsync(int id);
    }
}
