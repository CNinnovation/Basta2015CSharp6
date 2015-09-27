using System;

namespace BooksSample.Events
{
    public class BookInfoEvent : EventArgs
    {
        public BookInfoEvent(int bookId)
        {
            BookId = bookId;
        }

        // TODO:  02 readonly auto property
        public int BookId { get; }
    }
}
