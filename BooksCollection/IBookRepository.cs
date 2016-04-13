using System.Collections.Generic;

namespace BooksCollection
{
    public interface IBookRepository
    {
        IList<Book> Load();
        void Save(IList<Book> books);
    }

}