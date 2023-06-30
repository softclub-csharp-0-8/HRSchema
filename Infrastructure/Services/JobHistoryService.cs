using Infrastructure.Context;
using Domain.Dtos.JobHistoryDto;
using Domain.Entities;
using System.Net;
using AutoMapper;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobHistoryService : IJobHistoryService
{
    private readonly DataContext context;
    private readonly IMapper mapper;

    public JobHistoryService(DataContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }

    public async Task<Response<AddJobHistoryDto>> AddJobHistory(AddJobHistoryDto model)
    {
        try
        {
            var jobHistory = new JobHistory()
            {
                EmployeeId = model.EmployeeId,
                DepartmentId = model.DeparmentId,
                JobId = model.JobId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
            };
            var result = await context.JobHistories.AddAsync(jobHistory);
            await context.SaveChangesAsync();
            return new Response<AddJobHistoryDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddJobHistoryDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<string>> DeleteJobHistory(int employeeId)
    {
        try
        {
            var find = await context.JobHistories.FindAsync(employeeId);
            context.JobHistories.Remove(find);
            await context.SaveChangesAsync();
            return new Response<string>("Success");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<List<GetJobHistoryDto>>> GetJobHistory()
    {
        try
        {
            var result = context.JobHistories.Select(x => new GetJobHistoryDto()
            {
                EmployeeId = x.EmployeeId,
                JobId = x.JobId,
                DeparmentId = x.DepartmentId,
                JobName = x.Job.Title,
                DeparmentName = x.Department.DeparmentName,
                EmployeeName = x.Employee.FirstName + " " + x.Employee.LastName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
            }).ToList();
            return new Response<List<GetJobHistoryDto>>(result);
        }
        catch (Exception ex)
        {
            return new Response<List<GetJobHistoryDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<GetJobHistoryDto>> GetJobHistoryById(int id)
    {
        try
        {
            var find = await context.JobHistories.FindAsync(id);
            var result = new GetJobHistoryDto()
            {
                EmployeeId = find.EmployeeId,
                JobId = find.JobId,
                DeparmentId = find.DepartmentId,
                JobName = find.Job.Title,
                DeparmentName = find.Department.DeparmentName,
                EmployeeName = find.Employee.FirstName + " " + find.Employee.LastName,
                StartDate = find.StartDate,
                EndDate = find.EndDate,
            };
            return new Response<GetJobHistoryDto>(result);
        }
        catch (Exception ex)
        {
            return new Response<GetJobHistoryDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<AddJobHistoryDto>> UpdateJobHistory(AddJobHistoryDto model)
    {
        try
        {
            var find = await context.JobHistories.FindAsync(model.EmployeeId);
            mapper.Map(model, find);
            context.Entry(find).State = EntityState.Modified;
            await context.SaveChangesAsync();
            var response = mapper.Map<AddJobHistoryDto>(find);
            return new Response<AddJobHistoryDto>(response);
        }
        catch (Exception ex)
        {
            return new Response<AddJobHistoryDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
}
