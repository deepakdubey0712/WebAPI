using HRSystem.WebAPI.Models;

namespace HRSystem.WebAPI.Services
{
    public interface IPromotionService
    {
        Task<IEnumerable<Promotion>> GetAllAsync();
        Task<Promotion?> GetByIdAsync(int id);
        Task<Promotion> AddAsync(Promotion promotion);
        Task<Promotion> UpdateAsync(Promotion promotion);
        Task<bool> DeleteAsync(int id);

      
    }
}