using Domain.Dtos.AuthenticationAuthorizationDto;
using Domain.Wrapper;

namespace Infrastructure.Services.Role;

public interface IRoleService
{
    Task<Response<List<RoleDto>>> GetRoles();
    Task<Response<AssignRoleDto>> AssignUserRole(AssignRoleDto assign); 
    Task<Response<AssignRoleDto>> RemoveUserRole(AssignRoleDto assign);
}