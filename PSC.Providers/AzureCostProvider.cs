using Microsoft.Extensions.Logging;
using PSC.Domain;
using PSC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Providers
{
    public class AzureCostProvider
    {
        private PSCContext _db;
        private readonly ILogger _log;

        public AzureCostProvider(PSCContext dbContext, ILogger log)
        {
            _db = dbContext;
            _log = log;
        }

        public IEnumerable<AzureCost> GetValues()
        {
            return _db.AzureCosts;
        }

        public async Task<AzureCost> GetAsync(long id)
        {
            return await _db.AzureCosts.FindAsync(id);
        }

        public async Task<long> InsertAsync(AzureCost value)
        {
            _log.LogDebug("[AzureCost] Start adding a new record");
            await _db.AddAsync(value);
            await _db.SaveChangesAsync();

            _log.LogDebug($"[AzureCost] Added record ID {value.ID}");
            return value.ID;
        }

        public async Task ReplaceAsync(int id, AzureCost value)
        {
            _db.Update(value);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _db.AzureCosts.FindAsync(id);
            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

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
