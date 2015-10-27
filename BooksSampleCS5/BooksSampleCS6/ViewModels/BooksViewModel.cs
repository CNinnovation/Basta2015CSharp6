using BooksSample.Contracts;
using BooksSample.Events;
using BooksSample.Framework;
using BooksSample.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace BooksSample.ViewModels
{
    public class BooksViewModel : ViewModelBase
    {
        private IBooksService _booksService;

        public BooksViewModel(IBooksService booksService)
        {
            _booksService = booksService;
            GetBooksCommand = new DelegateCommand(OnGetBooks, CanGetBooks);
            AddBookCommand = new DelegateCommand(OnAddBook);
        }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                if (SetProperty(ref _selectedBook, value))
                {
                    EventAggregator<BookInfoEvent>.Instance.Publish(this, new BookInfoEvent(_selectedBook.BookId));
                }
            }
        }

        // DONE
        public IEnumerable<Book> Books => _booksService.Books;

        public ICommand GetBooksCommand { get; }

        // DONE
        public async void OnGetBooks()
        {
            (GetBooksCommand as DelegateCommand)?.RaiseCanExecuteChanged();
            await _booksService.LoadBooksAsync();

            _canGetBooks = true;
            (GetBooksCommand as DelegateCommand)?.RaiseCanExecuteChanged();
        }

        private bool _canGetBooks = true;

        // DONE
        public bool CanGetBooks() => _canGetBooks;


        private void OnAddBook()
        {
            EventAggregator<BookInfoEvent>.Instance.Publish(this, new BookInfoEvent(0));
        }

        public ICommand AddBookCommand { get; }
    }
}
