using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using NLog;

namespace BooksCollection
{
    public class BookService
    {
        private List<Book> bookList;
        private readonly IRepository repository;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public BookService(IEnumerable<Book> bookList, IRepository repository)
        {
            this.bookList = bookList.ToList();
            this.repository = repository;
        }

        public void AddBook(Book book)
        {
            if (object.ReferenceEquals(null, book))
                throw new NoNullAllowedException();

            if (bookList.Contains(book))
            {
                logger.Warn($"book {book.Title} is already exist");
                throw new BookIsAlreadyExistException("Book is already exist in this collection!");
            }

            bookList.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (object.ReferenceEquals(null, book))
                throw new NoNullAllowedException();

            if (!bookList.Remove(book))
            {
                logger.Warn($"book {book.Title} is not found");
                throw new BookIsNotFoundException();
            }

        }

        public Book FindByTag(string title)
        {
            Book searchedBook = bookList.FirstOrDefault(b => b.Title == title);
            return searchedBook;
        }

        public Book FindByTag(string title, string author)
        {
            Book searchedBook = bookList.FirstOrDefault(b => b.Author == author && b.Title == title);
            return searchedBook;
        }

        public Book FindByTag(decimal price)
        {
            Book searchedBook = bookList.FirstOrDefault(b => b.Price == price);
            return searchedBook;
        }

        public class BookCompAdapter : IComparer<Book>
        {
            private readonly Comparison<Book> comparison;

            public BookCompAdapter(Comparison<Book> compare)
            {
                this.comparison = compare;
            }

            public int Compare(Book x, Book y)
            {
                return comparison(x, y);
            }
        }

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            bookList.Sort(comparer);
        }

        public void SortBooksByTag(Comparison<Book> comparison)
        {
            BookCompAdapter compAdapter = new BookCompAdapter(comparison);
            SortBooksByTag(compAdapter);
        }

        public void SaveBooks() => repository.Save(bookList);

        public void LoadBooks() => bookList = repository.Load().ToList();

    }

}