using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Repositories;
namespace HRSystem.WebAPI.Services
{
    public class EmployeeGradeService : IEmployeeGradeService
    {
        private readonly IEmployeeGradeRepository _repository;

        public EmployeeGradeService(IEmployeeGradeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeGrade>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<EmployeeGrade?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<EmployeeGrade> AddAsync(EmployeeGrade employeegrade) => await _repository.AddAsync(employeegrade);

        public async Task<EmployeeGrade> UpdateAsync(EmployeeGrade employeegrade) => await _repository.UpdateAsync(employeegrade);

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}