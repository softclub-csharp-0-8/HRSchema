using AutoMapper;
using Domain.Dtos.EmployeeDto;
using Domain.Entities;

namespace Infrastructure.AutoMapperProfiles;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Employee, GetEmployeeDto>().ReverseMap();
        CreateMap<GetEmployeeDto, Employee>().ReverseMap();
        CreateMap<Employee, AddEmployeeDto>().ReverseMap();
        
    }
}