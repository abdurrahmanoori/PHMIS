using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PHMIS.Domain.Entities.Patients;
using PHMIS.Domain.Enums;

namespace PHMIS.Infrastructure.EntityConfigurations
{
    public class PatientLabTestConfiguration : IEntityTypeConfiguration<PatientLabTest>
    {
        public void Configure(EntityTypeBuilder<PatientLabTest> builder)
        {
            builder.HasKey(plt => plt.Id);

            // Configure the enum-to-string conversion for LabStatus
            builder.Property(e => e.Status)
                .HasConversion(new EnumToStringConverter<LabStatus>())
                .HasMaxLength(50); // Set a max length for the string column
        }
    }
}
