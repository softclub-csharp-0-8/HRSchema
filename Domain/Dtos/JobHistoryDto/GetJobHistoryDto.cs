namespace Domain.Dtos.JobHistoryDto;

public class GetJobHistoryDto : JobHistoryBaseDto
{
    public string JobName { get; set; }
    public string EmployeeName { get; set; }
    public string DeparmentName { get; set; }
}
