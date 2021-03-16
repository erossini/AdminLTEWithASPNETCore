using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PSC.Domain;
using PSC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Providers.Tables
{
    /// <summary>
    /// Class AzureCostProvider.
    /// </summary>
    public class AzureCostProvider : ProviderBase<AzureCost>
    {
        public AzureCostProvider(PSCContext db, ILogger log) : base(db, log) { }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns>IQueryable&lt;AzureCost&gt;.</returns>
        public IQueryable<AzureCost> GetValues()
        {
            return _db.AzureCosts
                        .Include(c => c.AzureCategory)
                        .Include(c => c.AzureLocation)
                        .Include(c => c.AzureResource)
                        .Include(c => c.AzureResourceGroup)
                        .Include(c => c.AzureSubcategory);
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;AzureCost&gt; representing the asynchronous operation.</returns>
        public async Task<AzureCost> GetAsync(long id)
        {
            return await _db.AzureCosts.FindAsync(id);
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
        public override async Task<bool> DeleteAsync(long id)
        {
            _log.LogDebug($"[AzureCost] Deleting the record Id {id}");
            var entity = await _db.AzureCosts.FindAsync(id);
            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();

                _log.LogDebug($"[AzureCost] Deleted the record Id {id}");
                return true;
            }

            _log.LogDebug($"[AzureCost] Can't delete the record Id {id}");
            return false;
        }
    }
}