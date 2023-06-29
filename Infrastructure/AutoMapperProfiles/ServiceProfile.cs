using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.AutoMapperProfiles;

public class ServiceProfile:Profile
{
    public ServiceProfile()
    {
        CreateMap<Employee, GetEmployeeDto>(); 
    }
}