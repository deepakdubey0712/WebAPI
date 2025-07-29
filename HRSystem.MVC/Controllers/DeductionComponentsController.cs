using HRSystem.MVC.Models;
using Microsoft.AspNetCore.Mvc;

public class DeductionComponentsController : Controller
{
    private readonly DeductionComponentApiService _service;

    public DeductionComponentsController(DeductionComponentApiService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var deductionComponents = await _service.GetAllAsync();
        return Json(deductionComponents);
    }

    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var deductionComponent = await _service.GetByIdAsync(id);
        return Json(deductionComponent);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DeductionComponent deductionComponent)
    {
        await _service.CreateAsync(deductionComponent);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] DeductionComponent deductionComponent)
    {
        await _service.UpdateAsync(deductionComponent);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }        
}
