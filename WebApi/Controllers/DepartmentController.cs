using Domain.Dtos.DepartmentDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetDepartment()
    {
        var result = await _departmentService.GetDepartment();
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateDepartment(AddDepartmentDto job)
    {
        var result = await _departmentService.UpdateDepartment(job);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
        var result = await _departmentService.GetDepartmentById(id);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddDepartment(AddDepartmentDto model)
    {
        var result = await _departmentService.AddDepartment(model);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var result = await _departmentService.DeleteDepartment(id);
        return StatusCode((int)result.StatusCode, result);
    }
}