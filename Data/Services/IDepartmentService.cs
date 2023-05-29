using CompanyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Data.Services
{
    public interface IDepartmentService
    {
        List<department> getAllDepartments();
        int getManagerId(int depID);
        department getDepByID(int depID);
        void Add(department dep);
        department Update(department dep);
        void Delete(int depID);
        public bool HasEmployees(int departmentId);
    }
}
