using Microsoft.AspNetCore.Mvc;
using HRSystem.WebAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class PayslipBreakdownController : ControllerBase
{
    private readonly PayslipComponentService _service;

    public PayslipBreakdownController(PayslipComponentService service)
    {
        _service = service;
    }

    [HttpGet("{payslipId}")]
    public async Task<IActionResult> GetByPayslipId(int payslipId)
    {
        var components = await _service.GetByPayslipIdAsync(payslipId);
        return Ok(components);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] PayslipComponentDTO dto)
    {
        await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetByPayslipId), new { payslipId = dto.PayslipID }, dto);
    }

    [HttpDelete("{payslipId}/{componentId}")]
    public async Task<IActionResult> Delete(int payslipId, int componentId)
    {
        await _service.DeleteAsync(payslipId, componentId);
        return NoContent();
    }
}