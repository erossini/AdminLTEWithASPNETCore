using Microsoft.Extensions.Logging;
using PSC.Domain.CommonTables;
using PSC.Persistence.Interfaces;
using PSC.Persistence.Interfaces.CommonTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Persistence.Repositories.CommonTables
{
    public class AzureCategoryRepository : BaseRepository<AzureCategory>, IAzureCategoryRepository
    {
        public AzureCategoryRepository(PSCContext db, ILogger<AzureCategoryRepository> log): base(db, log) { }

        /// <summary>
        /// Creates if not exist.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>AzureCategory.</returns>
        public async Task<AzureCategory> CreateIfNotExist(string name)
        {
            long id = GetIdByNameAsync(name);

            if (id == 0)
            {
                var entity = await AddAsync(new AzureCategory() { Name = name });
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
            return _db.AzureCategories.Where(r => r.Name.ToLower() == name.ToLower())?.FirstOrDefault()?.ID ?? 0;
        }
    }
}