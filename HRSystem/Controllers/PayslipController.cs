using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PayslipController : ControllerBase
{
    private readonly IPayslipService _service;

    public PayslipController(IPayslipService service)
    {
        _service = service;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GeneratePayslip([FromBody] PayslipDTO dto)
    {
        var payslip = await _service.GeneratePayslipAsync(dto);
        if (payslip == null) return BadRequest("Failed to generate payslip.");
        return Ok(payslip);
    }

    [HttpGet("{employeeId}/{month}/{year}")]
    public async Task<IActionResult> GetPayslip(int employeeId, int month, int year)
    {
        var payslip = await _service.GetPayslipAsync(employeeId, month, year);
        if (payslip == null) return NotFound();
        return Ok(payslip);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllPayslips()
    {
        var payslips = await _service.GetAllPayslipsAsync();
        return Ok(payslips);
    }
}
