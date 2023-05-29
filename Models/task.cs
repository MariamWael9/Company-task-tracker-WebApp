using CompanyWebApp.Data.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyWebApp.Models
{
    [Serializable]
    public class task
    {
        [Key]
        [Required]public int Id { get; set; }
        [Required(ErrorMessage = " Write task description")] public string taskDesc { get; set; }
        public TskStatus taskStatues { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        //relationship with comments
        public List<comment>? Comments { get; set; }
        
        //relationship between task and its emp
        [Required] public int Employee_Id { get; set; }
        [ForeignKey("Employee_Id")]
        public Employee? employee { get; set; }


    }
}
