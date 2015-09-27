using BooksSample.Contracts;
using BooksSample.Errors;
using BooksSample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BooksSample.Services
{
    public class BooksService : IBooksService
    {
        private ObservableCollection<Book> _books = new ObservableCollection<Book>();
        private IBooksRepository _booksRepository;
        public BooksService(IBooksRepository repository)
        {
            _booksRepository = repository;
        }

        public async Task LoadBooksAsync()
        {
            if (_books.Count > 0) return;

            IEnumerable<Book> books = await _booksRepository.GetItemsAsync();
            _books.Clear();
            foreach (var b in books)
            {
                _books.Add(b);
            }
        }

        // DONE: expression
        public Book GetBook(int bookId) => _books.Where(b => b.BookId == bookId).SingleOrDefault();

        public async Task<Book> AddOrUpdateBookAsync(Book book)
        {
            // DONE: 03 - nameof expression
            if (book == null) throw new ArgumentNullException(nameof(book));

            Book old = _books.Where(b => b.BookId == book.BookId).SingleOrDefault();

            if (old == null)
            {
                Book added = await _booksRepository.AddAsync(book);
                _books.Add(added);
                return added;
            }
            else
            {
                Book updated = await _booksRepository.UpdateAsync(book);
                int ix = _books.IndexOf(old);
                _books.RemoveAt(ix);
                _books.Insert(ix, updated);
                return updated;
            }
        }

        public void SpecialSave(Book book)
        {
            if (book.Title.StartsWith("99"))
            {
                throw new TitleException("Bad title") { MyErrorCode = 99 };
            }
            else if (book.Title.Length == 5)
            {
                throw new TitleException("invalid title length") { MyErrorCode = 5 };
            }
            else if (book.Publisher.StartsWith("42"))
            {
                throw new PublisherException("bad publisher") { MyErrorCode = 11 };
            }
        }

        IEnumerable<Book> IBooksService.Books => _books;

    }
}
