using System;

namespace BooksSample.Errors
{
    public class TitleException : Exception
    {
        public TitleException() { }
        public TitleException(string message) : base(message) { }
        public TitleException(string message, Exception inner) : base(message, inner) { }

        public int MyErrorCode { get; set; }
    }

    public class PublisherException : Exception
    {
        public PublisherException() { }
        public PublisherException(string message) : base(message) { }
        public PublisherException(string message, Exception inner) : base(message, inner) { }

        public int MyErrorCode { get; set; }
    }
}
