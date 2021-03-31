using System.Threading.Tasks;

namespace PSC.Persistence.Interfaces
{
    public interface ICommonTableRepository<T> : IAsyncRepository<T> where T : class
    {
        Task<T> CreateIfNotExist(string name);
        long GetIdByNameAsync(string name);
    }
}