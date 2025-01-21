using EmployeeDirectory.Domain.Dtos;
using EmployeeDirectory.Domain.Models;

namespace EmployeeDirectory.Extensions
{
    public static class DtoToDomainMapper
    {
        public static Employee CreateResponse(this CreateEmployeeDto employeeDto)
        {
            return new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone,
                Position = employeeDto.Position
            };
        }

        public static Employee UpdateResponse(this UpdateEmployeeDto employeeDto)
        {
            return new Employee
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone,
                Position = employeeDto.Position
            };
        }


    }
}
