using CompanyWebApp.Data;
using CompanyWebApp.Data.Services;
using CompanyWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _service;
        public DepartmentsController(IDepartmentService service)
        {
            _service = service; 
        }
        public IActionResult Display()
        {
            var data = _service.getAllDepartments();
            return View(data);
        }
        public IActionResult AddDep()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDep(department dep)
        {
            if(! ModelState.IsValid)
            return View(dep);
            _service.Add(dep);
            return RedirectToAction(nameof(Display));
        }
        public IActionResult EditDep(int depId)
        {
            var data = _service.getDepByID(depId);
            if (data == null) return View("Not Found");
            return View(data);
        }
        [HttpPost]
        public IActionResult EditDep(department dep)
        {
            if (!ModelState.IsValid)
            {
                return View(dep);
            }
            _service.Update(dep);
            return RedirectToAction(nameof(Display));
        }
        public IActionResult DelDep(int DepId)
        {
            var data = _service.getDepByID(DepId);
            if (data == null) return View("Not Found");
            return View(data);
        }
        [HttpPost, ActionName("DeleteDep")]
        public IActionResult DelEmpConfirmed(int DepId)
        {
            try
            {
                // Check if the department ID is associated with any employee
                var hasEmployees = _service.HasEmployees(DepId);
                if (hasEmployees)
                {
                    return View("Error", "You cannot delete this department because it has associated employees.");
                }
                var data = _service.getDepByID(DepId);
                if (data == null)
                {
                    return View("NotFound");
                }
                else
                {
                    _service.Delete(DepId);
                    return RedirectToAction(nameof(Display));
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }


    }
}
