using HRSystem.MVC.Models;
using Microsoft.AspNetCore.Mvc;

public class EmployeesController : Controller
{
    private readonly EmployeeApiService _service;

    public EmployeesController(EmployeeApiService service)
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
        var employees = await _service.GetAllAsync();
        return Json(employees);
    }

    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var employee = await _service.GetByIdAsync(id);
        return Json(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Employee employee)
    {
        await _service.CreateAsync(employee);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Employee employee)
    {
        await _service.UpdateAsync(employee);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }

    // [HttpDelete]
    // public async Task<IActionResult> DeleteConfirmed(int id)
    // {
    //     await _service.DeleteAsync(id);
    //     return RedirectToAction(nameof(Index));
    // }
}
