namespace Domain.Dtos;

public class EmployeeBaseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber  { get; set; }
    public decimal Salary { get; set; }   
}

public class AddEmployeeDto : EmployeeBaseDto
{
    
} 
public class GetEmployeeDto : EmployeeBaseDto
{
    
}