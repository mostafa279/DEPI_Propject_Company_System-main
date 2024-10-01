using System.ComponentModel.DataAnnotations;

namespace DEPI_Propject_Company_System.Models
{
    public class Project : CommonProperties
    {
        [Required]
        [Range(1_00_000, 10_000_000)]
        int Budget { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; } = string.Empty;

        public virtual ICollection<Employee>? Employees { get; set; } = new List<Employee>();

        public virtual ICollection<EmployeeProjects>? EmployeeProjects { get; set; } = new List<EmployeeProjects>();

        public int DepartmentId { get; set; }

        public Department Department { get; set; } = default!;
    }
}
