using BooksSample.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BooksSample.Views
{
    public sealed partial class BooksView : UserControl
    {
        public BooksView()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        private BooksViewModel _viewModel;

        public BooksViewModel ViewModel =>
            _viewModel ?? (_viewModel = new BooksViewModel((App.Current as App).BooksService));

    }
}
