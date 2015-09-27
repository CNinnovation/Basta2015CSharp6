using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksSample.Contracts
{
    public interface IQueryRepository<T, in TKey>
    {
        Task<T> GetItemAsync(TKey id);
        Task<IEnumerable<T>> GetItemsAsync();
    }
}
