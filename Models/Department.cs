using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Department
    {
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "The Department Name must be alphanumeric without special characters.")]
        public string? Dname { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "The Department Number must be a numeric value.")]

        public int? Dnumber { get; set; }
        [ForeignKey("employee")]
        public int? MGRSSN { get; set; }

        public Employee? employee { get; set; }


        [Range(typeof(DateTime), "1/1/1990", "12/31/9999", ErrorMessage = "Date cannot be before 1990")]
        public DateTime? MGRStartDate { get; set; } 

     
        [Required]
        public virtual ICollection<DEPT_LOCATION> DEPT_LOCATIONs { get; set; } = new HashSet<DEPT_LOCATION>();
        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

      



    }
}
