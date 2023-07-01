using Domain.Dtos.JobHistoryDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JobHistoryController : ControllerBase
{
    private readonly IJobHistoryService _jobHistoryService;

    public JobHistoryController(IJobHistoryService jobHistoryService)
    {
        _jobHistoryService = jobHistoryService;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetJobHistory()
    {
        var result = await _jobHistoryService.GetJobHistory();
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateJobHistory(AddJobHistoryDto job)
    {
        var result = await _jobHistoryService.UpdateJobHistory(job);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetJobHistoryById(int id)
    {
        var result = await _jobHistoryService.GetJobHistoryById(id);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddJobHistory(AddJobHistoryDto model)
    {
        var result = await _jobHistoryService.AddJobHistory(model);
        return StatusCode((int)result.StatusCode, result);
    }
    // [HttpDelete("Delete")]
    // public async Task<IActionResult> DeleteJobHistory(int employeeId)
    // {
    //     var result = await _jobHistoryService.DeleteJobHistory(employeeId);
    //     return StatusCode((int)result.StatusCode, result);
    // }
}