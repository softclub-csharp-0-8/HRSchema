using System.Net;
using Domain.Dtos.EmployeeDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    private readonly IEmployeeService employeeService;
    public HomeController(IEmployeeService _employeeService)
    {
        employeeService = _employeeService;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var employees = await employeeService.GetEmployee();
        return View(employees);
    }
    [HttpGet]
     public IActionResult Update(int id)
    {
        var exesting = employeeService.GetEmployeeById(id);
        return View(exesting);
    }
    [HttpPost]
    public IActionResult Update(AddEmployeeDto employee)
    {
        if (ModelState.IsValid)
        {
            
            employeeService.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
        return View(employee);
    }


}