using Domain.Dtos.JobDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }
    [HttpGet("Get")]
    public async Task<IActionResult> GetJob()
    {
        var result = await _jobService.GetJob();
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateJob(AddJobDto job)
    {
        var result = await _jobService.UpdateJob(job);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetJobById(int id)
    {
        var result = await _jobService.GetJobById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> AddJob(AddJobDto model)
    {
        var result = await _jobService.AddJob(model);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteJob(int id)
    {
        var result = await _jobService.DeleteJob(id);
        return StatusCode((int)result.StatusCode, result);
    }
}