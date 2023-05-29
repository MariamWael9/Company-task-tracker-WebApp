using CompanyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Data.Services
{
    public class EmployeesService : IEmployeesService

    {
        private readonly AppDbContext _context;
        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }
        public List<Employee> getAllEmployees()
        {
            var employees = _context.Employees.Include(n => n.Dep).Include(q => q.Supervisor).ToList();
            return employees;
        }
        public List<Employee> getAllSuperv(int empId)
        {
            var emp = getEmployeeById(empId);
            var superv = getEmployeeById(emp.Supervisor_Id);
            var man = getEmployeeById(superv.Supervisor_Id);
            List<Employee> supervList = new List<Employee>();
            supervList.Add(superv);
            supervList.Add(man);

            return supervList;
        }
        public Employee getEmployeeById(int? employeeId)
        {
            var res = _context.Employees.FirstOrDefault(n=> n.Id == employeeId);
            return res;
        }

        public Employee Update( Employee NewEmp)
        {
            _context.Update(NewEmp);
            _context.SaveChanges();
            return NewEmp;
        }

    }
}
