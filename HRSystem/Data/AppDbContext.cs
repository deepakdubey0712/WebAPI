using Microsoft.EntityFrameworkCore;
using HRSystem.Models;

namespace HRSystem.Data
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employees", "public");
            modelBuilder.Entity<DeductionComponent>().ToTable("deduction_components", "public");
            modelBuilder.Entity<EmployeeDepartment>().ToTable("employee_departments", "public");
            modelBuilder.Entity<Department>().ToTable("departments", "public");
            modelBuilder.Entity<Grade>().ToTable("grades", "public");
            modelBuilder.Entity<Promotion>().ToTable("promotions", "public");
            modelBuilder.Entity<EmployeeGrade>().ToTable("employeegrades", "public");
        }

        

    }
}

