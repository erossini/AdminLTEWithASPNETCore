using Microsoft.Extensions.Logging;
using PSC.Domain.Interfaces;
using PSC.Repositories;
using System.Threading.Tasks;

namespace PSC.Providers
{
    public abstract class ProviderBase<T> where T : ITable
    {
        /// <summary>
        /// The database
        /// </summary>
        protected PSCContext _db;
        /// <summary>
        /// The log
        /// </summary>
        protected readonly ILogger _log;

        public ProviderBase(PSCContext db, ILogger log)
        {
            _db = db;
            _log = log;
        }

        public abstract Task<bool> DeleteAsync(long id);

        /// <summary>
        /// insert as an asynchronous operation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A Task&lt;System.Int64&gt; representing the asynchronous operation.</returns>
        public async Task<long> InsertAsync(T value)
        {
            _log.LogDebug($"[{nameof(T)}] Start adding a new record");
            await _db.AddAsync(value);
            await _db.SaveChangesAsync();

            _log.LogDebug($"[{nameof(T)}] Added record ID {value.ID}");
            return value.ID;
        }

        /// <summary>
        /// replace as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task ReplaceAsync(long id, T value)
        {
            _log.LogDebug($"[{nameof(T)}] Replace the record Id {id}");
            _db.Update(value);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// delete multiple as an asynchronous operation.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>A Task&lt;System.Int64&gt; representing the asynchronous operation.</returns>
        public async Task<long> DeleteMultipleAsync(long[] ids)
        {
            _log.LogDebug($"[{nameof(T)}] Deleting multiple records");
            long c = 0;
            foreach (long id in ids)
            {
                c += await DeleteAsync(id) ? 1 : 0;
            }
            return c;
        }
    }
}
