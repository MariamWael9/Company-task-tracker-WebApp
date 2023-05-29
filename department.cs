using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyWebApp.Models
{
    [Serializable]
    public class department
    {
        [Key]
        [Required(ErrorMessage ="Department ID is required")]public int Id { get; set; }
        [Required(ErrorMessage = "Department Name is required")] public string Name { get; set; }

        //relation between dep and its manager
        
        public int? Manager_Id { get; set; }

        //department has relationship with employees work there
        public List<Employee>? Employees { get; set; }

    }
}
