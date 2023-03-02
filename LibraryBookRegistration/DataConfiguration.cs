using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryBookRegistration
{
    public class DataConfiguration
    {
        /// <summary>
        /// Removes all leading, trailing white space and within the string
        /// </summary>
        /// <param name="text">the string to have white space removed</param>
        /// <returns>A string with all white space removed</returns>
        public static string RemoveAllWhiteSpace(string text)
        {
            text = text.Trim();
            text = Regex.Replace(text, " ", "");

            return text;
        }

        /// <summary>
        /// Removes dashes from within a isbn
        /// </summary>
        /// <param name="isbn">A isbn in the form of a string</param>
        /// <returns>A isbn string with dashes removed</returns>
        public static string RemoveDashesFromISBN(string isbn)
        {
            return Regex.Replace(isbn, "-", "");
        }
    }
}
