using DEPI_Propject_Company_System.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DEPI_Propject_Company_System.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasMany(p => p.Employees)
                .WithMany(e => e.Projects)
                .UsingEntity<EmployeeProjects>(
                    l => l.HasOne(ep => ep.Employee)
                    .WithMany(e => e.EmployeeProjects)
                    .HasForeignKey(ep => ep.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict),

                    l => l.HasOne(ep => ep.Project)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(ep => ep.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                );

            builder.HasOne(p => p.Department)
                .WithMany(d => d.Projects)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
