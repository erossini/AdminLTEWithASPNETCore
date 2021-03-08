using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using PSC.Domain;
using PSC.Domain.Audit;
using PSC.Domain.Audit.CommonTables;
using PSC.Domain.CommonTables;
using PSC.Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Repositories
{
    public class PSCContext : AuditDbContext
    {
        public PSCContext(DbContextOptions<PSCContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<AuditMessage> Audit_Messages { get; set; }

        #region Common Tables
        public DbSet<Country> Countries { get; set; }
        public DbSet<AuditCountry> Audit_Countries { get; set; }
        #endregion
        #region Seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
        #endregion
    }
}
