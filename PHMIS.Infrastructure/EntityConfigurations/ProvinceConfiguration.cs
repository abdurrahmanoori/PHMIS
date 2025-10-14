using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PHMIS.Domain.Entities;

namespace PHMIS.Infrastructure.EntityConfigurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            // Configure the one-to-many relationship with translations
            builder.HasMany(x => x.Translations)
                   .WithOne(t => t.Province)
                   .HasForeignKey(t => t.ProvinceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}