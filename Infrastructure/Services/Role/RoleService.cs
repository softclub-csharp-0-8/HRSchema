using System.Net;
using AutoMapper;
using Domain.Dtos.AuthenticationAuthorizationDto;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.Role;

public class RoleService : IRoleService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly DataContext _context;
    private readonly IMapper _mapper; 

    public RoleService(IConfiguration configuration, UserManager<IdentityUser> userManager, DataContext context, IMapper mapper )
    {
        _configuration = configuration;
        _userManager = userManager;
        _context = context;
        _mapper = mapper;  
    }

    public async Task<Response<List<RoleDto>>> GetRoles()
    {
        var roles = await _context.Roles.ToListAsync();
        var map = _mapper.Map<List<RoleDto>>(roles);
        return new Response<List<RoleDto>>(map); 
    }
    public async Task<Response<AssignRoleDto>> AssignUserRole(AssignRoleDto assign)
    {
        try
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id.ToUpper() == assign.RoleId.ToUpper());
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.ToUpper() == assign.UserId.ToUpper());
            await _userManager.AddToRoleAsync(user, role.Name);
            return new Response<AssignRoleDto>(assign);  
        }
        catch (Exception ex)
        {
            return new Response<AssignRoleDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<AssignRoleDto>> RemoveUserRole(AssignRoleDto assign)
    {
        try
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id.ToUpper() == assign.RoleId.ToUpper());
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.ToUpper() == assign.UserId.ToUpper());
            await _userManager.RemoveFromRoleAsync(user, role.Name);
            return new Response<AssignRoleDto>(assign);
        }
        catch (Exception ex)
        {
            return new Response<AssignRoleDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });

        }
    }
}