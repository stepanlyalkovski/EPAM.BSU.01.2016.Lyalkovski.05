using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BooksCollection
{
    public class BinaryFileStorage : IBooksStorage
    {
        private FileInfo booksFile;

        public BinaryFileStorage() : this(new FileInfo("books"))
        {
        }

        public BinaryFileStorage(FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException();

            if (!file.Exists)
                booksFile = new FileInfo("books");
            else
                booksFile = file;

        }

        public List<Book> LoadBookCollection()
        {
            List<Book> books = new List<Book>();
            using (var binaryReader = new BinaryReader(booksFile.OpenRead()))
            {
                while (binaryReader.PeekChar() > -1)
                {
                    string title = binaryReader.ReadString();
                    string author = binaryReader.ReadString();
                    string genre = binaryReader.ReadString();
                    DateTime date = DateTime.Parse(binaryReader.ReadString());
                    int pages = binaryReader.ReadInt32();
                    int price = binaryReader.ReadInt32();
                    books.Add(new Book(title, author, genre, date, pages, price));
                }
                
            }
            return books;
        }

        public void SaveBookCollection(List<Book> books)
        {
            using (var binaryWriter = new BinaryWriter(booksFile.Create()))
            {
                foreach (var book in books)
                {
                    binaryWriter.Write(book.Title);
                    binaryWriter.Write(book.Author);
                    binaryWriter.Write(book.Genre);
                    binaryWriter.Write(book.PublishDate.ToString(CultureInfo.InvariantCulture));
                    binaryWriter.Write(book.Pages);
                    binaryWriter.Write(book.Price);
                }
            }
        }
    }
}