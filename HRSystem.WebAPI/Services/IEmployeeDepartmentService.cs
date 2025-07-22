using HRSystem.WebAPI.Models;

namespace HRSystem.WebAPI.Services
{
    public interface IEmployeeDepartmentService
    {
        Task<List<EmployeeDepartment>> GetEmployeeDepartmentsAsync();
        Task<EmployeeDepartment> GetEmployeeDepartmentByIdAsync(int id);
        Task AddEmployeeDepartmentAsync(EmployeeDepartment employeeDepartment);
        Task UpdateEmployeeDepartmentAsync(int id, EmployeeDepartment employeeDepartment);
        Task DeleteEmployeeDepartmentAsync(int id);
    }
}