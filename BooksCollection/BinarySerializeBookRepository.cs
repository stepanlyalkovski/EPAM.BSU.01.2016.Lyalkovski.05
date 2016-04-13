using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NLog;

namespace BooksCollection
{
    public class BinarySerializeBookRepository : IBookRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IFormatter formatter = new BinaryFormatter();
        private string path;

        public BinarySerializeBookRepository() : this("booksCollection.bin")
        {
        }

        public BinarySerializeBookRepository(string filePath)
        {
            path = filePath;
        }

        public IList<Book> Load()
        {
            
            using (FileStream s = File.Create(path))
            {
                logger.Info($"Start load serialized books from {s.Name}");
                var result = formatter.Deserialize(s);
                logger.Info("Deserialize books");
                return (List<Book>) result;
            }
        }

        public void Save(IList<Book> books)
        {
            
            using (FileStream s = File.Create(path))
            {
                logger.Info($"Start save serialized books to {s.Name}");
                formatter.Serialize(s, books);              
            }
            logger.Info("Books was serialized");
        }
    }
}