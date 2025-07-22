using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Repositories;

namespace HRSystem.WebAPI.Repositories
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
