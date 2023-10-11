using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class DEPT_LOCATION
    {
        [ForeignKey("department")]
        public int? Dnumber { get; set; }

        public Department? department { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The DLocation must contain alphabetic characters only.")]

        public string? DLocation { get; set; }
    }
}
