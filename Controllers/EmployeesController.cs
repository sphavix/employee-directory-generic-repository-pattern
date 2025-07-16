using EmployeeDirectory.Domain.Dtos;
using EmployeeDirectory.Extensions;
using EmployeeDirectory.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("/employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _service.GetEmployeesAsync();

            var response = employees.ToEmployeesResponse();

            return Ok(response);
        }

        [HttpGet]
        [Route("/employees/{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _service.GetEmployeeAsync(id);

            if(employee is null )
            {
                return NotFound();
            }

            var response = employee.ToEmployeeResponse();

            return Ok(response);
        }

        [HttpPost]
        [Route("/employees")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto request)
        {
            var employee = request.ToEmployeeDto();

            await _service.CreateEmployeeAsync(employee);

            var response = employee.ToEmployeeResponse();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, response);
        }

        [HttpPut]
        [Route("/employees/{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeDto request)
        {
            var existingEmployee = await _service.GetEmployeeAsync(request.Id);

            if(existingEmployee is null)
            {
                return NotFound();
            }

            var employee = request.ToEmployeeDto();

            await _service.UpdateEmployeeAsync(existingEmployee);

            var response = employee.ToEmployeeResponse();

            return Ok(response);
        }

        [HttpDelete]
        [Route("/employees/{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _service.DeleteEmployeeAsync(id);

            return NoContent();
        }
    }
}
