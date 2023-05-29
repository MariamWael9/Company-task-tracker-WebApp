using CompanyWebApp.Data.Services;
using CompanyWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace CompanyWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //ILogger<HomeController> logger
        private readonly IEmployeesService _service;
        private readonly IHttpContextAccessor _contextAccessor;
        public HomeController(IEmployeesService service, IHttpContextAccessor contextAccessor)
        {
            //_logger = logger;
            _service = service;
            _contextAccessor = contextAccessor;
        }
        public IActionResult HomePage(Employee emp)
        {
           
            Employee data = _service.getEmployeeById(emp.Id);
            if (data == null) return View("Not correct Id or/and Password");
            else if (emp.Password == data.Password)
            {
                // Serialize the Employee object to a JSON string
                string employeeJson = JsonConvert.SerializeObject(data);
                _contextAccessor.HttpContext.Session.SetString("LoggedEmployee", employeeJson);               
                    return RedirectToAction("EmpCal", "Tasks");                
            }           
            return View("Not correct Id or/and Password");
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}