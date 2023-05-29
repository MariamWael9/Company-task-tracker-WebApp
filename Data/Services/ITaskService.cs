using CompanyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Data.Services
{
    public interface ITaskService
    {
        List<task> getAllTasksforEmp(int empID);
        List<task> selectMangerOrSuper(int empId);
        List<task> getTeamTasks(int SupervisorID);
        List<task> getDepTasks(int depID);
        public List<Employee> getDepEmps(int depID);
        void Add(task task);
        public task View(int taskID);
        List<comment> getAllcommentsFortask(int taskId);
        task Update(task udTask);
        void Delete(task task);
    }
}
