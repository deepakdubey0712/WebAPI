using Microsoft.EntityFrameworkCore;
using HRSystem.WebAPI.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRSystem.WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public class UtcDateTimeConverter : ValueConverter<DateTime, DateTime>
        {
            public UtcDateTimeConverter() : base(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
            { }
        }

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

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(DateTime)))
                {
                    property.SetValueConverter(new UtcDateTimeConverter());
                }
            }

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

