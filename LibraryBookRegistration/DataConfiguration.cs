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
        /// Removes white space from the beginning and end of a string 
        /// </summary>
        /// <param name="text">the string to have white space removed</param>
        /// <returns>A string with white space removed from the beginning and end of a string</returns>
        public static string RemoveWhiteSpace(string text)
        {
            return text.Trim();
        }
    }
}
