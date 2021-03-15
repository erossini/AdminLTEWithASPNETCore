using Microsoft.Extensions.Logging;
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
    /// Class AzureLocationProvider.
    /// Implements the <see cref="PSC.Providers.ProviderBase{PSC.Domain.CommonTables.AzureLocation}" />
    /// </summary>
    /// <seealso cref="PSC.Providers.ProviderBase{PSC.Domain.CommonTables.AzureLocation}" />
    public class AzureLocationProvider : ProviderBase<AzureLocation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureLocationProvider"/> class.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="log">The log.</param>
        public AzureLocationProvider(PSCContext db, ILogger log) : base(db, log) { }

        /// <summary>
        /// Creates if not exist.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>AzureLocation.</returns>
        public async Task<AzureLocation> CreateIfNotExist(string name)
        {
            long id = GetIdByNameAsync(name);

            if (id == 0)
                id = await InsertAsync(new AzureLocation() { Name = name });

            return await GetAsync(id);
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns>IQueryable&lt;AzureLocation&gt;.</returns>
        public IQueryable<AzureLocation> GetValues()
        {
            return _db.AzureLocations;
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;AzureLocation&gt; representing the asynchronous operation.</returns>
        public async Task<AzureLocation> GetAsync(long id)
        {
            return await _db.AzureLocations.FindAsync(id);
        }

        /// <summary>
        /// Gets the identifier by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int64.</returns>
        public long GetIdByNameAsync(string name)
        {
            return _db.AzureLocations.Where(r => r.Name.ToLower() == name.ToLower())?.FirstOrDefault()?.ID ?? 0;
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
        public override async Task<bool> DeleteAsync(long id)
        {
            var entity = await _db.AzureLocations.FindAsync(id);
            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}