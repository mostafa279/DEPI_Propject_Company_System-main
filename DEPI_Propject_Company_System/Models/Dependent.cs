﻿using DEPI_Propject_Company_System.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DEPI_Propject_Company_System.Models
{
    public class Dependent
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Image { get; set; } = default!;

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = default!;
    }
}
