using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookRegistration
{
    /// <summary>
    /// Represents a Registration
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// Creates a Registration
        /// </summary>
        /// <param name="customerID"> Given CustomerID of a Customer </param>
        /// <param name="isbn"> Given ISBN of a Book </param>
        /// <param name="regDate"> Given registration date </param>
        public Registration(int customerID, string isbn, DateTime regDate)
        {
            CustomerID = customerID;
            ISBN = isbn;
            RegDate = regDate;
        }

        /// <summary>
        /// CustomerID of a Customer
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// ISBN of a Book
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Registration date
        /// </summary>
        public DateTime RegDate { get; set; }
    }
}
