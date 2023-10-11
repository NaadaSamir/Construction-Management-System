using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Employee
    {
        [RegularExpression("[a-zA-Z]{3,20}", ErrorMessage = "The first name must be between 3 and 20 characters long.")]
        public string? Fname { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The Minit name must be between 3 and 20 characters long.")]
        public string? Minit { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The last name must be between 3 and 20 characters long.")]
        public string? Lname { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "The Social Security Number must be a numeric value.")]
        public int SSN { get; set; }

        public DateTime? BDATE { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The address must contain alphabetic characters only.")]

        public string? Address { get; set; }
        [RegularExpression("^[FM]$", ErrorMessage = "The sex must be either 'F' or 'M'.")]
        public char? Sex { get; set; }


        [Range(10000,25000, ErrorMessage = "The Range of salary must be between 10 and 25 thousand")]
        public int? Salary { get; set; }
        [ForeignKey("employee")]
        public int? SuperSSN { get; set; }
        public Employee? employee { get; set; }
     

        [ForeignKey("department")]
        public int? DNO { get; set; }

        public Department? department { get; set; }
        public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();
        public virtual ICollection<WorksOn> WorkOns { get; set; } = new HashSet<WorksOn>();
        public virtual ICollection<Dependent> Dependents { get; set; } = new HashSet<Dependent>();


    }
}
