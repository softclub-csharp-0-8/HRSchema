using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Department  
{ 
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string DeparmentName { get; set; }
    public List<Employee> Employees { get; set; }  
    public List<JobHistory> JobHistories { get; set; }  

}