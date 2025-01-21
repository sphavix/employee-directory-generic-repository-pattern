using EmployeeDirectory.Domain.Dtos;
using EmployeeDirectory.Domain.Models;

namespace EmployeeDirectory.Extensions
{
    public static class DomainToDtoMapper
    {
        public static EmployeeDto ToEmployeeResponse(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                Position = employee.Position
            };
        }

        public static GetEmployeesDto ToEmployeesResponse(this IEnumerable<Employee> employees)
        {
            return new GetEmployeesDto
            {
                Employees = employees.Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Phone = x.Phone,
                    Position = x.Position
                })
            };
        }
    }
}
