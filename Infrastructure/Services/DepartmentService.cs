using System;
using AutoMapper;
using Infrastructure.Context;
using Domain.Dtos.DepartmentDto;
using Domain.Entities;
using Domain.Wrapper;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;
public class DepartmentService : IDepartmentService
{
    private readonly DataContext context;
    private readonly IMapper mapper;

    public DepartmentService(DataContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }

    public async Task<Response<AddDepartmentDto>> AddDepartment(AddDepartmentDto model)
    {

        try
        {
            var department = new Department()
            {
                Id = model.Id,
                DeparmentName = model.DeparmentName
            };
            var result = await context.Departments.AddAsync(department);
            await context.SaveChangesAsync();
            return new Response<AddDepartmentDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddDepartmentDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<string>> DeleteDepartment(int id)
    {
        try
        {
            var find = await context.Departments.FindAsync(id);
            context.Departments.Remove(find);
            await context.SaveChangesAsync();
            return new Response<string>("Success");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<List<GetDepartmentDto>>> GetDepartment()
    {
        try
        {
            var result = context.Departments.Select(x => new GetDepartmentDto()
            {
                Id = x.Id,
                DeparmentName = x.DeparmentName
            }).ToList();
            return new Response<List<GetDepartmentDto>>(result);
        }
        catch (Exception ex)
        {
            return new Response<List<GetDepartmentDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<GetDepartmentDto>> GetDepartmentById(int id)
    {
        try
        {
            var find = await context.Departments.FindAsync(id);
            var result = new GetDepartmentDto()
            {
                Id = find.Id,
                DeparmentName = find.DeparmentName
            };
            return new Response<GetDepartmentDto>(result);
        }
        catch (Exception ex)
        {
            return new Response<GetDepartmentDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<AddDepartmentDto>> UpdateDepartment(AddDepartmentDto model)
    {
        try
        {
            var find = await context.Departments.FindAsync(model.Id);
            mapper.Map(model, find);
            context.Entry(find).State = EntityState.Modified;
            await context.SaveChangesAsync();
            var response = mapper.Map<AddDepartmentDto>(find);
            return new Response<AddDepartmentDto>(response);
        }
        catch (Exception ex)
        {
            return new Response<AddDepartmentDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
}


