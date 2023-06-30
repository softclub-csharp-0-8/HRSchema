using System;
using AutoMapper;
using Infrastructure.Context;
using Domain.Dtos.JobDto;
using Domain.Entities;
using Domain.Wrapper;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobService : IJobService
{
    private readonly DataContext context;
    private readonly IMapper mapper;

    public JobService(DataContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<Response<AddJobDto>> AddJob(AddJobDto model)
    {
        try
        {
            var job = new Job()
            {
                Id = model.Id,
                MaxSalary = model.MaxSalary,
                MinSalary = model.MinSalary,
                Title = model.Title
            };
            var result = await context.Jobs.AddAsync(job);
            await context.SaveChangesAsync();
            return new Response<AddJobDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddJobDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<string>> DeleteJob(int id)
    {
        try
        {
            var find = await context.Jobs.FindAsync(id);
            context.Jobs.Remove(find);
            await context.SaveChangesAsync();
            return new Response<string>("Success");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<List<GetJobDto>>> GetJob()
    {
        try
        {
            var result = context.Jobs.Select(x => new GetJobDto()
            {
                Id = x.Id,
                MaxSalary = x.MaxSalary,
                MinSalary = x.MinSalary,
                Title = x.Title,
            }).ToList();
            return new Response<List<GetJobDto>>(result);
        }
        catch (Exception ex)
        {
            return new Response<List<GetJobDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<GetJobDto>> GetJobById(int id)
    {
        try
        {
            var find = await context.Jobs.FindAsync(id);
            var result = new GetJobDto()
            {
                Id = find.Id,
                MinSalary = find.MinSalary,
                MaxSalary = find.MaxSalary,
                Title = find.Title
            };
            return new Response<GetJobDto>(result);
        }
        catch (Exception ex)
        {
            return new Response<GetJobDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<AddJobDto>> UpdateJob(AddJobDto model)
    {
        try
        {
            var find = await context.Jobs.FindAsync(model.Id);
            mapper.Map(model, find);
            context.Entry(find).State = EntityState.Modified;
            await context.SaveChangesAsync();
            var response = mapper.Map<AddJobDto>(find);
            return new Response<AddJobDto>(response);
        }
        catch (Exception ex)
        {
            return new Response<AddJobDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
}
