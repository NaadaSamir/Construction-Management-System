using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Project
    {
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The Project Name must contain alphabetic characters only.")]

        public string? Pname { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "The Project Number must be a numeric value.")]

        public int? Pnumber { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The Project Location must contain alphabetic characters only.")]

        public string? Plocation { get; set; }
        [ForeignKey("department")]
        public int? Dnum { get; set; }

        public virtual Department? department { get; set; }

        public virtual ICollection<WorksOn> WorkOns { get; set; } = new HashSet<WorksOn>();


    }
}
