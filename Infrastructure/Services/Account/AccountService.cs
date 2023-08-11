using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Domain.Dtos.AuthenticationAuthorizationDto;
using Domain.Dtos.EmployeeDto;
using Domain.Dtos.UserDto;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens; 

namespace Infrastructure.Services.Account;

public class AccountService : IAccountService 
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountService(IConfiguration configuration, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager )
    {
        _configuration = configuration;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
   public async Task<Response<IdentityResult>> RegisterAsync(UserRegisterDto model)
    {
        try
        {
            var user = new IdentityUser()
            {
                UserName = model.Username,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                 await _userManager.AddToRoleAsync(user, "Manager");
                return new Response<IdentityResult>(result); 
            }
            else
            {
                return new Response<IdentityResult>(HttpStatusCode.BadRequest,
                    result.Errors.Select(e => e.Description).ToList());
            }
        }
        catch (Exception ex)
        {
            return new Response<IdentityResult>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<IdentityUser>> LoginAsync(UserLoginDto model)
    {
        var existing = await _userManager.FindByNameAsync(model.Username);
        if (existing == null)
            return new Response<IdentityUser>(HttpStatusCode.BadRequest, "Login or Password  is incorrect");
        var checkPassword = await _userManager.CheckPasswordAsync(existing, model.Password);
        if (checkPassword == true)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, existing.UserName),
                new Claim(ClaimTypes.Email, existing.Email),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.DateOfBirth, "2005.02.02"),
                new Claim("Tax", "2345654"),
            };
            await _signInManager.SignInWithClaimsAsync(existing, model.RememberMe, claims);
            return new Response<IdentityUser>(existing); //
        }
        else
        {
            return new Response<IdentityUser>(HttpStatusCode.BadRequest, "Login or Password  is incorrect");
        }
    }
}