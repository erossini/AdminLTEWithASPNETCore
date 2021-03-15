using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using PSC.Domain;
using PSC.Domain.Audit;
using PSC.Domain.Audit.CommonTables;
using PSC.Domain.CommonTables;
using PSC.Domain.Interfaces;
using PSC.Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSC.Repositories
{
    public class PSCContext : AuditDbContext
    {
        public PSCContext(DbContextOptions<PSCContext> options) : base(options) { }

        public DbSet<AzureCost> AzureCosts { get; set; }
        public DbSet<AzureCostImport> AzureCostImports { get; set; }
        public DbSet<AzureCostImportLog> AzureCostImportLogs { get; set; }

        public DbSet<AuditAzureCost> AuditAzureCosts { get; set; }
        public DbSet<AuditAzureCostImport> AuditAzureCostImports { get; set; }
        public DbSet<AuditAzureCostImportLog> AuditAzureCostImportLogs { get; set; }

        #region Common Tables
        public DbSet<AzureCategory> AzureCategories { get; set; }
        public DbSet<AzureLocation> AzureLocations { get; set; }
        public DbSet<AzureResource> AzureResources { get; set; }
        public DbSet<AzureResourceGroup> AzureResourceGroups { get; set; }
        public DbSet<AzureSubcategory> AzureSubcategories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AuditCountry> AuditCountries { get; set; }
        public DbSet<AuditAzureCategory> AuditAzureCategories { get; set; }
        public DbSet<AuditAzureLocation> AuditAzureLocations { get; set; }
        public DbSet<AuditAzureResource> AuditAzureResources { get; set; }
        public DbSet<AuditAzureResourceGroup> AuditAzureResourceGroups { get; set; }
        public DbSet<AuditAzureSubcategory> AuditAzureSubcategories { get; set; }
        #endregion
        #region Seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            modelBuilder.Entity<AzureCost>().Property(f => f.Cost).HasPrecision(24, 20);
            modelBuilder.Entity<AzureCost>().Property(f => f.Quantity).HasPrecision(24, 20);

            modelBuilder.Entity<AuditAzureCost>().Property(f => f.Cost).HasPrecision(24, 20);
            modelBuilder.Entity<AuditAzureCost>().Property(f => f.Quantity).HasPrecision(24, 20);
        }
        #endregion
    }
}
