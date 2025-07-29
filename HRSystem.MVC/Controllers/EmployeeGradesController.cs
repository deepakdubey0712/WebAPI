using HRSystem.MVC.Models;
using Microsoft.AspNetCore.Mvc;

public class EmployeeGradesController : Controller
{
    private readonly EmployeeGradeApiService _service;

    public EmployeeGradesController(EmployeeGradeApiService service)
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
        var data = await _service.GetAllAsync();
        return Json(data);
    }

    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return Json(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeGrade model)
    {
        var result = await _service.CreateAsync(model);
        return result ? Ok() : BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] EmployeeGrade model)
    {
        var result = await _service.UpdateAsync(model);
        return result ? Ok() : BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result ? Ok() : BadRequest();
    }
}
