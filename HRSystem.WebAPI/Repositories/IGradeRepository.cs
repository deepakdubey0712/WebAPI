using HRSystem.WebAPI.Models;

namespace HRSystem.WebAPI.Repositories
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAllAsync();
        Task<Grade?> GetByIdAsync(int id);
        Task<Grade> AddAsync(Grade grade);
        Task<Grade> UpdateAsync(Grade grade);
        Task<bool> DeleteAsync(int id);
    }
}