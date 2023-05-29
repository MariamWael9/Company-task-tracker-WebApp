using CompanyWebApp.Data.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace CompanyWebApp.Models
{
    [Serializable]
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = " ID is required")]public int Id { get; set; }
        [Required(ErrorMessage = " Name is required")] public string Name { get; set; }
        [Required(ErrorMessage = " Phone number is required")] public string Phone { get; set; }
        [Required(ErrorMessage = " Password is required")] public string Password { get; set; }
        [Required(ErrorMessage = " Title is required")] public string Title { get; set; }
        [Required(ErrorMessage = " Email is required")] public string Email { get; set; }
        [Required(ErrorMessage = " Employee status is required")] public EmpStatus empStatus { get; set; }
        [Required(ErrorMessage = " Employee status is required")] public EmpRole empRole { get; set; }

        //supervision relationship with employees
        public List<Employee>? Employees { get; set;}

        //relationship with comments
        public List<comment>? Comments { get; set; }

        //relation of employee to his supervisor
        public int? Supervisor_Id { get; set; }
        [ForeignKey("Supervisor_Id")]
        public Employee? Supervisor { get; set; }

        //employee has a task relationship
        public List<task>? Tasks { get; set; }

        //relation of emp with his dep
        [Required(ErrorMessage = " Department ID is required")]
        public int Dep_Id { get; set; }
        [ForeignKey("Dep_Id")]
        public virtual department? Dep { get; set; }

    }
}
