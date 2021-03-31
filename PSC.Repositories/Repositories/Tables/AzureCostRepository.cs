using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PSC.Domain;
using PSC.Persistence.Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Persistence.Repositories.Tables
{
    public class AzureCostRepository : BaseRepository<AzureCost>, IAzureCostRepository
    {
        public AzureCostRepository(PSCContext db, ILogger<AzureCostRepository> log) : base(db, log) { }

        public override IQueryable<AzureCost> ListAllQuerableAsync()
        {
            return _db.AzureCosts
                      .Include(c => c.AzureCategory)
                      .Include(c => c.AzureLocation)
                      .Include(c => c.AzureResource)
                      .Include(c => c.AzureResourceGroup)
                      .Include(c => c.AzureSubcategory);
        }

        public override IQueryable<AzureCost> ListAllQuerableAsync(Expression<Func<AzureCost, bool>> func)
        {
            return _db.AzureCosts
                      .Include(c => c.AzureCategory)
                      .Include(c => c.AzureLocation)
                      .Include(c => c.AzureResource)
                      .Include(c => c.AzureResourceGroup)
                      .Include(c => c.AzureSubcategory)
                      .Where(func);
        }
    }
}
