using HRSystem.Models;

namespace HRSystem.Services
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