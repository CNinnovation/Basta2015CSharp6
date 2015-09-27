using BooksSample.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BooksSample.Views
{
    public sealed partial class BookView : UserControl
    {
        public BookView()
        {
            this.InitializeComponent();
        }

        private BookViewModel _viewModel;
        public BookViewModel ViewModel
        {
            get
            {
                return _viewModel ?? (_viewModel = new BookViewModel((App.Current as App).BooksService));
            }
        }
    }
}
