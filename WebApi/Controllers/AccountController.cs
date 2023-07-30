using Domain.Dtos.AuthenticationAuthorizationDto;
using Domain.Wrapper;
using Infrastructure.Services.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AccountController:ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("Register")]
    public async Task<Response<IdentityResult>> Register(RegisterDto model)
    {
        return await _accountService.Register(model); 
    }

    [HttpPost("Login")]
    public async Task<Response<TokenDto>> Login(LoginDto model)
    {
        return await _accountService.Login(model); 
    }
}