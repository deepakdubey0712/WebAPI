using HRSystem.Data;
using HRSystem.Repositories;
using Microsoft.EntityFrameworkCore;

public class PayslipComponentRepository : IPayslipComponentRepository
{
    private readonly AppDbContext _context;

    public PayslipComponentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PayslipComponent>> GetByPayslipIdAsync(int payslipId)
    {
        return await _context.PayslipComponents
            .Where(pc => pc.PayslipID == payslipId)
            .ToListAsync();
    }

    public async Task AddAsync(PayslipComponentDTO dto)
    {
        var component = new PayslipComponent
        {
            PayslipID = dto.PayslipID,
            ComponentID = dto.ComponentID,
            Amount = dto.Amount
        };

        _context.PayslipComponents.Add(component);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int payslipId, int componentId)
    {
        var component = await _context.PayslipComponents
            .FirstOrDefaultAsync(pc => pc.PayslipID == payslipId && pc.ComponentID == componentId);

        if (component != null)
        {
            _context.PayslipComponents.Remove(component);
            await _context.SaveChangesAsync();
        }
    }
}