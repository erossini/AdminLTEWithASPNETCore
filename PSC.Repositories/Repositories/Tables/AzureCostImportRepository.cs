using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PSC.Domain;
using PSC.Persistence.Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Persistence.Repositories.Tables
{
    public class AzureCostImportRepository : BaseRepository<AzureCostImport>, IAzureCostImportRepository
    {
        public AzureCostImportRepository(PSCContext db, ILogger<AzureCostImportRepository> log) : base(db, log) { }

        public async Task<AzureCostImport> CreateIfNotExist(string filename, string username)
        {
            long id = GetIdByNameAsync(filename);

            if (id == 0)
            {
                var entity = await AddAsync(new AzureCostImport() { FileName = filename, UserId = username });
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
            return _db.AzureCostImports.Where(r => r.FileName.ToLower() == name.ToLower())?.FirstOrDefault()?.ID ?? 0;
        }
    }
}