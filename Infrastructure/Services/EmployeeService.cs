using AutoMapper;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class EmployeeService //:IEmployeeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper; 
    }
}