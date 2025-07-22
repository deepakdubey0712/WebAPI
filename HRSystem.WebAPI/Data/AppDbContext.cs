using Microsoft.EntityFrameworkCore;
using HRSystem.WebAPI.Models;

namespace HRSystem.WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<DeductionComponent> DeductionComponents { get; set; }

        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<EmployeeGrade> EmployeeGrades { get; set; }
        public DbSet<SalaryComponent> SalaryComponents { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<Payslip> Payslips { get; set; }
        public DbSet<PayslipComponent> PayslipComponents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employees", "public");
            modelBuilder.Entity<DeductionComponent>().ToTable("deductioncomponents", "public");
            modelBuilder.Entity<EmployeeDepartment>().ToTable("employeedepartments", "public");
            modelBuilder.Entity<Department>().ToTable("departments", "public");
            modelBuilder.Entity<Grade>().ToTable("grades", "public");
            modelBuilder.Entity<Promotion>().ToTable("promotions", "public");
            modelBuilder.Entity<EmployeeGrade>().ToTable("employeegrades", "public");
            modelBuilder.Entity<SalaryComponent>().ToTable("salarycomponents", "public");
            modelBuilder.Entity<EmployeeSalary>().ToTable("employeesalaries", "public");
            modelBuilder.Entity<Payslip>().ToTable("payslips", "public");
            modelBuilder.Entity<PayslipComponent>().ToTable("payslipcomponents", "public");
        }

    }
}

