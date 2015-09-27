using BooksSample.Framework;

namespace BooksSample.Models
{
    public class Book : BindableBase
    {
        public Book(int bookId)
        {
            _bookId = bookId;
            Title = string.Empty;
            Publisher = string.Empty;
            Author = "Christian Nagel";
        }

        // TODO: 02 - getter-only auto property
        private readonly int _bookId;
        public int BookId
        {
            get
            {
                return _bookId;
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _publisher;
        public string Publisher
        {
            get { return _publisher; }
            set { SetProperty(ref _publisher, value); }
        }

        // TODO: 01 - auto property initializer
        public string Author { get; set; }

        // TODO: 07 - string interpolation
        // TODO: 04 - expression bodied member : method
        public override string ToString()
        {
            return string.Format("{0}, {1}", Title, Publisher);
        }

    }
}
