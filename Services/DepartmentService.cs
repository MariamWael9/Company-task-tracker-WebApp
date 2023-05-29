using CompanyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Data.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;
        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }
        public List<department> getAllDepartments()
        {
            var res = _context.departments.ToList();
            return res;
        }
        public void Add(department dep)
        {
            _context.departments.Add(dep);
            _context.SaveChanges();
        }
        public department getDepByID(int depID)
        {
            var res = _context.departments.FirstOrDefault(n => n.Id == depID);
            return res;
        }
        public department Update(department NewDep)
        {
            _context.Update(NewDep);
            _context.SaveChanges();
            return NewDep;
        }

        public void Delete(int depID)
        {
            var res = _context.departments.FirstOrDefault(n => n.Id == depID);
            _context.departments.Remove(res);
            _context.SaveChanges();
        }

        public bool HasEmployees(int departmentId)
        {
            var employeesCount = _context.Employees.Count(e => e.Dep_Id == departmentId);
            return employeesCount > 0;
        }
        public int getManagerId(int depID)
        {
            throw new NotImplementedException();
        }

    }
}
