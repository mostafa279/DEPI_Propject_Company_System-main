using DEPI_Propject_Company_System.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DEPI_Propject_Company_System.Models.Enums;

namespace DEPI_Propject_Company_System.Data.Configurations
{
    public class DependentConfiguration : IEntityTypeConfiguration<Dependent>
    {
        public void Configure(EntityTypeBuilder<Dependent> builder)
        {
            builder.HasKey(d => new { d.Name, d.EmployeeId });

            builder.HasOne(d => d.Employee)
                .WithMany(e => e.Dependents)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.Property(e => e.Gender)
                .HasConversion(
                    e => e.ToString(),
                    e => (Gender)Enum.Parse(typeof(Gender), e)
                );
        }
    }
}
