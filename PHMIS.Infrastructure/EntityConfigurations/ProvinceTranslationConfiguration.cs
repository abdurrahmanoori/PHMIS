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
            builder.Property(x => x.LanguageCode).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            // use LanguageId for uniqueness to match FK relationship
            builder.HasIndex(x => new { x.ProvinceId, x.LanguageId }).IsUnique();

            builder.HasOne(x => x.Province)
                   .WithMany(p => p.Translations)
                   .HasForeignKey(x => x.ProvinceId)
                   .OnDelete(DeleteBehavior.Cascade);

            // configure relationship to Language (FK)
            builder.HasOne(x => x.Language)
                   .WithMany()
                   .HasForeignKey(x => x.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
