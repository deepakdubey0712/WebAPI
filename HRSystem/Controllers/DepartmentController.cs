using Microsoft.AspNetCore.Mvc;
using HRSystem.Models;
using HRSystem.Services;

[ApiController]
[Route("api/departments")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _service;
    public DepartmentController(IDepartmentService service)
    {
        _service = service;

    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Department department)
    {
        var created = await _service.AddAsync(department);
        return CreatedAtAction(nameof(GetById), new { id = created.DepartmentID }, created);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var department = await _service.GetByIdAsync(id);
        return department == null ? NotFound() : Ok(department);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Department department)
    {
        if (id != department.DepartmentID) return BadRequest();
        var updated = await _service.UpdateAsync(department);
        return Ok(updated);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}