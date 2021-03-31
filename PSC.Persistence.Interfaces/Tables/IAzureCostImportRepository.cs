using PSC.Domain;
using System.Threading.Tasks;

namespace PSC.Persistence.Interfaces.Tables
{
    public interface IAzureCostImportRepository : IAsyncRepository<AzureCostImport>
    {
        Task<AzureCostImport> CreateIfNotExist(string filename, string username);
        long GetIdByNameAsync(string name);
    }
}
