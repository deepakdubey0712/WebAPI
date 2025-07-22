using HRSystem.WebAPI.Models;

namespace HRSystem.WebAPI.Services
{
    public interface IDeductionComponentService
    {
        Task<IEnumerable<DeductionComponent>> GetAllAsync();
        Task<DeductionComponent?> GetByIdAsync(int id);
        Task<DeductionComponent> AddAsync(DeductionComponent deductionComponent);
        Task<DeductionComponent> UpdateAsync(DeductionComponent deductionComponent);
        Task<bool> DeleteAsync(int id);
    }
}