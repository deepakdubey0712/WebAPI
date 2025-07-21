using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRSystem.Models;
using HRSystem.Services;

[Route("api/[controller]")]
[ApiController]
public class SalaryComponentController : ControllerBase
{
    private readonly ISalaryComponentService _service;
    public SalaryComponentController(ISalaryComponentService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var components = await _service.GetAllAsync();
        return Ok(components);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var salaryComponent = await _service.GetByIdAsync(id);
        return salaryComponent == null ? NotFound() : Ok(salaryComponent);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SalaryComponent salaryComponent)
    {
        if (salaryComponent == null) return BadRequest("Salary component cannot be null.");
        var created = await _service.AddAsync(salaryComponent);
        return CreatedAtAction(nameof(GetById), new { id = created.ComponentID }, created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SalaryComponent salaryComponent)
    {
        if (id != salaryComponent.ComponentID) return BadRequest("ID mismatch.");
        var updated = await _service.UpdateAsync(salaryComponent);
        return Ok(updated);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}