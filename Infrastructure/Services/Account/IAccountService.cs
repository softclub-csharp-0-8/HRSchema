using AutoMapper;
using Dapper;
using Domain.Dtos.AuthenticationAuthorizationDto;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.Account;

public interface IAccountService
{
    Task<Response<IdentityResult>> Register(RegisterDto model);
    Task<Response<TokenDto>> Login(LoginDto model); 
}