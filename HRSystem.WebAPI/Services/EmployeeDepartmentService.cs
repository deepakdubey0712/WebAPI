using HRSystem.WebAPI.Models;

namespace HRSystem.WebAPI.Services
{
    public class EmployeeDepartmentService : IEmployeeDepartmentService
    {
       
   private readonly IEmployeeDepartmentRepository _repository;

        public EmployeeDepartmentService(IEmployeeDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeDepartment>> GetEmployeeDepartmentsAsync()
        {
            return (await _repository.GetAllAsync()).ToList();
        }

        public async Task<EmployeeDepartment> GetEmployeeDepartmentByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Employee Department not found");
        }

        public async Task AddEmployeeDepartmentAsync(EmployeeDepartment employeeDepartment)
        {
            if (employeeDepartment == null) throw new ArgumentNullException(nameof(employeeDepartment));
            await _repository.AddAsync(employeeDepartment);
        }

        public async Task UpdateEmployeeDepartmentAsync(int id, EmployeeDepartment employeeDepartment)
        {
            if (employeeDepartment == null) throw new ArgumentNullException(nameof(employeeDepartment));
            if (id != employeeDepartment.EmpDeptID) throw new ArgumentException("ID mismatch");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException("Employee Department not found");

            await _repository.UpdateAsync(id, employeeDepartment);
        }

        public async Task DeleteEmployeeDepartmentAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException("Employee Department not found");

            await _repository.DeleteAsync(id);
        }
    }
}