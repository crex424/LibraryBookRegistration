using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookRegistration
{
    /// <summary>
    /// Represents a customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Creates a customer
        /// </summary>
        /// <param name="title">Customers title</param>
        /// <param name="fName">Customers legal first name</param>
        /// <param name="lName">Customers legal last name</param>
        /// <param name="dob">Customers legal date of birth</param>
        public Customer(string title, string fName, string lName, DateTime dob)
        {
            Title = title;
            FirstName = fName;
            LastName = lName;
            DateOfBirth = dob;
        }

        /// <summary>
        /// The customers ID
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// The customers legal first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The customers legal last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The customers legal title ex.(Mr, Mrs, Dr)
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The customers legal date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The users formatted full name. ex.(LastName, FirstName)
        /// </summary>
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        /// <summary>
        /// Overrides ToString method and returns formatted information of the customer
        /// </summary>
        /// <returns> A formatted string of customers title full name and date of birth 
        /// ex.(Title. FullName DateOfBirth)</returns>
        public override string ToString()
        {
            return Title + ". " + FullName + " " + DateOfBirth.ToShortDateString();
        }
    }
}
