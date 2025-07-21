using HRSystem.Models;
using HRSystem.Repositories;

namespace HRSystem.Services
{
    public class SalaryComponentService : ISalaryComponentService
    {
        private readonly ISalaryComponentRepository _repository;

        public SalaryComponentService(ISalaryComponentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SalaryComponent>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<SalaryComponent?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<SalaryComponent> AddAsync(SalaryComponent salaryComponent) => await _repository.AddAsync(salaryComponent);

        public async Task<SalaryComponent> UpdateAsync(SalaryComponent salaryComponent) => await _repository.UpdateAsync(salaryComponent);

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
