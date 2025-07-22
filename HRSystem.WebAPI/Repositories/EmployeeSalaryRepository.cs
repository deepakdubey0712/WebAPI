using HRSystem.WebAPI.Data;
using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

public class EmployeeSalaryRepository : IEmployeeSalaryRepository
{
    private readonly AppDbContext _context;

    public EmployeeSalaryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EmployeeSalary>> GetEmployeeSalariesAsync() => await _context.EmployeeSalaries.ToListAsync();
    public async Task AddEmployeeSalaryAsync(EmployeeSalary employeeSalary)
    {
        await _context.EmployeeSalaries.AddAsync(employeeSalary);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeSalaryAsync(int id, EmployeeSalary employeeSalary)
    {
        var existingEmployeeSalary = await GetEmployeeSalaryByIdAsync(id);
        if (existingEmployeeSalary != null)
        {
            _context.Entry(existingEmployeeSalary).CurrentValues.SetValues(employeeSalary);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<EmployeeSalary> GetEmployeeSalaryByIdAsync(int id)
    {
        var employeeSalary = await _context.EmployeeSalaries.FindAsync(id);
        if (employeeSalary == null)
            throw new InvalidOperationException($"EmployeeSalary with id {id} not found.");
        return employeeSalary;
    }

    public async Task DeleteEmployeeSalaryAsync(int id)
    {
        var employeeSalary = await GetEmployeeSalaryByIdAsync(id);
        if (employeeSalary != null)
        {
            _context.EmployeeSalaries.Remove(employeeSalary);
            await _context.SaveChangesAsync();
        }
    }

}