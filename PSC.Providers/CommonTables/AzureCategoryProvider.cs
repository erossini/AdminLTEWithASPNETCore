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
    public class AzureCategoryProvider
    {
        /// <summary>
        /// The database
        /// </summary>
        private PSCContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureCategoryProvider"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public AzureCategoryProvider(PSCContext dbContext)
        {
            _db = dbContext;
        }

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
            public IEnumerable<AzureCategory> GetValues()
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
        /// insert as an asynchronous operation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A Task&lt;System.Int64&gt; representing the asynchronous operation.</returns>
        public async Task<long> InsertAsync(AzureCategory value)
        {
            await _db.AddAsync(value);
            await _db.SaveChangesAsync();
            return value.ID;
        }

        /// <summary>
        /// replace as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task ReplaceAsync(int id, AzureCategory value)
        {
            _db.Update(value);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
        public async Task<bool> DeleteAsync(long id)
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

        /// <summary>
        /// delete multiple as an asynchronous operation.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>A Task&lt;System.Int64&gt; representing the asynchronous operation.</returns>
        public async Task<long> DeleteMultipleAsync(long[] ids)
        {
            long c = 0;
            foreach (long id in ids)
            {
                c += await DeleteAsync(id) ? 1 : 0;
            }
            return c;
        }
    }
}
