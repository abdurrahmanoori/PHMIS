using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PHMIS.Domain.Entities.Patients;

namespace PHMIS.Infrastructure.EntityConfigurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);

            // A Patient can have many PatientLabTests
            builder.HasMany(p => p.PatientLabTests)
                   .WithOne(plt => plt.Patient)
                   .HasForeignKey(plt => plt.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
