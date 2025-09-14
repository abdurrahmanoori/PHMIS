using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PHMIS.Domain.Entities;

namespace PHMIS.Infrastructure.EntityConfigurations
{
    public class ProvinceTranslationConfiguration : IEntityTypeConfiguration<ProvinceTranslation>
    {
        public void Configure(EntityTypeBuilder<ProvinceTranslation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Language).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            builder.HasIndex(x => new { x.ProvinceId, x.Language }).IsUnique();

            builder.HasOne(x => x.Province)
                   .WithMany(p => p.Translations)
                   .HasForeignKey(x => x.ProvinceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
