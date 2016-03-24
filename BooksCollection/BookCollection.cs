using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BooksCollection
{
    public class BookCollection
    {
        private List<Book> books = new List<Book>();
        private IBooksStorage bookStorage = new BinaryFileStorage();

        public void AddBook(Book book)
        {
            if (object.ReferenceEquals(null, book))
                throw new NullReferenceException();

            if (books.Contains(book))
                return;

            books.Add(book);
             
        }

        public void RemoveBook(Book book)
        {
            if (object.ReferenceEquals(null, book))
                throw new NullReferenceException();

            if (books.Remove(book))
                return;
        }

        public Book FindByTag(string title)
        {
            Book searchedBook = books.FirstOrDefault(b => b.Title == title);
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