using Microsoft.AspNetCore.Mvc;
using HRSystem.Models;
using HRSystem.Services;

[ApiController]
[Route("api/[controller]")]
public class GradeController : ControllerBase
{
    private readonly IGradeService _service;
    public GradeController(IGradeService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var grade = await _service.GetByIdAsync(id);
        return grade == null ? NotFound() : Ok(grade);
    }
    [HttpPost]
    public async Task<IActionResult> Create(Grade grade)
    {
        var created = await _service.AddAsync(grade);
        return CreatedAtAction(nameof(GetById), new { id = created.GradeID }, created);
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