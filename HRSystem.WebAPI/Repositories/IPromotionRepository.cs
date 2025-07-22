using HRSystem.WebAPI.Models;

namespace HRSystem.WebAPI.Repositories
{
    public interface IPromotionRepository
    {
        Task<IEnumerable<Promotion>> GetAllAsync();
        Task<Promotion?> GetByIdAsync(int id);
        Task<Promotion> AddAsync(Promotion promotion);
        Task<Promotion> UpdateAsync(Promotion promotion);
        Task<bool> DeleteAsync(int id);

   

    }
}