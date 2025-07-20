using HRSystem.Models;
using HRSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly IEmployeeSalaryService _service;

        public EmployeeSalaryController(IEmployeeSalaryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var salaries = await _service.GetEmployeeSalariesAsync();
            return Ok(salaries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var salary = await _service.GetEmployeeSalaryByIdAsync(id);
            return salary == null ? NotFound() : Ok(salary);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeSalary employeeSalary)
        {
            await _service.AddEmployeeSalaryAsync(employeeSalary);
            return CreatedAtAction(nameof(GetById), new { id = employeeSalary.EmployeeSalaryID }, employeeSalary);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeSalary employeeSalary)
        {
            if (id != employeeSalary.EmployeeSalaryID)
                return BadRequest("EmployeeSalary ID mismatch.");
            await _service.UpdateEmployeeSalaryAsync(id, employeeSalary);
            return NoContent();
        }   
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteEmployeeSalaryAsync(id);
            return NoContent();
        }


    }
}

  
        