using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Dependent
    { 
 

        [ForeignKey("employee")]
        public int? Essn { get; set; }

        public Employee? employee { get; set; }
        public string? Dependent_Name { get; set; }
        [RegularExpression("^[FM]$", ErrorMessage = "The Gender must be only F or M")]
        public char? Sex { get; set; }

        [Range(typeof(DateTime), "1/1/2004", "12/31/9999", ErrorMessage = "Date must be 2004 or later")]
        public DateTime? Bdate { get; set; }
        [RegularExpression("[a-zA-Z]", ErrorMessage = "The Relationship must be only char")]

        public string? Relationship { get; set; }

    }
}
