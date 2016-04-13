using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using NLog;

namespace BooksCollection
{
    public class BinaryBookRepository : IBookRepository
    {
        private FileInfo booksFile;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public BinaryBookRepository() : this(new FileInfo("books"))
        {
        }

        public BinaryBookRepository(FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException();

            if (!file.Exists)
                booksFile = new FileInfo("books");
            else
                booksFile = file;

        }

        public IList<Book> Load()
        {
            logger.Info($"Load books from {booksFile.Directory}");
            List<Book> books = new List<Book>();
            
            using (var binaryReader = new BinaryReader(booksFile.OpenRead()))
            {
                while (binaryReader.PeekChar() > -1)
                {
                    string title = binaryReader.ReadString();
                    string author = binaryReader.ReadString();
                    string genre = binaryReader.ReadString();
                    DateTime date = DateTime.FromFileTime(binaryReader.ReadInt64());
                    int pages = binaryReader.ReadInt32();
                    decimal price = binaryReader.ReadDecimal();
                    books.Add(new Book(title, author, genre, date, pages, price));
                }
                
            }
            logger.Info("Books has been loaded");
            return books;
        }

        public void Save(IList<Book> books)
        {
            logger.Info($"Save books to \"{booksFile.Directory}\" ");

            File.Delete(booksFile.FullName);
            using (var binaryWriter = new BinaryWriter(booksFile.Create()))
            {
                foreach (var book in books)
                {
                    binaryWriter.Write(book.Title);
                    binaryWriter.Write(book.Author);
                    binaryWriter.Write(book.Genre);
                    binaryWriter.Write(book.PublishDate.ToFileTime());
                    binaryWriter.Write(book.Pages);
                    binaryWriter.Write(book.Price);
                }
            }
            logger.Info("Books has been saved");
        }
    }
}