using Domain.Dtos.AuthenticationAuthorizationDto;
using Domain.Wrapper;
using Infrastructure.Services.Role;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class RoleController:ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService; 
    }

    [HttpGet("GetRoles")]
    public async Task<Response<List<RoleDto>>> GetRoles()
    {
        return await _roleService.GetRoles(); 
    }

    [HttpPost("AssignUserRole")]
    public async Task<Response<AssignRoleDto>> AssignUserRole(AssignRoleDto model)
    {
        return await _roleService.AssignUserRole(model);
    }

    [HttpDelete("RemoveUserRole")]
    public async Task<Response<AssignRoleDto>> RemoveUserRole(AssignRoleDto model)
    {
        return await _roleService.RemoveUserRole(model); 
    }

}