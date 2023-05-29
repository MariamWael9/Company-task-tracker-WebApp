using CompanyWebApp.Models;

namespace CompanyWebApp.Data.Services
{
    public interface IEmployeesService
    {
        List<Employee> getAllEmployees();
        List<Employee> getAllSuperv(int empId);
        Employee getEmployeeById(int? employeeId);
        void Add(Employee emp);
        Employee Update( Employee emp);
        //void Delete(int empID);

    }
}
