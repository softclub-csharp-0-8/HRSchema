using Domain.Dtos.EmployeeDto;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface IEmployeeService
{
    Task<Response<List<GetEmployeeDto>>> GetEmployee();
    Task<Response<GetEmployeeDto>> GetEmployeeById(int id);
    Task<Response<AddEmployeeDto>> AddEmployee(AddEmployeeDto model);
    Task<Response<AddEmployeeDto>> UpdateEmployee(AddEmployeeDto model);
    Task<Response<string>> DeleteEmployee(int id);
}
