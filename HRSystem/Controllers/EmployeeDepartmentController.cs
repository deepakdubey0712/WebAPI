using HRSystem.Models;
using HRSystem.Services;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDepartmentController : ControllerBase
    {
        private readonly IEmployeeDepartmentService _service;

        public EmployeeDepartmentController(IEmployeeDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDepartment>>> GetEmployeeDepartments()
        {
            var employeeDepartments = await _service.GetEmployeeDepartmentsAsync();
            return Ok(employeeDepartments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDepartment>> GetEmployeeDepartment(int id)
        {
            var employeeDepartment = await _service.GetEmployeeDepartmentByIdAsync(id);
            if (employeeDepartment == null) return NotFound();
            return Ok(employeeDepartment);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployeeDepartment(EmployeeDepartment employeeDepartment)
        {
            await _service.AddEmployeeDepartmentAsync(employeeDepartment);
            return CreatedAtAction(nameof(GetEmployeeDepartment), new { id = employeeDepartment.EmpDeptID}, employeeDepartment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployeeDepartment(int id, EmployeeDepartment employeeDepartment)
        {
            await _service.UpdateEmployeeDepartmentAsync(id, employeeDepartment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeDepartment(int id)
        {
            await _service.DeleteEmployeeDepartmentAsync(id);
            return NoContent();
        }
    }

   