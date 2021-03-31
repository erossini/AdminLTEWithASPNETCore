using Microsoft.Extensions.Logging;
using PSC.Domain.CommonTables;
using PSC.Persistence.Interfaces.CommonTables;
using System.Linq;
using System.Threading.Tasks;

namespace PSC.Persistence.Repositories.CommonTables
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(PSCContext db, ILogger<CountryRepository> log): base(db, log) { }

        /// <summary>
        /// Creates if not exist.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>AzureCategory.</returns>
        public async Task<Country> CreateIfNotExist(string name)
        {
            long id = GetIdByNameAsync(name);

            if (id == 0)
            {
                var entity = await AddAsync(new Country() { Name = name });
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