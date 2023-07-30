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
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public DepartmentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<AddDepartmentDto>> AddDepartment(AddDepartmentDto model)
    {
        try
        {
            var department = new Department()
            {
                Id = model.Id,
                DeparmentName = model.DepartmentName
            };
            var result = await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return new Response<AddDepartmentDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddDepartmentDto>(HttpStatusCode.InternalServerError,
                new List<string>() { ex.Message });
        }
    }

    public async Task<Response<string>> DeleteDepartment(int id)
    {
        try
        {
            var find = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(find);
            await _context.SaveChangesAsync();
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
            var result = await _context.Departments.Select(x => new GetDepartmentDto()
            {
                Id = x.Id,
                DepartmentName = x.DeparmentName
            }).ToListAsync();
            return new Response<List<GetDepartmentDto>>(result);
        }
        catch (Exception ex)
        {
            return new Response<List<GetDepartmentDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { ex.Message });
        }
    }

    public async Task<Response<GetDepartmentDto>> GetDepartmentById(int id)
    {
        try
        {
            var find = await _context.Departments.FindAsync(id);
            var result = new GetDepartmentDto()
            {
                Id = find.Id,
                DepartmentName = find.DeparmentName
            };
            return new Response<GetDepartmentDto>(result);
        }
        catch (Exception ex)
        {
            return new Response<GetDepartmentDto>(HttpStatusCode.InternalServerError,
                new List<string>() { ex.Message });
        }
    }

    public async Task<Response<AddDepartmentDto>> UpdateDepartment(AddDepartmentDto model)
    {
        try
        {
            var find = await _context.Departments.FindAsync(model.Id);
            _mapper.Map(model, find);
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var response = _mapper.Map<AddDepartmentDto>(find);
            return new Response<AddDepartmentDto>(response);
        }
        catch (Exception ex)
        {
            return new Response<AddDepartmentDto>(HttpStatusCode.InternalServerError,
                new List<string>() { ex.Message });
        }
    }
}