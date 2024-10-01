using System.ComponentModel.DataAnnotations;

namespace DEPI_Propject_Company_System.Models
{
    public class CommonProperties
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}
