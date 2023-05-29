using CompanyWebApp.Models;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CompanyWebApp.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //add all models
                //department
                if (!context.departments.Any())
                {
                    context.departments.AddRange(new List<department>()
                    {
                        new department() {
                            //Id = 1,
                            Name = "Finance",
                            Manager_Id = 5
                        },
                        new department() {
                            //Id = 2,
                            Name = "IT",
                            Manager_Id =1 
                        },
                        new department() {
                            //Id = 3,
                            Name = "Managment",
                            Manager_Id =7
                        }
                    });
                    context.SaveChanges();
                }
                //emplyees
                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new List<Employee>()
                    {
                        new Employee() {
                            //Id = 1,
                            Name = "Ahmed Mahmoud",
                            Phone = "011111223456",
                            Password = "Ahmed1",
                            Title = "IT Dapartment manager",
                            empStatus = enums.EmpStatus.Active,
                            empRole = enums.EmpRole.Manager,
                            Email = "AhmedMO@gmail.com",
                            Dep_Id = 2
                        },
                        new Employee() {
                            //Id = 2,
                            Name = "Rami Mahmoud",
                            Phone = "01143533456",
                            Password = "RAMIm",
                            Title = "IT Team Lead",
                            empStatus = enums.EmpStatus.Active,
                            empRole = enums.EmpRole.Supervisor,
                            Email = "RamiMO@gmail.com",
                            Dep_Id = 2,
                            Supervisor_Id = 1 },
                        new Employee() {
                            //Id = 3,
                            Name = "Emre Mahmoud",
                            Phone = "01000533111",
                            Password = "EMmah333",
                            Title = "IT Engineer",
                            empStatus = enums.EmpStatus.Active,
                            empRole = enums.EmpRole.Employee,
                            Email = "EmreMO@gmail.com",
                            Dep_Id = 2,
                            Supervisor_Id = 2},
                        new Employee() {
                            //Id = 4,
                            Name = "Omar Ahmed",
                            Phone = "01555542181",
                            Password = "OmmA",
                            Title = "Financial Manager",
                            empStatus = enums.EmpStatus.Active,
                            empRole = enums.EmpRole.Employee,
                            Email = "omar_ahmed@gmail.com",
                            Dep_Id = 1,
                            Supervisor_Id = 6 },
                        new Employee() {
                            //Id = 5,
                            Name = "Kareem Tarek",
                            Phone = "01122336581",
                            Password = "Kareem1",
                            Title = "Finance Dapartment manager",
                            empStatus = enums.EmpStatus.Active,
                            empRole = enums.EmpRole.Manager,
                            Email = "kareemt@gmail.com",
                            Dep_Id = 1
                        },                      
                        new Employee() {
                            //Id = 6,
                            Name = "Jana Ahmed",
                            Phone = "01000533155",
                            Password = "jana333",
                            Title = "Financial Director",
                            empStatus = enums.EmpStatus.Active,
                            empRole = enums.EmpRole.Supervisor,
                            Email = "JanaA@gmail.com",
                            Dep_Id = 1,
                            Supervisor_Id = 5},
                        new Employee() {
                            //Id = 7,
                            Name = "Ragheb Mahmoud",
                            Phone = "01000533165",
                            Password = "ARN7",
                            Title = "System Admin",
                            empStatus = enums.EmpStatus.Active,
                            empRole = enums.EmpRole.Admin,
                            Email = "aragebn@gmail.com",
                            Dep_Id = 3}
                    });
                    context.SaveChanges();
                }
                
                //tasks
                if (!context.tasks.Any())
                {
                    context.tasks.AddRange(new List<task>()
                    {
                        new task() {
                            //Id = 1,
                            taskDesc = "Create the login page and the database",
                            taskStatues = enums.TskStatus.In_progress,
                            Employee_Id = 3,
                            StartDate = new DateTime(2023, 5, 7),
                            EndDate = new DateTime(2023, 5, 28)
                        },
                        new task() {
                            //Id = 2,
                            taskDesc = "Create the Home page and the user's profile",
                            taskStatues = enums.TskStatus.In_queue,
                            Employee_Id = 3,
                            StartDate = new DateTime(2023, 6, 1),
                            EndDate = new DateTime(2023, 6, 15)
                        },
                        new task() {
                            //Id = 3,
                            taskDesc = "Create Calender View for Finance plans",
                            Employee_Id = 4,
                            taskStatues = enums.TskStatus.Paused,
                            StartDate = new DateTime(2023, 4, 1),
                            EndDate = new DateTime(2023, 5, 1)
                        }

                    });
                    context.SaveChanges();
                }
                //comments
                if (!context.comments.Any())
                {
                    context.comments.AddRange(new List<comment>()
                    {
                        new comment() {
                            //Id = 1,
                            Text = "Add email field to be entered in login form",
                            Task_Id = 1,
                            Emp_Id = 2
                        },
                        new comment() {
                            //Id = 2,
                            Text = "Check all ID columns data types",
                            Task_Id = 1,
                            Emp_Id = 3
                        } 
                    });
                    context.SaveChanges();
                }
                
            }
        }
    }
}
