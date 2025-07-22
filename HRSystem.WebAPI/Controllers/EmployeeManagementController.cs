using Microsoft.AspNetCore.Mvc;
using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Services;

[ApiController]
[Route("api/employees")]
public class EmployeeManagementController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeManagementController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _service.GetByIdAsync(id);
        return employee == null ? NotFound() : Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Employee employee)
    {
        var created = await _service.AddAsync(employee);
        return CreatedAtAction(nameof(GetById), new { id = created.EmployeeID }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
    {
        if (id != employee.EmployeeID) return BadRequest();
        var updated = await _service.UpdateAsync(employee);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
