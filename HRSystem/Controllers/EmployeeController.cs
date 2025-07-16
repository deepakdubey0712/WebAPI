using Microsoft.AspNetCore.Mvc;
using HRSystem.Models;
using HRSystem.Services;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
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
    public async Task<IActionResult> Create(Employee employee)
    {
        var created = await _service.AddAsync(employee);
        return CreatedAtAction(nameof(GetById), new { id = created.EmployeeID }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Employee employee)
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
