using HRSystem.Models;
using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.Repositories
{
    public interface IEmployeeSalaryRepository
    {
        Task<List<EmployeeSalary>> GetEmployeeSalariesAsync();
        Task<EmployeeSalary> GetEmployeeSalaryByIdAsync(int id);
        Task AddEmployeeSalaryAsync(EmployeeSalary employeeSalary);
        Task UpdateEmployeeSalaryAsync(int id, EmployeeSalary employeeSalary);
        Task DeleteEmployeeSalaryAsync(int id);
    }
}
