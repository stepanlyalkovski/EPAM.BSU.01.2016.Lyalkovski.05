using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCollection
{
    public class Book : IEquatable<Book>
    {
        public string Title { get; }
        public List<string> Authors { get; }
        public List<string> Genres { get; }
        public DateTime PublishDate { get; }
        public int Pages { get; }
        public decimal Price { get; }

        public Book()
        {
        }

        public Book(string title, List<string> authors, List<string> genres, DateTime publishDate, int pages, decimal price)
        {
            Title = title;
            Authors = authors;
            Genres = genres;
            PublishDate = publishDate;
            Pages = pages;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            return Equals((Book)obj);
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return string.Equals(Title, other.Title)
                   && Authors.SequenceEqual(other.Authors)
                   && Genres.SequenceEqual(other.Genres)
                   && PublishDate.Equals(other.PublishDate)
                   && Pages == other.Pages
                   && Price == other.Price;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Authors != null ? Authors.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Genres != null ? Genres.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PublishDate.GetHashCode();
                hashCode = (hashCode * 397) ^ Pages;
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                return hashCode;
            }
        }
    }
}
