using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class WorksOn
    {
        [ForeignKey("Employee")]

        public int? ESSN { get; set; }

        public Employee? employee { get; set; } 

        [ForeignKey("Project")]
        public int? Pno { get; set; }

        public Project? project { get; set; }

        [Range(6,12, ErrorMessage = "The range of hours must be between 6 and 12 hours")]

        public int? Hours { get; set; }
    }
}
