using HRSystem.WebAPI.Data;
using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

public class SalaryComponentRepository
    : ISalaryComponentRepository
{
    private readonly AppDbContext _context;

    public SalaryComponentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SalaryComponent>> GetAllAsync()
        => await _context.SalaryComponents.ToListAsync();

    public async Task<SalaryComponent?> GetByIdAsync(int id)
        => await _context.SalaryComponents.FindAsync(id);

    public async Task<SalaryComponent> AddAsync(SalaryComponent salaryComponent)
    {
        _context.SalaryComponents.Add(salaryComponent);
        await _context.SaveChangesAsync();
        return salaryComponent;
    }

    public async Task<SalaryComponent> UpdateAsync(SalaryComponent salaryComponent)
    {
        _context.SalaryComponents.Update(salaryComponent);
        await _context.SaveChangesAsync();
        return salaryComponent;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var salaryComponent = await _context.SalaryComponents.FindAsync(id);
        if (salaryComponent == null) return false;

        _context.SalaryComponents.Remove(salaryComponent);
        await _context.SaveChangesAsync();
        return true;
    }
}
