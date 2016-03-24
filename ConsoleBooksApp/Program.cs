using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksCollection;

namespace ConsoleBooksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BookCollection collection = new BookCollection();
            Book book = new Book("Title", "author", "genre", DateTime.Now, 150, 20);
            collection.AddBook(book);
            collection.SaveBooks();
            BookCollection resCollection = new BookCollection();
            File.Create("Collection");
            FileInfo file = new FileInfo("Collection");
            IBooksStorage st = new BinaryFileStorage();
            
            resCollection.LoadBooks();

        }
    }
}
