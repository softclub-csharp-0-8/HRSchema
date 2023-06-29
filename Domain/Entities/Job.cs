using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Job
{
    [Key]
    public int Id { get; set; } 
    [Required,MaxLength(50)]
    public string Title { get; set; }
    public decimal MinSalary { get; set; } 
    public decimal MaxSalary { get; set; }
    public List<Employee> Employees { get; set; } 
    public List<JobHistory> JobHistories { get; set; }
}