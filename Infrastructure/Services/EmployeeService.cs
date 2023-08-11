using System.Net;
using AutoMapper;
using Domain.Dtos.EmployeeDto;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetEmployeeDto>>> GetEmployee()
    {
        try
        {
            var result = await _context.Employees.Select(x => new GetEmployeeDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Salary = x.Salary,
                DeparmentId = x.DepartmentId,
                DeparmentName = x.Department.DeparmentName,
                JobId = x.JobId,
                JobName = x.Job.Title,
                HireDate = x.HireDate,
            }).ToListAsync();
            return new Response<List<GetEmployeeDto>>(result);
        }
        catch (Exception ex)
        {
            return new Response<List<GetEmployeeDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { ex.Message });
        }
    }

    public async Task<Response<GetEmployeeDto>> GetEmployeeById(int id)
    {
        try
        {
            var find = await _context.Employees.Include(e => e.Department).Include(e => e.Job)
                .SingleOrDefaultAsync(x => x.Id == id);
            var result = new GetEmployeeDto()
            {
                Id = find.Id,
                FirstName = find.FirstName,
                LastName = find.LastName,
                Email = find.Email,
                PhoneNumber = find.PhoneNumber,
                Salary = find.Salary,
                DeparmentId = find.DepartmentId,
                DeparmentName = find.Department.DeparmentName,
                JobId = find.JobId,
                JobName = find.Job.Title,
                HireDate = find.HireDate,
            };
            return new Response<GetEmployeeDto>(result);
        }
        catch (Exception ex)
        {
            return new Response<GetEmployeeDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<AddEmployeeDto>> AddEmployee(AddEmployeeDto model)
    {
        try
        {
            model.HireDate = DateTime.SpecifyKind(model.HireDate, DateTimeKind.Utc);
            var employee = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                HireDate = model.HireDate,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                JobId = model.JobId,
                DepartmentId = model.DeparmentId,
                Salary = model.Salary
            };
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return new Response<AddEmployeeDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddEmployeeDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<RegisterEmployeeDto>> RegisterEmployee(RegisterEmployeeDto employee)
    {
        try
        {
            var employees = _mapper.Map<Employee>(employee);
            await _context.Employees.AddAsync(employees);
            await _context.SaveChangesAsync();
            return new Response<RegisterEmployeeDto>(employee); 
        }
        catch (Exception e)
        {
            return new Response<RegisterEmployeeDto>(HttpStatusCode.InternalServerError, new List<string>() { e.Message });
        }
    }
    public async Task<Response<string>> DeleteEmployee(int id)
    {
        try
        {
            var find = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<string>("Success");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }


    public async Task<Response<AddEmployeeDto>> UpdateEmployee(AddEmployeeDto model)
    {
        try
        {
            model.HireDate = DateTime.SpecifyKind(model.HireDate, DateTimeKind.Utc);
            var find = await _context.Employees.FindAsync(model.Id);
            _mapper.Map(model, find);
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var response = _mapper.Map<AddEmployeeDto>(find);
            return new Response<AddEmployeeDto>(response);
        }
        catch (Exception ex)
        {
            return new Response<AddEmployeeDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
}