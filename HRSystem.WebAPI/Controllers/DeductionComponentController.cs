using Microsoft.AspNetCore.Mvc;
using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class DeductionComponentController : ControllerBase
{
    private readonly IDeductionComponentService _service;

    public DeductionComponentController(IDeductionComponentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var component = await _service.GetByIdAsync(id);
        return component == null ? NotFound() : Ok(component);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DeductionComponent deductionComponent)
    {
        var created = await _service.AddAsync(deductionComponent);
        return CreatedAtAction(nameof(GetById), new { id = created.DeductionID }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DeductionComponent deductionComponent)
    {
        if (id != deductionComponent.DeductionID) return BadRequest();
        var updated = await _service.UpdateAsync(deductionComponent);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}            