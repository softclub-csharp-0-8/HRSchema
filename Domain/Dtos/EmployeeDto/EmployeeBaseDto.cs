namespace Domain.Dtos.EmployeeDto;

public class EmployeeBaseDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber  { get; set; }
    public decimal Salary { get; set; }   
    public int DeparmentId { get; set; }
    public int  JobId { get; set; }
    public DateTime HireDate { get; set; }
    public int ManagerId { get; set; }
}
