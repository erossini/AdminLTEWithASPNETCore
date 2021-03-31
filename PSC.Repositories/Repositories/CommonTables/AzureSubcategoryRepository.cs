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
    public class AzureSubcategoryRepository : BaseRepository<AzureSubcategory>, IAzureSubcategoryRepository
    {
        public AzureSubcategoryRepository(PSCContext db, ILogger<AzureSubcategoryRepository> log): base(db, log) { }

        /// <summary>
        /// Creates if not exist.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>AzureCategory.</returns>
        public async Task<AzureSubcategory> CreateIfNotExist(string name)
        {
            long id = GetIdByNameAsync(name);

            if (id == 0)
            {
                var entity = await AddAsync(new AzureSubcategory() { Name = name });
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