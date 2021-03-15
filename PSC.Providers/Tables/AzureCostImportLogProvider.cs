using Microsoft.Extensions.Logging;
using PSC.Domain;
using PSC.Domain.CommonTables;
using PSC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Providers.CommonTables
{
    /// <summary>
    /// Class AzureCostImportProvider.
    /// </summary>
    public class AzureCostImportLogProvider : ProviderBase<AzureCostImportLog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureCostImportProvider"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public AzureCostImportLogProvider(PSCContext db, ILogger log) : base(db, log) { }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns>IEnumerable&lt;AzureCategory&gt;.</returns>
        public IQueryable<AzureCostImportLog> GetValues()
        {
            return _db.AzureCostImportLogs;
        }

        public IQueryable<AzureCostImportLog> GetValues(long AzureCostId)
        {
            return _db.AzureCostImportLogs.Where(r => r.AzureCostImportId == AzureCostId);
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;AzureCategory&gt; representing the asynchronous operation.</returns>
        public async Task<AzureCostImportLog> GetAsync(long id)
        {
            return await _db.AzureCostImportLogs.FindAsync(id);
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
        public override async Task<bool> DeleteAsync(long id)
        {
            _log.LogDebug($"[AzureCostImportProvider] Deleting the record Id {id}");
            var entity = await _db.AzureCostImportLogs.FindAsync(id);
            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();

                _log.LogDebug($"[AzureCostImportProvider] Deleted the record Id {id}");
                return true;
            }

            _log.LogDebug($"[AzureCostImportProvider] Can't delete the record Id {id}");
            return false;
        }
    }
}