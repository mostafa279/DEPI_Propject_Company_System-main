using DEPI_Propject_Company_System.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DEPI_Propject_Company_System.Data.Configurations
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProjects>
    {
        public void Configure(EntityTypeBuilder<EmployeeProjects> builder)
        {
            builder.HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            builder.Property(e => e.StartDate)
                .HasColumnType("DATE")
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
