using DEPI_Propject_Company_System.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DEPI_Propject_Company_System.ViewModels.DepartmentVM
{
    public class CreateDepartmentVM
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Location { get; set; } = null!;
        [Required]
        [Display(Name = "Manager Name")]
        public int? ManagerId { get; set; }
        public IEnumerable<SelectListItem> ManagersSelectList = Enumerable.Empty<SelectListItem>();
 

    }
}
