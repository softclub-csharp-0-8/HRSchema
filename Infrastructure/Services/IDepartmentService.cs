using Domain.Dtos.DepartmentDto;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface IDepartmentService
{
    Task<Response<List<GetDepartmentDto>>> GetDepartment();
    Task<Response<GetDepartmentDto>> GetDepartmentById(int id);
    Task<Response<AddDepartmentDto>> AddDepartment(AddDepartmentDto model);
    Task<Response<AddDepartmentDto>> UpdateDepartment(AddDepartmentDto model);
    Task<Response<string>> DeleteDepartment(int id);
}