using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Repositories;

namespace HRSystem.WebAPI.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _repository;

        public GradeService(IGradeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Grade>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Grade?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<Grade> AddAsync(Grade grade) => await _repository.AddAsync(grade);

        public async Task<Grade> UpdateAsync(Grade grade) => await _repository.UpdateAsync(grade);

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}