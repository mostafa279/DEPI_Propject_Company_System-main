using System.ComponentModel.DataAnnotations;

namespace DEPI_Propject_Company_System.ViewModels.DepartmentVM
{
    public class DisplayDepartmentVM
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Location { get; set; } = null!;
        [Required]
        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; } = null!;
    }
}
