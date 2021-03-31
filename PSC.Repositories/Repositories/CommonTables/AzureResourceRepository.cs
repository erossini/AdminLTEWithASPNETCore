using Microsoft.Extensions.Logging;
using PSC.Domain.CommonTables;
using PSC.Persistence.Interfaces.CommonTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Persistence.Repositories.CommonTables
{
    public class AzureResourceRepository : BaseRepository<AzureResource>, IAzureResourceRepository
    {
        public AzureResourceRepository(PSCContext db, ILogger<AzureResourceRepository> log): base(db, log) { }

        /// <summary>
        /// Creates if not exist.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>AzureCategory.</returns>
        public async Task<AzureResource> CreateIfNotExist(string name)
        {
            long id = GetIdByNameAsync(name);

            if (id == 0)
            {
                var entity = await AddAsync(new AzureResource() { Name = name });
                id = entity.ID;
            }

            return await GetByIdAsync(id);
        }

        /// <summary>
        /// Gets the identifier by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int64.</returns>
        public long GetIdByNameAsync(string name)
        {
            Expression<Func<AzureResource, bool>> func = r => r.Name.ToLower() == name.ToLower();
            var result = ListAllQuerableAsync(func);
            return result?.FirstOrDefault()?.ID ?? 0;
        }
    }
}