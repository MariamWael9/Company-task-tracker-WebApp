using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyWebApp.Models
{
    [Serializable]
    public class comment
    {
        [Key]
        [Required]public int Id { get; set; }

        [Required(ErrorMessage = "Write a comment first")] public string Text { get; set; }

        //relation between comment and its task
        [Required]public int Task_Id { get; set; }
        [ForeignKey("Task_Id")]
        public task? Task { get; set; }

        // relation between comment and employee who wrote it
        public int? Emp_Id { get; set; }
        [ForeignKey("Emp_Id")]
        public Employee? employee { get; set; }
    }
}
