using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRSystem.WebAPI.Models;
using HRSystem.WebAPI.Services;


[Route("api/[controller]")]
[ApiController]
public class PromotionController : ControllerBase
{
    private readonly IPromotionService _service;

    public PromotionController(IPromotionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var promotion = await _service.GetByIdAsync(id);
        return promotion == null ? NotFound() : Ok(promotion);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Promotion promotion)
    {
        var createdPromotion = await _service.AddAsync(promotion);
        return CreatedAtAction(nameof(GetById), new { id = createdPromotion.PromotionID }, createdPromotion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Promotion promotion)
    {
        if (id != promotion.PromotionID) return BadRequest();
        var updatedPromotion = await _service.UpdateAsync(promotion);
        return Ok(updatedPromotion);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }

  

}
