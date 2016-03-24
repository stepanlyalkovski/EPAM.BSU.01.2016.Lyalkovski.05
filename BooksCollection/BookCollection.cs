using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using NLog;

namespace BooksCollection
{
    public class BookCollection
    {
        private List<Book> books = new List<Book>();
        private IBooksStorage bookStorage = new BinaryFileStorage();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void AddBook(Book book)
        {
            if (object.ReferenceEquals(null, book))
                throw new NoNullAllowedException();

            if (books.Contains(book))
            {
                logger.Warn($"book {book.Title} is already exist");
                throw new BookIsAlreadyExistException("Book is already exist in this collection!");
            }
           

            books.Add(book);
             
        }

        public void RemoveBook(Book book)
        {
            if (object.ReferenceEquals(null, book))
                throw new NoNullAllowedException();

            if (!books.Remove(book))
            {
                logger.Warn($"book {book.Title} is not found");
                throw new BookIsNotFoundException();
            }
            
        }

        public Book FindByTag(string title)
        {
            Book searchedBook = books.FirstOrDefault(b => b.Title == title);
            return searchedBook;
        }

        public Book FindByTag(string title, string author)
        {
            Book searchedBook = books.FirstOrDefault(b => b.Author == author && b.Title == title);
            return searchedBook;
        }

        public Book FindByTag(decimal price)
        {
            Book searchedBook = books.FirstOrDefault(b => b.Price == price);
            return searchedBook;
        }

        public void SortBooksByTag()
        {

        }

        public void AddBooksStorage(IBooksStorage storage)
        {
            bookStorage = storage;
        }

        public void SaveBooks() => bookStorage.SaveBookCollection(books);

        public void LoadBooks() => books = bookStorage.LoadBookCollection();

    }
}