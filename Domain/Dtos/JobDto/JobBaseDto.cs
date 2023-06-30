namespace Domain.Dtos.JobDto;

public class JobBaseDto
{

    public int Id { get; set; }
    public string Title { get; set; }
    public decimal MinSalary { get; set; }
    public decimal MaxSalary { get; set; }
}
