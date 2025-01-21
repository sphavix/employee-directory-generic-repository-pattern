namespace EmployeeDirectory.Domain.Dtos
{
    public class GetEmployeesDto
    {
        public IEnumerable<EmployeeDto> Employees { get; set; } = Enumerable.Empty<EmployeeDto>();
    }
}
