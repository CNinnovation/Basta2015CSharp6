using BooksSample.Contracts;
using BooksSample.Errors;
using BooksSample.Events;
using BooksSample.Framework;
using BooksSample.Models;
using System;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Popups;

namespace BooksSample.ViewModels
{
    public enum EditBookMode
    {
        Edit,
        AddNew
    }

    public class BookViewModel : ViewModelBase, IDisposable
    {
        private IBooksService _booksService;
        public BookViewModel(IBooksService booksService)
        {
            _booksService = booksService;

            SaveBookCommand = new DelegateCommand(OnSaveBook);
            SpecialSaveCommand = new DelegateCommand(OnSpecialSave);

            EventAggregator<BookInfoEvent>.Instance.Event += LoadBook;
        }

        public ICommand SaveBookCommand { get; }
        public ICommand SpecialSaveCommand { get; }

        private void LoadBook(object sender, BookInfoEvent bookInfo)
        {
            if (bookInfo.BookId == 0)
            {
                int bookId = _booksService.Books.Select(b => b.BookId).Max() + 1;
                Book = new Book(bookId);
            }
            else
            {
                Book = _booksService.GetBook(bookInfo.BookId);
            }
        }

        public void Dispose()
        {
            EventAggregator<BookInfoEvent>.Instance.Event -= LoadBook;
        }

        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { SetProperty(ref _book, value); }
        }

        // TODO: 05 - await in catch
        private async void OnSaveBook()
        {
            bool hasError = false;
            string errorMessage = string.Empty;

            try
            {
                Book book = await _booksService.AddOrUpdateBookAsync(Book);

                Book = book;
            }
            catch (ArgumentNullException)
            {
                hasError = true;
                errorMessage = "Add vor Speichern";
            }
            if (hasError)
            {
                var dlg = new MessageDialog(errorMessage);
                await dlg.ShowAsync();
            }
        }

        // TODO: 06 - exception filter
        private async void OnSpecialSave()
        {
            bool hasError = false;
            string errorMessage = string.Empty;

            try
            {
                _booksService.SpecialSave(Book);
            }
            catch (TitleException ex)
            {
                if (ex.MyErrorCode != 99)
                {
                    throw;
                }
                hasError = true;
                errorMessage = "99";
            }
            catch
            {
                hasError = true;
                errorMessage = "some other error";
            }

            if (hasError)
            {
                await new MessageDialog(errorMessage).ShowAsync();
            }
        }

        private bool FilterError(Exception ex)
        {
            return false;
        }


    }
}
