using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.EmployeeDto;

public class RegisterEmployeeDto
{
    [Required] 
    public string? UserName { get; set; }
    [Required,EmailAddress]
    public string? Email { get; set; }
    [Required,Phone] 
    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "Password us required")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Confirm Password is required")]
    [DataType(DataType.Password)]
    [Compare("Password")] 
    public string? ConfirmPassword { get; set; }
}
