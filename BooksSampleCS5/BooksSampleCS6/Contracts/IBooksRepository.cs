using BooksSample.Models;

namespace BooksSample.Contracts
{
    public interface IBooksRepository : IQueryRepository<Book, int>, IUpdateRepository<Book, int>
    {
    }
}
