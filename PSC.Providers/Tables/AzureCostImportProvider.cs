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
    public class AzureCostImportProvider : ProviderBase<AzureCostImport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureCostImportProvider"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public AzureCostImportProvider(PSCContext db, ILogger log) : base(db, log) { }

        /// <summary>
        /// Creates if not exist.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="username">The username.</param>
        /// <returns>AzureCostImport.</returns>
        public async Task<AzureCostImport> CreateIfNotExist(string filename, string username)
        {
            long id = GetIdByNameAsync(filename);

            if (id == 0)
                id = await InsertAsync(new AzureCostImport() { FileName = filename, UserId = username });

            return await GetAsync(id);
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns>IEnumerable&lt;AzureCategory&gt;.</returns>
        public IQueryable<AzureCostImport> GetValues()
        {
            _log.LogDebug("[AzureCostImportLogProvider] GetValues");
            return _db.AzureCostImports;
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;AzureCategory&gt; representing the asynchronous operation.</returns>
        public async Task<AzureCostImport> GetAsync(long id)
        {
            _log.LogDebug($"[AzureCostImportLogProvider] GetValue for Id {id}");
            return await _db.AzureCostImports.FindAsync(id);
        }

        /// <summary>
        /// Gets the identifier by name asynchronous.
        /// </summary>
        /// <param name="filename">The name.</param>
        /// <returns>System.Int64.</returns>
        public long GetIdByNameAsync(string filename)
        {
            _log.LogDebug("[AzureCostImportLogProvider] GetIdByNameAsync");
            return _db.AzureCostImports.Where(r => r.FileName.ToLower() == filename.ToLower())?.FirstOrDefault()?.ID ?? 0;
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
        public override async Task<bool> DeleteAsync(long id)
        {
            _log.LogDebug($"[AzureCostImportLogProvider] Deleting the record Id {id}");
            var entity = await _db.AzureCostImports.FindAsync(id);
            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();

                _log.LogDebug($"[AzureCostImportLogProvider] Deleted the record Id {id}");
                return true;
            }

            _log.LogDebug($"[AzureCostImportLogProvider] Can't delete the record Id {id}");
            return false;
        }
    }
}