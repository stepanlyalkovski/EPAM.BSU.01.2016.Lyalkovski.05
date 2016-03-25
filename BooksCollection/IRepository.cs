using System.Collections.Generic;

namespace BooksCollection
{
    public interface IRepository
    {
        IEnumerable<Book> Load();
        void Save(List<Book> books);
    }

}