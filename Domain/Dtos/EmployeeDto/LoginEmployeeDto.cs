using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.EmployeeDto;

public class LoginEmployeeDto
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }  
    public bool RememberMe { get; set; }    
    public string? ReturnUrl { get; set; }
    
}