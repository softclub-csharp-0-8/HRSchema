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
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public JobService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
            var result = await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
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
            var find = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(find);
            await _context.SaveChangesAsync();
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
            var result = _context.Jobs.Select(x => new GetJobDto()
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
            var find = await _context.Jobs.FindAsync(id);
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
            var find = await _context.Jobs.FindAsync(model.Id);
            _mapper.Map(model, find);
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var response = _mapper.Map<AddJobDto>(find);
            return new Response<AddJobDto>(response);
        }
        catch (Exception ex)
        {
            return new Response<AddJobDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
}