using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PHMIS.Domain.Entities.Laboratory;

namespace PHMIS.Infrastructure.EntityConfigurations
{
    public class LabTestGroupConfiguration : IEntityTypeConfiguration<LabTestGroup>
    {
        public void Configure(EntityTypeBuilder<LabTestGroup> builder)
        {
            builder.HasKey(lg => lg.Id);
            builder.Property(lg => lg.Name).IsRequired().HasMaxLength(100);

            // A LabTestGroup has many LabTests
            builder.HasMany(g => g.LabTests)
                   .WithOne(t => t.LabTestGroup)
                   .HasForeignKey(t => t.LabTestGroupId)
                   .OnDelete(DeleteBehavior.Cascade); // If a group is deleted, its tests are also deleted.
        }
    }
}
