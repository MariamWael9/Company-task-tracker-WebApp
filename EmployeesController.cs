using CompanyWebApp.Data;
using CompanyWebApp.Data.Services;
using CompanyWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CompanyWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _service;
        private readonly IHttpContextAccessor contextAccessor;
        public EmployeesController(IEmployeesService service, IHttpContextAccessor contextAccessor)
        {
            _service = service;
            this.contextAccessor = contextAccessor;
        }
        public IActionResult Display()
        {
            var data = _service.getAllEmployees();
            return View(data);
        }
        public IActionResult AddEmp()
        {
            Employee newEmployee = new Employee();
            return View(newEmployee);
        }
        [HttpPost]
        public IActionResult AddEmp(Employee newEmployee)
        {
            if (!ModelState.IsValid)
            {
                return View(newEmployee);
            }

            _service.Add(newEmployee);
            return RedirectToAction(nameof(Display));
        }

        public IActionResult EditEmp(int EmpId)
        {
            var data = _service.getEmployeeById(EmpId);
            if (data == null) return View("Not Found");
            return View(data);
        }
        [HttpPost]
        public IActionResult EditEmp(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View( employee);
            }
            _service.Update(employee);
            return RedirectToAction(nameof(Display));
        }
        public IActionResult DelEmp(int EmpId)
        {
            var data = _service.getEmployeeById(EmpId);
            if (data == null) return View("Not Found");
            return View(data);
        }
        [HttpPost, ActionName("DeleteEmp")]
        public IActionResult DelEmpConfirmed(int EmpId)
        {
            var data = _service.getEmployeeById(EmpId);
            if (data == null) return View("Not Found");
            data.empStatus = Data.enums.EmpStatus.Inactive;
            _service.Update(data);
            return RedirectToAction(nameof(Display));
        }
        public IActionResult DisplayContact()
        {
            string employeeJson = contextAccessor.HttpContext.Session.GetString("LoggedEmployee");
            Employee emp = JsonConvert.DeserializeObject<Employee>(employeeJson);
            var sup = _service.getAllSuperv(emp.Id);
            return View(sup);
        }
    }
}
