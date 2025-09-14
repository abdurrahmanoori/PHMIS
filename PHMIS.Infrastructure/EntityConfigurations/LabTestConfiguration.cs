using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PHMIS.Domain.Entities.Laboratory;

namespace PHMIS.Infrastructure.EntityConfigurations
{
    public class LabTestConfiguration : IEntityTypeConfiguration<LabTest>
    {
        public void Configure(EntityTypeBuilder<LabTest> builder)
        {
            builder.HasKey(lt => lt.Id);
            builder.Property(lt => lt.Name).IsRequired().HasMaxLength(100);

            // A LabTest can be associated with many PatientLabTests
            builder.HasMany(lt => lt.PatientLabTests)
                   .WithOne(plt => plt.LabTest)
                   .HasForeignKey(plt => plt.LabTestId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a LabTest if it has associated patient results.
        }
    }
}
