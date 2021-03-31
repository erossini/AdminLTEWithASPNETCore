using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PSC.Domain.Interfaces;
using PSC.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Persistence.Repositories
{
    /// <summary>
    /// Class BaseRepository.
    /// Implements the <see cref="PSC.Persistence.Interfaces.IAsyncRepository{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="PSC.Persistence.Interfaces.IAsyncRepository{T}" />
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        /// <summary>
        /// The log
        /// </summary>
        protected readonly ILogger _log;

        /// <summary>
        /// The database
        /// </summary>
        protected PSCContext _db;

        public BaseRepository(PSCContext db, ILogger<BaseRepository<T>> log)
        {
            _db = db;
            _log = log;
        }

        /// <summary>
        /// Add a new entity as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A Task&lt;T&gt; representing the asynchronous operation.</returns>
        public async Task<T> AddAsync(T entity)
        {
            _log.LogDebug($"[{nameof(T)}] Adding a new record");

            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Delete an entity as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(T entity)
        {
            _log.LogDebug($"[{nameof(T)}] Delete a record by entity");

            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Delete an entity as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(long id)
        {
            _log.LogDebug($"[{nameof(T)}] Delete a record by ID");

            var entity = await GetByIdAsync(id);
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(Expression<Func<T, bool>> func)
        {
            _log.LogDebug($"[{nameof(T)}] Delete a record with expression");

            var list = await ListAllAsync(func);
            _db.Set<T>().RemoveRange(list);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Delete multiple entity by ids as an asynchronous operation.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>A Task&lt;System.Int64&gt; representing the asynchronous operation.</returns>
        public async Task DeleteMultipleAsync(long[] ids)
        {
            _log.LogDebug($"[{nameof(T)}] Deleting multiple records");

            foreach (long id in ids)
            {
                await DeleteAsync(id);
            }
        }

        /// <summary>
        /// Get entity by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;T&gt; representing the asynchronous operation.</returns>
        public async Task<T> GetByIdAsync(long id)
        {
            _log.LogDebug($"[{nameof(T)}] Find a record by ID");

            return await _db.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Get paged reponse as an asynchronous operation.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="size">The size.</param>
        /// <returns>A Task&lt;IReadOnlyList`1&gt; representing the asynchronous operation.</returns>
        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            _log.LogDebug($"[{nameof(T)}] Get paged records");
            return await _db.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// get paged reponse as an asynchronous operation.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <param name="page">The page.</param>
        /// <param name="size">The size.</param>
        /// <returns>A Task&lt;IReadOnlyList`1&gt; representing the asynchronous operation.</returns>
        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size, Expression<Func<T, bool>> func)
        {
            _log.LogDebug($"[{nameof(T)}] Get paged records with expression");
            return await _db.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// List all as an asynchronous operation as List
        /// </summary>
        /// <returns>A Task&lt;IReadOnlyList`1&gt; representing the asynchronous operation.</returns>
        public async virtual Task<IReadOnlyList<T>> ListAllAsync()
        {
            _log.LogDebug($"[{nameof(T)}] Get records as list");
            return await _db.Set<T>().ToListAsync();
        }

        /// <summary>
        /// List all as an asynchronous operation as IReadOnlyList
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns>A Task&lt;IReadOnlyList`1&gt; representing the asynchronous operation.</returns>
        public async virtual Task<IReadOnlyList<T>> ListAllAsync(Expression<Func<T, bool>> func)
        {
            _log.LogDebug($"[{nameof(T)}] Get records as IReadOnlyList");
            return await _db.Set<T>().Where(func).ToListAsync();
        }

        /// <summary>
        /// List all as an asynchronous operation.
        /// </summary>
        /// <returns>A Task&lt;IReadOnlyList`1&gt; representing the asynchronous operation.</returns>
        public virtual IQueryable<T> ListAllQuerableAsync()
        {
            _log.LogDebug($"[{nameof(T)}] Get records as IQuerable");
            return _db.Set<T>();
        }

        /// <summary>
        /// Lists all querable asynchronous.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public virtual IQueryable<T> ListAllQuerableAsync(Expression<Func<T, bool>> func)
        {
            _log.LogDebug($"[{nameof(T)}] Get records as IQuerable and expression");
            return _db.Set<T>().Where(func);
        }

        /// <summary>
        /// Update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task UpdateAsync(T entity)
        {
            _log.LogDebug($"[{nameof(T)}] Update an entity");

            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
