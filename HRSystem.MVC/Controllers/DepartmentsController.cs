using HRSystem.MVC.Models;
using Microsoft.AspNetCore.Mvc;

public class DepartmentsController : Controller
{
    private readonly DepartmentApiService _service;

    public DepartmentsController(DepartmentApiService service)
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
        var departments = await _service.GetAllAsync();
        return Json(departments);
    }

    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var department = await _service.GetByIdAsync(id);
        return Json(department);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Department department)
    {
        await _service.CreateAsync(department);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Department department)
    {
        await _service.UpdateAsync(department);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}