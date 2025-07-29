using HRSystem.MVC.Models;
using Microsoft.AspNetCore.Mvc;

public class EmployeeAssignmentsController : Controller
{
    private readonly EmployeeAssignmentApiService _service;

    public EmployeeAssignmentsController(EmployeeAssignmentApiService service)
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
        var assignments = await _service.GetAllAsync();
        return Json(assignments);
    }

    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var assignment = await _service.GetByIdAsync(id);
        return Json(assignment);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeDepartment assignment)
    {
        await _service.CreateAsync(assignment);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] EmployeeDepartment assignment)
    {
        await _service.UpdateAsync(assignment);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}
