using BooksSample.Contracts;
using BooksSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksSample.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private List<Book> _books;
        public BooksRepository()
        {
            InitSampleBooks();
        }

        private void InitSampleBooks()
        {
            _books = new List<Book>()
            {
                new Book(1) { Title = "Professional C# 6", Publisher = "Wrox Press" },
                new Book(2) { Title = "Professional C# 5.0", Publisher = "Wrox Press" },
                new Book(3) { Title = "Enterprise Services with the .NET Framework", Publisher = "AWL" }
            };
        }

        public Task<bool> DeleteAsync(int id)
        {
            Book bookToDelete = _books.Find(b => b.BookId == id);
            if (bookToDelete != null)
            {
                return Task.FromResult<bool>(_books.Remove(bookToDelete));
            }
            return Task.FromResult<bool>(false);
        }

        // DONE: 04 - expression bodied member
        public Task<Book> GetItemAsync(int id) =>
            Task.FromResult(_books.Find(b => b.BookId == id));

        public Task<IEnumerable<Book>> GetItemsAsync() =>
            Task.FromResult<IEnumerable<Book>>(_books);

        public Task<Book> UpdateAsync(Book item)
        {
            Book bookToUpdate = _books.Find(b => b.BookId == item.BookId);
            int ix = _books.IndexOf(bookToUpdate);
            _books[ix] = item;
            return Task.FromResult(_books[ix]);
        }

        public Task<Book> AddAsync(Book item)
        {
            _books.Add(item);
            return Task.FromResult(item);
        }
    }
}
