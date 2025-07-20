using HRSystem.Repositories;

public class PayslipService
{
    private readonly IPayslipRepository _repository;
    public PayslipService(IPayslipRepository repository)
    {
        _repository = repository;
    }
    public async Task<Payslip?> GeneratePayslipAsync(PayslipDTO dto) => await _repository.GeneratePayslipAsync(dto);
    public async Task<Payslip?> GetPayslipAsync(int employeeId, int month, int year) => await _repository.GetPayslipAsync(employeeId, month, year);
    public async Task<IEnumerable<Payslip?>> GetAllPayslipsAsync() => await _repository.GetAllPayslipsAsync();
}
