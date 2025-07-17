using HRSystem.Data;
using HRSystem.Models;
using HRSystem.Repositories;
using Microsoft.EntityFrameworkCore;

public class DeductionComponentRepository : IDeductionComponentRepository
{
    private readonly AppDbContext _context;

    public DeductionComponentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DeductionComponent>> GetAllAsync() => await _context.DeductionComponents.ToListAsync();

    public async Task<DeductionComponent?> GetByIdAsync(int id) => await _context.DeductionComponents.FindAsync(id);

    public async Task<DeductionComponent> AddAsync(DeductionComponent deductionComponent)
    {
        _context.DeductionComponents.Add(deductionComponent);
        await _context.SaveChangesAsync();
        return deductionComponent;
    }

    public async Task<DeductionComponent> UpdateAsync(DeductionComponent deductionComponent)
    {
        _context.DeductionComponents.Update(deductionComponent);
        await _context.SaveChangesAsync();
        return deductionComponent;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deductionComponent = await GetByIdAsync(id);
        if (deductionComponent == null) return false;

        _context.DeductionComponents.Remove(deductionComponent);
        await _context.SaveChangesAsync();
        return true;
    }
}
