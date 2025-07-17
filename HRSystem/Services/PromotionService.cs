using HRSystem.Models;
using HRSystem.Repositories;

namespace HRSystem.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _repository;

        public PromotionService(IPromotionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Promotion>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Promotion?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<Promotion> AddAsync(Promotion promotion) => await _repository.AddAsync(promotion);

        public async Task<Promotion> UpdateAsync(Promotion promotion) => await _repository.UpdateAsync(promotion);

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}