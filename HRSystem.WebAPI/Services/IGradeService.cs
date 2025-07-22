using HRSystem.WebAPI.Models;

namespace HRSystem.WebAPI.Services
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetAllAsync();
        Task<Grade?> GetByIdAsync(int id);
        Task<Grade> AddAsync(Grade grade);
        Task<Grade> UpdateAsync(Grade grade);
        Task<bool> DeleteAsync(int id);
    }
}