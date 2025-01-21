using EmployeeDirectory.Domain.Models;
using EmployeeDirectory.Repositories.Abstract;

namespace EmployeeDirectory.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;

        public EmployeeService(IGenericRepository<Employee> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = await _repository.GetAllAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            var employee = await _repository.GetAsync(id);
            return employee;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {

            var result = await _repository.CreateAsync(employee);
            return result;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var result = await _repository.UpdateAsync(employee);
            return result;
        }

        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return result;
        }
    }
}
