using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.WebAPI.Services
{
    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        private readonly IEmployeeSalaryRepository _repository;

        public EmployeeSalaryService(IEmployeeSalaryRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<EmployeeSalary>> GetEmployeeSalariesAsync()
        {
            return (await _repository.GetEmployeeSalariesAsync()).ToList();
        }


        public async Task<EmployeeSalary> GetEmployeeSalaryByIdAsync(int id)
        {
            return await _repository.GetEmployeeSalaryByIdAsync(id);
        }

        public async Task AddEmployeeSalaryAsync(EmployeeSalary employeeSalary)
        {
            await _repository.AddEmployeeSalaryAsync(employeeSalary);
        }

        public async Task UpdateEmployeeSalaryAsync(int id, EmployeeSalary employeeSalary)
        {
            await _repository.UpdateEmployeeSalaryAsync(id, employeeSalary);
        }

        public async Task DeleteEmployeeSalaryAsync(int id)
        {
            await _repository.DeleteEmployeeSalaryAsync(id);
        }


    }
}
