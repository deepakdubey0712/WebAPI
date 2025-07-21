using Microsoft.AspNetCore.Mvc;
using HRSystem.Models;
using HRSystem.Services;

[ApiController]
[Route("api/[controller]")]
public class GradeController : ControllerBase
{
    private readonly IGradeService _service;
    private readonly IEmployeeGradeService _egservice;

    private readonly IPromotionService _promservice;
    public GradeController(IGradeService service, IEmployeeGradeService egservice, IPromotionService promservice)
    {
        _service = service;
        _egservice = egservice;
        _promservice = promservice;
    }

    [HttpGet("grades")]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());


    [HttpPost("grades")]
    public async Task<IActionResult> Create(Grade grade)
    {
        var created = await _service.AddAsync(grade);
        return CreatedAtAction(nameof(GetById), new { id = created.GradeID }, created);
    }


    [HttpGet("employees/{id}/grades")]
    public async Task<IActionResult> GetByEmployeeGradeId(int id)
    {
        var employeegrade = await _egservice.GetByIdAsync(id);
        return employeegrade == null ? NotFound() : Ok(employeegrade);
    }

    [HttpPost("employeegrades")]
    public async Task<IActionResult> Create(EmployeeGrade employeegrade)
    {
        var created = await _egservice.AddAsync(employeegrade);
        return CreatedAtAction(nameof(GetByEmployeeGradeId), new { id = created.EmployeeGradeID }, created);
    }


    [HttpPost("promotions")]
    public async Task<IActionResult> Create(Promotion promotion)
    {
        var createdPromotion = await _promservice.AddAsync(promotion);
        return CreatedAtAction(nameof(GetById), new { id = createdPromotion.PromotionID }, createdPromotion);
    }


    [HttpGet("promotions/{employeeId}")]
    public async Task<IActionResult> GetByEmployeeId(int employeeId)
    {
        var promotions = await _promservice.GetByEmployeeIdAsync(employeeId);
        return promotions == null || !promotions.Any() ? NotFound() : Ok(promotions);
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