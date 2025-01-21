using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Domain.Dtos
{
    public record UpdateEmployeeDto
    (
        int Id,
        [Required] string FirstName,
        [Required] string LastName,
        [Required][EmailAddress] string Email,
        [Required][Phone] string Phone,
        [Required] string Position
    );
}