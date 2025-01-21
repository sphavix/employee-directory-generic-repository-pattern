
using EmployeeDirectory.Domain.Models;

namespace EmployeeDirectory.Persistence.SeedData
{
    public class EmployeeSeeder(EmployeeDbContext _context) : IEmployeeSeeder
    {
        public async Task SeedData()
        {
            if(await _context.Database.CanConnectAsync())
            {
                if (!_context.Employees.Any())
                {
                    var employees = GetEmployees();

                    _context.Employees.AddRange(employees);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employees = [
                new()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@email.com",
                    Phone = "0123456789",
                    Position = "Developer"
                },
                new()
                {
                    FirstName = "Erick",
                    LastName = "Fella",
                    Email = "erick@email.com",
                    Phone = "0123456789",
                    Position = "Developer"
                }
            ];

            return employees;
        }
    }
}
