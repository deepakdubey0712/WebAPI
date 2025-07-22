using HRSystem.WebAPI.Models;

namespace HRSystem.WebAPI.Repositories
{
    public interface IEmployeeSalaryRepository
    {
        Task<IEnumerable<EmployeeSalary>> GetEmployeeSalariesAsync();
        Task<EmployeeSalary> GetEmployeeSalaryByIdAsync(int id);
        Task AddEmployeeSalaryAsync(EmployeeSalary employeeSalary);
        Task UpdateEmployeeSalaryAsync(int id, EmployeeSalary employeeSalary);
        Task DeleteEmployeeSalaryAsync(int id);
    }
}
