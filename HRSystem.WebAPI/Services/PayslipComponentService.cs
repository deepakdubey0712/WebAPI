using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Repositories;

namespace HRSystem.WebAPI.Services
{
    public class PayslipComponentService : IPayslipComponentService
    {
        private readonly IPayslipComponentRepository _repository;

        public PayslipComponentService(IPayslipComponentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PayslipComponent>> GetByPayslipIdAsync(int payslipId)
        {
            return await _repository.GetByPayslipIdAsync(payslipId);
        }

        public async Task AddAsync(PayslipComponentDTO dto)
        {
            await _repository.AddAsync(dto);
        }

        public async Task DeleteAsync(int payslipId, int componentId)
        {
            await _repository.DeleteAsync(payslipId, componentId);
        }
    }
}