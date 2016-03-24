using System.Collections.Generic;

namespace BooksCollection
{
    public interface IBooksStorage
    {
        List<Book> LoadBookCollection();
        void SaveBookCollection(List<Book> books);
    }

}