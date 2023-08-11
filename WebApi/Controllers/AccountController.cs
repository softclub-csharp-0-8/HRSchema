using Domain.Dtos.AuthenticationAuthorizationDto;
using Domain.Dtos.EmployeeDto;
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

}