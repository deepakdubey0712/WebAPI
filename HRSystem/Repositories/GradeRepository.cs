using HRSystem.Data;
using HRSystem.Models;
using HRSystem.Repositories;
using Microsoft.EntityFrameworkCore;

public class GradeRepository : IGradeRepository
{
    private readonly AppDbContext _context;
    public GradeRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Grade>> GetAllAsync() => await _context.Grades.ToListAsync();
    public async Task<Grade?> GetByIdAsync(int id) => await _context.Grades.FindAsync(id);
    public async Task<Grade> AddAsync(Grade grade)
    {
        _context.Grades.Add(grade);
        await _context.SaveChangesAsync();
        return grade;
    }
    public async Task<Grade> UpdateAsync(Grade grade)
    {
        _context.Grades.Update(grade);
        await _context.SaveChangesAsync();
        return grade;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var grade = await _context.Grades.FindAsync(id);
        if (grade == null) return false;
        _context.Grades.Remove(grade);
        await _context.SaveChangesAsync();
        return true;
    }
}
