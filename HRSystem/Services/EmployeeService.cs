using HRSystem.Models;
using HRSystem.Repositories;

namespace HRSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Employee?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<Employee> AddAsync(Employee employee) => await _repository.AddAsync(employee);

        public async Task<Employee> UpdateAsync(Employee employee) => await _repository.UpdateAsync(employee);

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
