using PSC.Domain.CommonTables;
using PSC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Providers.CommonTables
{
    public class CountriesProvider
    {
        private PSCContext _db;

        public CountriesProvider(PSCContext dbContext)
        {
            _db = dbContext;
        }

        public IEnumerable<Country> GetValues()
        {
            return _db.Countries;
        }

        public async Task<Country> GetAsync(long id)
        {
            return await _db.Countries.FindAsync(id);
        }

        public async Task<long> InsertAsync(Country value)
        {
            await _db.AddAsync(value);
            await _db.SaveChangesAsync();
            return value.IDCountry;
        }

        public async Task ReplaceAsync(int id, Country value)
        {
            _db.Update(value);
            await _db.SaveChangesAsync();
        }

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
