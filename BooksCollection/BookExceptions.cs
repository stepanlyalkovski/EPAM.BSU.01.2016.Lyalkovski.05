using System;

namespace BooksCollection
{
    public class BookIsNotFoundException : Exception
    {
        public BookIsNotFoundException()
        {
            
        }

        public BookIsNotFoundException(string message)
            : base(message)
        {
        }

        public BookIsNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class BookIsAlreadyExistException : Exception
    {
        public BookIsAlreadyExistException()
        {
        }

        public BookIsAlreadyExistException(string message)
            : base(message)
        {
        }

        public BookIsAlreadyExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}