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
        public string Author { get; }
        public string Genre { get; }
        public DateTime PublishDate { get; }
        public int Pages { get; }
        public decimal Price { get; }

        public Book(string title, string author, string genre, DateTime publishDate, int pages, decimal price)
        {
            Title = title;
            Author = author;
            Genre = genre;
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
                   && Author.Equals(other.Author)
                   && Genre.Equals(other.Genre)
                   && PublishDate.Equals(other.PublishDate)
                   && Pages == other.Pages
                   && Price == other.Price;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Author != null ? Author.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Genre != null ? Genre.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PublishDate.GetHashCode();
                hashCode = (hashCode * 397) ^ Pages;
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                return hashCode;
            }
        }
    }
}
