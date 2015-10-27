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
            try
            {
                Book book = await _booksService.AddOrUpdateBookAsync(Book);

                Book = book;
            }
            catch (ArgumentNullException)
            {
                var dlg = new MessageDialog("Add vor Speichern");
                await dlg.ShowAsync();
            }
        }

        private async void OnSpecialSave()
        {
            try
            {
                _booksService.SpecialSave(Book);
            }
            catch (TitleException ex) when (ex.MyErrorCode == 99)
            {
                await new MessageDialog("99").ShowAsync();
            }
            catch
            {
                await new MessageDialog("some other error").ShowAsync();
            }
        }

        //private bool FilterError(Exception ex)
        //{
        //    return false;
        //}


    }
}
