using BooksSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksSample.Contracts
{
    public interface IBooksService
    {
        Task LoadBooksAsync();

        IEnumerable<Book> Books { get; }

        Book GetBook(int bookId);

        Task<Book> AddOrUpdateBookAsync(Book book);

        void SpecialSave(Book book);
    }
}
