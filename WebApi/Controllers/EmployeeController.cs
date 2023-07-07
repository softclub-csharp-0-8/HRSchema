using Domain.Dtos.EmployeeDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;

    }
    [HttpGet("Get")]
    public async Task<IActionResult> GetEmployee()
    {
        var result = await _employeeService.GetEmployee();
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateEmployee(AddEmployeeDto employee)
    {
        var result = await _employeeService.UpdateEmployee(employee);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var result = await _employeeService.GetEmployeeById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    
    [HttpPost("Add")]
    public async Task<IActionResult> AddEmplooyee([FromForm]AddEmployeeDto model)
    {
        var result = await _employeeService.AddEmployee(model);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var result = await _employeeService.DeleteEmployee(id);
        return StatusCode((int)result.StatusCode, result);
    }
}