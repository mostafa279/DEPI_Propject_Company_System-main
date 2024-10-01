using DEPI_Propject_Company_System.Models;
using DEPI_Propject_Company_System.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DEPI_Propject_Company_System.ViewModels.DependentVM
{
    public class DisplayDependentVM
    {
        [Required]
        public string Name { get; set; } = null!;
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        public string Image { get; set; } = default!;
        [Display(Name="Employee")]
        [Required]
        public Employee Employee { get; set; } = null!;

    }
}
