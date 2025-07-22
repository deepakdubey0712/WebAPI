using HRSystem.WebAPI.Data;
using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _context;
    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Department>> GetAllAsync() => await _context.Departments.ToListAsync();
    public async Task<Department?> GetByIdAsync(int id) => await _context.Departments.FindAsync(id);
    public async Task<Department> AddAsync(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return department;
    }
    public async Task<Department> UpdateAsync(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
        return department;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department == null) return false;
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        return true;
    }
}