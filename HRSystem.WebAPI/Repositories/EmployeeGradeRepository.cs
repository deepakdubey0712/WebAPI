using HRSystem.WebAPI.Data;
using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.WebAPI.Repositories
{
    public class EmployeeGradeRepository : IEmployeeGradeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeGradeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeGrade>> GetAllAsync()
        {
            return await _context.EmployeeGrades
        .Include(eg => eg.Employee)
        .Include(eg => eg.Grade)
        .ToListAsync();
        }

        public async Task<EmployeeGrade?> GetByIdAsync(int id) => await _context.EmployeeGrades.FindAsync(id);

        public async Task<EmployeeGrade> AddAsync(EmployeeGrade employeeGrade)
        {
            _context.EmployeeGrades.Add(employeeGrade);
            await _context.SaveChangesAsync();
            return employeeGrade;
        }

        public async Task<EmployeeGrade> UpdateAsync(EmployeeGrade employeeGrade)
        {
            _context.Entry(employeeGrade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return employeeGrade;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employeeGrade = await GetByIdAsync(id);
            if (employeeGrade == null) return false;

            _context.EmployeeGrades.Remove(employeeGrade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}