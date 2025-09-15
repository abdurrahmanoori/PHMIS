using Microsoft.EntityFrameworkCore;
using PHMIS.Infrastructure.DatabaseSeeders;

namespace PHMIS.Infrastructure.Context
{
    public partial class AppDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            // Register additional seeds without modifying the main AppDbContext file
            ProvinceSeed.DataSeed(modelBuilder);
        }
    }
}
