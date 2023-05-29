using CompanyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Data.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context) 
        {
            _context = context;
        }
        public void Add(task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
        public task View (int taskID)
        {
            var data = _context.tasks.FirstOrDefault(n => n.Id == taskID);
            return data;
        }
        public List<comment> getAllcommentsFortask(int taskId)
        {
            var data = _context.comments.Where(k => k.Task_Id == taskId).Include(n => n.employee).ToList();
            return data;
        }
        public void Delete(task task)
        {
            _context.tasks.Remove(task);
            _context.SaveChanges();
        }
        public task Update(task updateTask)
        {
            _context.Update(updateTask);
            _context.SaveChanges();
            return updateTask;
        } 

        public List<task> getAllTasksforEmp(int empID)
        {
            var data = _context.tasks.Where(n => n.Employee_Id == empID).ToList();
            return data;
        }
        public List<task> selectMangerOrSuper(int empId)
        {
            var emp = _context.Employees.FirstOrDefault(n=>n.Id == empId);
            if (emp.empRole == enums.EmpRole.Manager)
            {
                var res = _context.departments.FirstOrDefault(n => n.Manager_Id == empId);
                return getDepTasks(res.Id);    
            }
            
                return getTeamTasks(empId);
            
        }
        public List<task> getDepTasks(int depID)
        {
            var data = _context.tasks.Where(n => n.employee.Dep_Id == depID).Include(k => k.employee).ToList();
            return data;
        }
        public List<Employee> getDepEmps(int depID)
        {
            var data = _context.Employees.Where(n=>n.Dep_Id == depID).ToList();
            return data;
        }

        public List<task> getTeamTasks(int SupervisorID)
        {
            var data = _context.tasks.Where(n => n.employee.Supervisor_Id == SupervisorID).Include(k=>k.employee).ToList();
            return data;
        }

        
    }
}
