using Domain.Dtos.AuthenticationAuthorizationDto;
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
    [HttpGet]
    public  IActionResult Login()
    {
        return View(new LoginDto());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
       
        if (ModelState.IsValid)
        {
            var result = await _accountService.Login(model);
            return RedirectToAction( "Index");
        }
        else
        {
            return View(); 
            
        }
    }
    [HttpGet]
    public  IActionResult Register()
    {
        return View(new RegisterDto());
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        if (ModelState.IsValid)
        {
            var result = await _accountService.Register(model);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View();  
        }
    }
}