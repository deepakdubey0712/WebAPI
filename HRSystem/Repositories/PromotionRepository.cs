using HRSystem.Data;
using HRSystem.Models;
using HRSystem.Repositories;
using Microsoft.EntityFrameworkCore;


public class PromotionRepository : IPromotionRepository
{
    private readonly AppDbContext _context;

    public PromotionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Promotion>> GetAllAsync() => await _context.Promotions.ToListAsync();

    public async Task<Promotion?> GetByIdAsync(int id) => await _context.Promotions.FindAsync(id);

    public async Task<Promotion> AddAsync(Promotion promotion)
    {
        _context.Promotions.Add(promotion);
        await _context.SaveChangesAsync();
        return promotion;
    }

    public async Task<Promotion> UpdateAsync(Promotion promotion)
    {
        _context.Promotions.Update(promotion);
        await _context.SaveChangesAsync();
        return promotion;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var promotion = await _context.Promotions.FindAsync(id);
        if (promotion == null) return false;

        _context.Promotions.Remove(promotion);
        await _context.SaveChangesAsync();
        return true;
    }

  

}