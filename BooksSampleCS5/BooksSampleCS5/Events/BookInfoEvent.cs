using System;

namespace BooksSample.Events
{
    public class BookInfoEvent : EventArgs
    {
        public BookInfoEvent(int bookId)
        {
            _bookId = bookId;
        }

        private readonly int _bookId;

        // TODO:  02 readonly auto property
        public int BookId
        {
            get { return _bookId; }
        }

    }
}
