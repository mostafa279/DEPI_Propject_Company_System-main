using DEPI_Propject_Company_System.Models.Enums;
using DEPI_Propject_Company_System.Settings;
using DEPI_Propject_Company_System.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DEPI_Propject_Company_System.ViewModels.DependentVM
{
    public class CreateDependentVM
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Display (Name="Gender")]
        public int Gender { get; set; }
        public IEnumerable<SelectListItem>GenderSelectList { get; set; } = Enumerable.Empty<SelectListItem>();

        [Required]
        public int  EmployeeId { get; set; }
        [AllowedExtensions(FileSettings.AllowedExtensions),
            MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Image { get; set; } = default!;
    }
}
