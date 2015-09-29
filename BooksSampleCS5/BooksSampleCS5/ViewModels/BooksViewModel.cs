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

        // TODO: 04 - expression bodied member: property
        public IEnumerable<Book> Books
        {
            get
            {
                return _booksService.Books;
            }
        } 
        public ICommand GetBooksCommand { get; }

        // TODO: 08 - Elvis operator
        public async void OnGetBooks()
        {
            await _booksService.LoadBooksAsync();

            _canGetBooks = true;
            DelegateCommand command = GetBooksCommand as DelegateCommand;
            if (command != null)
            {
                command.RaiseCanExecuteChanged();
            }
        }

        private bool _canGetBooks = true;

        public bool CanGetBooks()
        {
            return _canGetBooks;
        }

        private void OnAddBook()
        {
            EventAggregator<BookInfoEvent>.Instance.Publish(this, new BookInfoEvent(0));
        }

        public ICommand AddBookCommand { get; }
    }
}
