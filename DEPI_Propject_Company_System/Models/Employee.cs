﻿using System.ComponentModel.DataAnnotations;

namespace DEPI_Propject_Company_System.Models
{
    public class Employee : CommonPersonProperties
    {
        [Required]
        [MaxLength(50)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = default!;

        public virtual Department DepartmentManager { get; set; } = default!;

        public virtual ICollection<Dependent>? Dependents { get; set; } = new List<Dependent>();

        public virtual ICollection<Project>? Projects { get; set; } = new List<Project>();

        public virtual ICollection<EmployeeProjects>? EmployeeProjects { get; set; } = new List<EmployeeProjects>();
    }
}
