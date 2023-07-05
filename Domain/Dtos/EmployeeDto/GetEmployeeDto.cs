namespace Domain.Dtos.EmployeeDto;

public class GetEmployeeDto : EmployeeBaseDto
{
    public string DeparmentName { get; set; }
    public string JobName { get; set; }
    public string FileName { get; set; }
    
}