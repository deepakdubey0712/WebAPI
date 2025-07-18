using HRSystem.Models;
using HRSystem.Repositories;

namespace HRSystem.Services
{
    public class EmployeeDepartmentService : IEmployeeDepartmentService
    {
        private readonly IEmployeeDepartmentRepository _repository;

        public EmployeeDepartmentService(IEmployeeDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeDepartment>> GetEmployeeDepartmentsAsync() => (await _repository.GetAllAsync()).ToList();

        public async Task<EmployeeDepartment> GetEmployeeDepartmentByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddEmployeeDepartmentAsync(EmployeeDepartment employeeDepartment) => await _repository.AddAsync(employeeDepartment);

        public async Task UpdateEmployeeDepartmentAsync(int id, EmployeeDepartment employeeDepartment) => await _repository.UpdateAsync(id, employeeDepartment);

        public async Task DeleteEmployeeDepartmentAsync(int id) => await _repository.DeleteAsync(id);
    }
}