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

        /// <summary>
        /// fomalize a single/multiple-word name/title
        /// by removing all leading and trailing white-space characters
        /// and replacing multiple spaces by single space within a name/title
        /// </summary>
        /// <param name="name">Name/Title to be formalized</param>
        /// <returns>Formalized Name/Title with properly capitalized and unnecessary spaces </returns>
        public static string FormalizeName(string name)
        {
            // remove all leading and trailing white-space characters
            name = name.Trim();

            // replace multiple spaces with single space within a name
            name = Regex.Replace(name, " {2,}", " ");

            // properly capitalize multiple-word name
            name = Regex.Replace(name, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
            return name;
        }
    }
}
