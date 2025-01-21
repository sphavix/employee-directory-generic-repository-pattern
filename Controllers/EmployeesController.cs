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
    }
}
