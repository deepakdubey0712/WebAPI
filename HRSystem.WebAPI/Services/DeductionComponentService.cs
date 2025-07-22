using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Repositories;

namespace HRSystem.WebAPI.Services
{
    public class DeductionComponentService : IDeductionComponentService
    {
        private readonly IDeductionComponentRepository _repository;

        public DeductionComponentService(IDeductionComponentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DeductionComponent>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<DeductionComponent?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<DeductionComponent> AddAsync(DeductionComponent deductionComponent) => await _repository.AddAsync(deductionComponent);

        public async Task<DeductionComponent> UpdateAsync(DeductionComponent deductionComponent) => await _repository.UpdateAsync(deductionComponent);

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}