using AutoMapper;
using Domain.Dtos.AuthenticationAuthorizationDto;
using Domain.Dtos.Constant;
using Domain.Dtos.DepartmentDto;
using Domain.Dtos.EmployeeDto;
using Domain.Dtos.JobDto;
using Domain.Dtos.JobHistoryDto;
using Domain.Dtos.UserDto;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.AutoMapperProfiles;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Employee, GetEmployeeDto>().ReverseMap();
        CreateMap<GetEmployeeDto, Employee>().ReverseMap();
        CreateMap<Employee, AddEmployeeDto>().ReverseMap();
        CreateMap<Job, AddJobDto>().ReverseMap();
        CreateMap<Department, AddDepartmentDto>().ReverseMap();
        CreateMap<JobHistory, AddJobHistoryDto>().ReverseMap();
        CreateMap<IdentityRole, RoleDto>();
        CreateMap<IdentityUser, RegisterEmployeeDto>().ReverseMap();    
    }
}