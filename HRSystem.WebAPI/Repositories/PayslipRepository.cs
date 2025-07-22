using HRSystem.WebAPI.Data;
using HRSystem.WebAPI.Repositories;
using HRSystem.WebAPI.Models;
using Microsoft.EntityFrameworkCore;


public class PayslipRepository : IPayslipRepository
    {
        private readonly AppDbContext _context;

        public PayslipRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Payslip?> GeneratePayslipAsync(PayslipDTO dto)
        {
            var payslip = new Payslip
            {
                EmployeeID = dto.EmployeeID,
                Month = dto.Month,
                Year = dto.Year,
                TotalEarnings = dto.TotalEarnings,
                TotalDeductions = dto.TotalDeductions,
                NetPay = dto.NetPay
            };

            _context.Payslips.Add(payslip);
            await _context.SaveChangesAsync();
            return payslip;
        }

        public async Task<Payslip?> GetPayslipAsync(int employeeId, int month, int year)
        {
            return await _context.Payslips
                .FirstOrDefaultAsync(p => p.EmployeeID == employeeId && p.Month == month && p.Year == year);
        }

        public async Task<IEnumerable<Payslip?>> GetAllPayslipsAsync()
        {
            return await _context.Payslips.ToListAsync();
        }
    }
    