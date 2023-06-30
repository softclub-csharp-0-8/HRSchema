namespace Domain.Dtos.JobHistoryDto;

public class JobHistoryBaseDto
{
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int JobId { get; set; }
    public int DeparmentId { get; set; }
}
