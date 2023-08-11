using AutoMapper;
using Dapper;
using Domain.Dtos.AuthenticationAuthorizationDto;
using Domain.Dtos.EmployeeDto;
using Domain.Dtos.UserDto;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.Account;

public interface IAccountService 
{
    Task<Response<IdentityResult>> RegisterAsync(UserRegisterDto model);
    Task<Response<IdentityUser>> LoginAsync(UserLoginDto model);

    
}