using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PHMIS.Domain.Entities;
using PHMIS.Domain.Entities.Identity.Entity;
using PHMIS.Domain.Entities.Laboratory;
using PHMIS.Domain.Entities.Patients;
using PHMIS.Infrastructure.DatabaseSeeders;
using System.Reflection;

namespace PHMIS.Infrastructure.Context
{
    public partial class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all IEntityTypeConfiguration classes from this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region Seed Database
            PatientSeed.DataSeed(modelBuilder);
            LabTestGroupSeed.DataSeed(modelBuilder);
            LabTestSeed.DataSeed(modelBuilder);
            HospitalSeed.DataSeed(modelBuilder);
            UserSeed.DataSeed(modelBuilder);
            #endregion

            // Allow extension from other layers via partial method
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<ProvinceTranslation> ProvinceTranslations { get; set; }
        public DbSet<LabTestGroup> LabTestGroups { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<PatientLabTest> PatientLabTests { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
    }
}
