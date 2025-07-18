using HRSystem.Models;

public interface IEmployeeDepartmentRepository
{
    Task<IEnumerable<EmployeeDepartment>> GetAllAsync();
    Task<EmployeeDepartment> GetByIdAsync(int id);
    Task<EmployeeDepartment> AddAsync(EmployeeDepartment empDept);
    Task<EmployeeDepartment> UpdateAsync(int id, EmployeeDepartment empDept);
    Task<bool> DeleteAsync(int id);
}