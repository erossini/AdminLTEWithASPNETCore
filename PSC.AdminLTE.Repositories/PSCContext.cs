using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using PSC.AdminLTE.Domain;
using PSC.AdminLTE.Domain.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.AdminLTE.Repositories
{
    public class PSCContext : AuditDbContext
    {
        public PSCContext(DbContextOptions<PSCContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<AuditMessage> Audit_Messages { get; set; }
    }
}
