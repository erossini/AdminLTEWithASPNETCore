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
    public class AzureResourceGroupProvider : ProviderBase<AzureResourceGroup>
    {
        public AzureResourceGroupProvider(PSCContext db, ILogger log): base(db, log) { }
        
        public async Task<AzureResourceGroup> CreateIfNotExist(string name)
        {
            long id = GetIdByNameAsync(name);

            if (id == 0)
                id = await InsertAsync(new AzureResourceGroup() { Name = name });

            return await GetAsync(id);
        }

        public IQueryable<AzureResourceGroup> GetValues()
        {
            return _db.AzureResourceGroups;
        }

        public async Task<AzureResourceGroup> GetAsync(long id)
        {
            return await _db.AzureResourceGroups.FindAsync(id);
        }

        public long GetIdByNameAsync(string name)
        {
            return _db.AzureResourceGroups.Where(r => r.Name.ToLower() == name.ToLower())?.FirstOrDefault()?.ID ?? 0;
        }

        public override async Task<bool> DeleteAsync(long id)
        {
            var entity = await _db.AzureResourceGroups.FindAsync(id);
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
