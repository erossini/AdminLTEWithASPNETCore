using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PSC.Persistence.Interfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> func);
        Task DeleteAsync(long id);
        Task DeleteAsync(T entity);
        Task DeleteMultipleAsync(long[] ids);
        Task<T> GetByIdAsync(long id);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size, Expression<Func<T, bool>> func);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAllAsync(Expression<Func<T, bool>> func);
        IQueryable<T> ListAllQuerableAsync();
        IQueryable<T> ListAllQuerableAsync(Expression<Func<T, bool>> func);
        Task UpdateAsync(T entity);
    }
}
