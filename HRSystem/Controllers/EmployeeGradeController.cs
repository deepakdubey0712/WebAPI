using Microsoft.AspNetCore.Mvc;
using HRSystem.Models;
using HRSystem.Services;

[ApiController]
[Route("api/[controller]")]
public class EmployeeGradeController : ControllerBase
{
    private readonly IEmployeeGradeService _service;
    public EmployeeGradeController(IEmployeeGradeService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employeegrade = await _service.GetByIdAsync(id);
        return employeegrade == null ? NotFound() : Ok(employeegrade);
    }
    [HttpPost]
    public async Task<IActionResult> Create(EmployeeGrade employeegrade)
    {
        var created = await _service.AddAsync(employeegrade);
        return CreatedAtAction(nameof(GetById), new { id = created.EmployeeGradeID }, created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EmployeeGrade employeegrade)
    {
        if (id != employeegrade.EmployeeGradeID) return BadRequest();
        var updated = await _service.UpdateAsync(employeegrade);
        return Ok(updated);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}