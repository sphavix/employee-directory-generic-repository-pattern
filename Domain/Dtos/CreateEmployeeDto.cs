using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Domain.Dtos
{
    public record CreateEmployeeDto
    (
        [Required] string FirstName,
        [Required] string LastName,
        [Required][EmailAddress] string Email,
        [Required] [Phone]string Phone,
        [Required] string Position
    );
    
    
}
