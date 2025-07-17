using HRSystem.Models;
using HRSystem.Repositories;

namespace HRSystem.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Department>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Department?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<Department> AddAsync(Department department) => await _repository.AddAsync(department);

        public async Task<Department> UpdateAsync(Department department) => await _repository.UpdateAsync(department);

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}