using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PHMIS.Domain.Entities;

namespace PHMIS.Infrastructure.EntityConfigurations
{
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name).IsRequired().HasMaxLength(100);

            // Configure HospitalType and HospitalCategory enums to be stored as strings
            builder.Property(h => h.Type)
                   .HasConversion(new EnumToStringConverter<HospitalType>())
                   .HasMaxLength(50);

            builder.Property(h => h.Category)
                   .HasConversion(new EnumToStringConverter<HospitalCategory>())
                   .HasMaxLength(50);
        }
    }
}
