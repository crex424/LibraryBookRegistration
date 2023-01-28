using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookRegistration
{
    /// <summary>
    /// Represents a Book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Creates a Book with given ISBN, Title, Price
        /// </summary>
        /// <param name="isbn">Given ISBN</param>
        /// <param name="title">Given Title</param>
        /// <param name="price">Given Price</param>
        public Book(string isbn, string title, double price)
        {
            ISBN = isbn;
            Title = title;
            Price = price;
        }

        /// <summary>
        /// The ISBN of a Book
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// The Title of the Book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The price of a Book
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Overrides ToString method and returns formatted information of the Book
        /// </summary>
        /// <returns> A formatted string of ISBN and Book Title and Price</returns>
        public override string ToString()
        {
            return ISBN + ", " + Title + ", " + Price.ToString("C");
        }
    }
}
