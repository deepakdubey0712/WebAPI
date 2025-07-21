using HRSystem.Models;

namespace HRSystem.Services
{
    public interface IPromotionService
    {
        Task<IEnumerable<Promotion>> GetAllAsync();
        Task<Promotion?> GetByIdAsync(int id);
        Task<Promotion> AddAsync(Promotion promotion);
        Task<Promotion> UpdateAsync(Promotion promotion);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Promotion>> GetByEmployeeIdAsync(int employeeId);
    }
}