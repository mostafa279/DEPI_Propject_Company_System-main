using DEPI_Propject_Company_System.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DEPI_Propject_Company_System.Models
{
    public class CommonPersonProperties : CommonProperties
    {
        [Required]
        public int Age { get; set; }

        public byte[] Image { get; set; } = default!;

        [Required]
        public Gender Gender { get; set; }
    }
}
