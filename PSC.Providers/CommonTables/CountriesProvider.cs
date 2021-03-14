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
    /// Class CountriesProvider.
    /// </summary>
    public class CountriesProvider
    {
        /// <summary>
        /// The database
        /// </summary>
        private PSCContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountriesProvider"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CountriesProvider(PSCContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns>IEnumerable&lt;Country&gt;.</returns>
        public IQueryable<Country> GetValues()
        {
            return _db.Countries;
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;Country&gt; representing the asynchronous operation.</returns>
        public async Task<Country> GetAsync(long id)
        {
            return await _db.Countries.FindAsync(id);
        }

        /// <summary>
        /// insert as an asynchronous operation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A Task&lt;System.Int64&gt; representing the asynchronous operation.</returns>
        public async Task<long> InsertAsync(Country value)
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
        public async Task ReplaceAsync(long id, Country value)
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
            var entity = await _db.Countries.FindAsync(id);
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