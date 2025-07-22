using Microsoft.AspNetCore.Mvc;
using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class GradeManagementController : ControllerBase
{
    private readonly IGradeService _service;

    public GradeManagementController(IGradeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Grade grade)
    {
        var created = await _service.AddAsync(grade);
        return CreatedAtAction(nameof(GetById), new { id = created.GradeID }, created);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var grade = await _service.GetByIdAsync(id);
        return grade == null ? NotFound() : Ok(grade);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Grade grade)
    {
        if (id != grade.GradeID) return BadRequest();
        var updated = await _service.UpdateAsync(grade);
        return Ok(updated);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}