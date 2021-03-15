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
    /// Class AzureCategoryProvider.
    /// </summary>
    public class AzureCategoryProvider : ProviderBase<AzureCategory>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureCategoryProvider"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public AzureCategoryProvider(PSCContext db, ILogger log) : base(db, log) { }

        public async Task<AzureCategory> CreateIfNotExist(string name)
        {
            long id = GetIdByNameAsync(name);

            if (id == 0)
                id = await InsertAsync(new AzureCategory() { Name = name });

            return await GetAsync(id);
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns>IEnumerable&lt;AzureCategory&gt;.</returns>
        public IQueryable<AzureCategory> GetValues()
        {
            return _db.AzureCategories;
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;AzureCategory&gt; representing the asynchronous operation.</returns>
        public async Task<AzureCategory> GetAsync(long id)
        {
            return await _db.AzureCategories.FindAsync(id);
        }

        /// <summary>
        /// Gets the identifier by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int64.</returns>
        public long GetIdByNameAsync(string name)
        {
            return _db.AzureCategories.Where(r => r.Name.ToLower() == name.ToLower())?.FirstOrDefault()?.ID ?? 0;
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
        public override async Task<bool> DeleteAsync(long id)
        {
            var entity = await _db.AzureCategories.FindAsync(id);
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