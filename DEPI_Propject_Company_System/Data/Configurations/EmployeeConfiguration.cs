using DEPI_Propject_Company_System.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DEPI_Propject_Company_System.Models.Enums;

namespace DEPI_Propject_Company_System.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Salary)
                .HasColumnType("MONEY");

            builder.Property(e => e.Image)
                .IsRequired(false);

            builder.Property(e => e.StartDate)
                .HasColumnType("DATE")
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
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
