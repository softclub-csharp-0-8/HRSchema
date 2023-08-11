using Domain.Dtos.AuthenticationAuthorizationDto;
using Domain.Dtos.EmployeeDto;
using Domain.Dtos.UserDto;
using Infrastructure.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Areas.Admin.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    [HttpGet]
    public  IActionResult Index()
    {
        return View();  
    }
    // [HttpGet]
    // public  IActionResult Login()
    // {
    //     return View(new LoginEmployeeDto());
    // }

    // [HttpPost]
    // public async Task<IActionResult> Login(UserLoginDto model)
    // {
    //    
    //     if (ModelState.IsValid)
    //     {
    //         var result = await _accountService.LoginAsync(model); 
    //         return RedirectToAction( "Index");
    //     }
    //     else
    //     {
    //         return View(); 
    //         
    //     }
    // }
    [HttpGet]
    public  IActionResult Register()
    {
        return View(new RegisterEmployeeDto());
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterDto model)
    {
        if (ModelState.IsValid)
        {
            var result = await _accountService.RegisterAsync(model);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View();  
        }
    }
}