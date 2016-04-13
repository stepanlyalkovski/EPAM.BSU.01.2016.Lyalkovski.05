using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using NLog;

namespace BooksCollection
{
    public class XmlBookRepository : IBookRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
        private string path;

        public XmlBookRepository() : this("booksCollection.xml")
        {
        }

        public XmlBookRepository(string filePath)
        {
            path = filePath;
        }

        public IList<Book> Load()
        {
            IList<Book> result;
            logger.Info("Loading books from xml file");
            using (Stream s = File.OpenRead(path))
            {
                result = (IList<Book>) serializer.Deserialize(s);
            }
            logger.Info("Finished loading books from xml file");
            return result;
        }

        public void Save(IList<Book> books)
        {
            logger.Info("Saving books to xml file");
            using (Stream s = File.Create(path))
            {
               serializer.Serialize(s, books);
            }
            logger.Info("Finished saving books to xml file");
        }
    }
}