
using HRSystem.Data;
using HRSystem.Models;
using HRSystem.Repositories;
using Microsoft.EntityFrameworkCore;

public class EmployeeDepartmentRepository : IEmployeeDepartmentRepository
{
    private readonly AppDbContext _context;

    public EmployeeDepartmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EmployeeDepartment>> GetAllAsync() => await _context.EmployeeDepartments.ToListAsync();

    public async Task<EmployeeDepartment> GetByIdAsync(int id)
    {
        var employeeDepartment = await _context.EmployeeDepartments.FindAsync(id);
        if (employeeDepartment == null)
            throw new InvalidOperationException($"EmployeeDepartment with id {id} not found.");
        return employeeDepartment;
    }

    public async Task<EmployeeDepartment> AddAsync(EmployeeDepartment employeeDepartment)
    {
        _context.EmployeeDepartments.Add(employeeDepartment);
        await _context.SaveChangesAsync();
        return employeeDepartment;
    }

    public async Task<EmployeeDepartment> UpdateAsync(EmployeeDepartment employeeDepartment)
    {
        _context.EmployeeDepartments.Update(employeeDepartment);
        await _context.SaveChangesAsync();
        return employeeDepartment;
    }

    public async Task<EmployeeDepartment> UpdateAsync(int id, EmployeeDepartment employeeDepartment)
    {
        var existingEmpDept = await _context.EmployeeDepartments.FindAsync(id);
        if (existingEmpDept == null)
            throw new InvalidOperationException($"EmployeeDepartment with id {id} not found.");
        
        existingEmpDept.EmployeeID = employeeDepartment.EmployeeID;
        existingEmpDept.StartDate = employeeDepartment.StartDate;
        existingEmpDept.EndDate = employeeDepartment.EndDate;
        existingEmpDept.DepartmentID = employeeDepartment.DepartmentID;
       

        await _context.SaveChangesAsync();
        return existingEmpDept;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employeeDepartment = await GetByIdAsync(id);
        if (employeeDepartment == null) return false;

        _context.EmployeeDepartments.Remove(employeeDepartment);
        await _context.SaveChangesAsync();
        return true;
    }

  
}
