using Microsoft.Extensions.Logging;
using PSC.Domain.CommonTables;
using PSC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Providers.CommonTables
{
    public class AzureResourceProvider : ProviderBase<AzureResource>
    {
        public AzureResourceProvider(PSCContext db, ILogger log) : base(db, log) { }

        public async Task<AzureResource> CreateIfNotExist(string name)
        {
            long id = GetIdByNameAsync(name);

            if (id == 0)
                id = await InsertAsync(new AzureResource() { Name = name });

            return await GetAsync(id);
        }

        public IQueryable<AzureResource> GetValues()
        {
            return _db.AzureResources;
        }

        public async Task<AzureResource> GetAsync(long id)
        {
            return await _db.AzureResources.FindAsync(id);
        }

        public long GetIdByNameAsync(string name)
        {
            return _db.AzureResources.Where(r => r.Name.ToLower() == name.ToLower())?.FirstOrDefault()?.ID ?? 0;
        }

        public override async Task<bool> DeleteAsync(long id)
        {
            var entity = await _db.AzureResources.FindAsync(id);
            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
