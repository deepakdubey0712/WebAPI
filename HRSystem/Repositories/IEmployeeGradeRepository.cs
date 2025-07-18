using HRSystem.Models;

namespace HRSystem.Repositories
{
    public interface IEmployeeGradeRepository
    {
        Task<IEnumerable<EmployeeGrade>> GetAllAsync();
        Task<EmployeeGrade?> GetByIdAsync(int id);
        Task<EmployeeGrade> AddAsync(EmployeeGrade employeeGrade);
        Task<EmployeeGrade> UpdateAsync(EmployeeGrade employeeGrade);
        Task<bool> DeleteAsync(int id);
    }
}