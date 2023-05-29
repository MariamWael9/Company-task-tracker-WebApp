using CompanyWebApp.Data;
using CompanyWebApp.Data.Services;
using CompanyWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Security.Claims;

namespace CompanyWebApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IHttpContextAccessor contextAccessor;
        public TasksController(ITaskService taskService, IHttpContextAccessor contextAccessor)
        {
            _taskService = taskService;
            this.contextAccessor = contextAccessor;
        }
        public IActionResult Display()
        {
            string employeeJson = contextAccessor.HttpContext.Session.GetString("LoggedEmployee");
            Employee emp = JsonConvert.DeserializeObject<Employee>(employeeJson);
            var data = _taskService.selectMangerOrSuper(emp.Id);
            return View(data);
        }
        public IActionResult DisplayForEmp()
        {
            string employeeJson = contextAccessor.HttpContext.Session.GetString("LoggedEmployee");
            Employee emp = JsonConvert.DeserializeObject<Employee>(employeeJson);
            List<task> data = _taskService.getAllTasksforEmp(emp.Id);
            var allEmpTasks = new object[] { emp, data };
            return View(allEmpTasks);
        }
        public IActionResult EmpCal()
        {
            Employee emp = new Employee();
            string employeeJson = contextAccessor.HttpContext.Session.GetString("LoggedEmployee");
            emp = JsonConvert.DeserializeObject<Employee>(employeeJson);
            return View(emp);
        }

        public IActionResult ViewTask(int taskId) 
        {
            string employeeJson = contextAccessor.HttpContext.Session.GetString("LoggedEmployee");
            Employee emp = JsonConvert.DeserializeObject<Employee>(employeeJson);
            task taskData = _taskService.View(taskId);
            var allComments = _taskService.getAllcommentsFortask(taskId);
            comment com = new comment();
            var updatedInfo = new object[] { emp, taskData , allComments , com};
            return View(updatedInfo);
        }
        public IActionResult EditTask(int taskId)
        {
            string employeeJson = contextAccessor.HttpContext.Session.GetString("LoggedEmployee");
            Employee emp = JsonConvert.DeserializeObject<Employee>(employeeJson);
            task taskData = _taskService.View(taskId);
            var updatedInfo = new object[] { emp, taskData};
            return View(updatedInfo);
        }
        [HttpPost]
        public IActionResult EditTask(task updatesTask)
        {
            if (!ModelState.IsValid)
            {
                return View(updatesTask);
            }
            _taskService.Update(updatesTask);
            return RedirectToAction("DisplayForEmp");
        }
        [HttpPost]
        public IActionResult DelTask(int taskId)
        {
            task taskData = _taskService.View(taskId);
            taskData.taskStatues = Data.enums.TskStatus.Cancelled;
            _taskService.Update(taskData);
            return RedirectToAction("DisplayForEmp" , "Tasks");
        }

        public IActionResult AddTask()
        {
            string employeeJson = contextAccessor.HttpContext.Session.GetString("LoggedEmployee");
            Employee emp = JsonConvert.DeserializeObject<Employee>(employeeJson);
            task newTask = new task();
            var updatedInfo = new object[] { emp, newTask };
            return View(updatedInfo);
        }
        [HttpPost]
        public IActionResult AddTask(task newTask)
        {
            if (!ModelState.IsValid)
            {
                return View(newTask);
            }
            _taskService.Add(newTask);
            return RedirectToAction("DisplayForEmp");
        }

        //Manager tasks controlling 
        public IActionResult MngAssignTask()
        {
            string employeeJson = contextAccessor.HttpContext.Session.GetString("LoggedEmployee");
            Employee emp = JsonConvert.DeserializeObject<Employee>(employeeJson);
            List<Employee> empList = _taskService.getDepEmps(emp.Dep_Id);
            task newTask = new task();
            var updatedInfo = new object[] { empList, newTask };
            return View(updatedInfo);
        }
        [HttpPost]
        public IActionResult MngAssignTask(task newTask)
        {
            if (!ModelState.IsValid)
            {
                return View(newTask);
            }

            _taskService.Add(newTask);
            return RedirectToAction("Display");
        }

        public IActionResult MngEditTask(int taskId)
        {
            string employeeJson = contextAccessor.HttpContext.Session.GetString("LoggedEmployee");
            Employee emp = JsonConvert.DeserializeObject<Employee>(employeeJson);
            List<Employee> empList = _taskService.getDepEmps(emp.Dep_Id);
            task taskData = _taskService.View(taskId);
            var updatedInfo = new object[] { empList, taskData };
            return View(updatedInfo);
        }
        [HttpPost]
        public IActionResult MngEditTask(task updatesTask)
        {
            if (!ModelState.IsValid)
            {
                return View(updatesTask);
            }
           // task taskData = _taskService.View(taskId);
            _taskService.Update(updatesTask);
            return RedirectToAction("Display");
        }
        public IActionResult MngDelTask(int taskId)
        {
            task taskData = _taskService.View(taskId);
            taskData.taskStatues = Data.enums.TskStatus.Cancelled;
            _taskService.Update(taskData);
            return RedirectToAction("Display", "Tasks");
        }
    }
}
