using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface IEmployeeService
{
    Task<Response<List<GetEmployeeDto>>> GetAuthors();   
    Task<Response<GetEmployeeDto>> GetAuthorById(int id);
    Task<Response<AddEmployeeDto>> AddAuthor(AddEmployeeDto model); 
    Task<Response<AddEmployeeDto>> UpdateAuthor(AddEmployeeDto model);
    Task<Response<string>>  DeleteAuthor(int id);  
} 
