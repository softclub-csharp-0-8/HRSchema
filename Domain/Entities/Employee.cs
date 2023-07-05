using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Employee 
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string FirstName { get; set; }
    [Required,MaxLength(50)]
    public string LastName { get; set; }
    [Required,MaxLength(50)]
    public string Email { get; set; } 
    [Required,MaxLength(50)]
    public string PhoneNumber  { get; set; }
    public decimal Salary { get; set; } 
    public DateTime HireDate { get; set; }
    public int ManagerId { get; set; } 
    public int DepartmentId { get; set; } 
    public Department Department { get; set; } 
    public int JobId { get; set; } 
    public Job Job { get; set; }
    public Level Level { get; set; } 

    public List<JobHistory> JobHistories { get; set; }
    
}

public enum Level
{
    Junior = 1,
    Middle = 2,
    Senior = 3
}