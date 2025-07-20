using HRSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Services
{
    public interface IEmployeeSalaryService
    {
        Task<List<EmployeeSalary>> GetEmployeeSalariesAsync();
        Task<EmployeeSalary> GetEmployeeSalaryByIdAsync(int id);
        Task AddEmployeeSalaryAsync(EmployeeSalary employeeSalary);
        Task UpdateEmployeeSalaryAsync(int id, EmployeeSalary employeeSalary);
        Task DeleteEmployeeSalaryAsync(int id);
    }
}