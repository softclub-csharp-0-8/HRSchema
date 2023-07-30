using Microsoft.AspNetCore.Http;

namespace Domain.Dtos.EmployeeDto;

public class AddEmployeeDto : EmployeeBaseDto
{
    public IFormFile? Image { get; set; } = null;

}


     public string FirstName { get; set; }
    public string  LastName { get; set; }
} 
