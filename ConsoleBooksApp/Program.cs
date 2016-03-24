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
            Book book1 = new Book("NewTitle", "author", "genre", DateTime.Now, 150, 20);
            collection.AddBook(book);
            try
            {
                collection.AddBook(book);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            try
            {
                collection.RemoveBook(book1);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            collection.SaveBooks();
            BookCollection resCollection = new BookCollection();
            File.Create("Collection");
            FileInfo file = new FileInfo("Collection");
            IBooksStorage st = new BinaryFileStorage();
            
            resCollection.LoadBooks();

        }
    }
}
