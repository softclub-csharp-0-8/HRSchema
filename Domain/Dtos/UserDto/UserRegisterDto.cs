using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.UserDto;

public class UserRegisterDto
{
    [Required(ErrorMessage = "Please fill up username")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Please fill up email address")]
    [EmailAddress]
    public string Email { get; set; } 
 
    [Required(ErrorMessage = "Please fill up password")]
    public string Password { get; set; } 
        
    [Compare("Password",ErrorMessage ="your password does not match")]
    public string ConfirmPassword { get; set; }
}