using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookRegistration
{
    /// <summary>
    /// Validates user input
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Checks whether a text box is empty or null
        /// </summary>
        /// <param name="text">text from a text box</param>
        /// <returns>True if there is text in the text box, false if empty or null</returns>
        public static bool IsPresent(TextBox text)
        {
            if (string.IsNullOrEmpty(text.Text)) 
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Checks if user input is in the correct format ex.(mm/dd/yyyy)
        /// </summary>
        /// <param name="dateString">String storing the date</param>
        /// <returns>True if date is valid, false if not</returns>
        public static bool IsValidDate(string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime _))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks whether the entered ISBN is valid
        /// </summary>
        /// <param name="isbn">string storing ISBN</param>
        /// <returns>True if ISBN is valid, false if not valid</returns>
        public static bool IsValidISBN(string isbn)
        {
            // Length must be 10
            int n = isbn.Length;
            if (n != 10)
                return false;

            // Computing weighted sum of
            // first 9 digits
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = isbn[i] - '0';

                if (0 > digit || 9 < digit)
                    return false;

                sum += (digit * (10 - i));
            }

            // Checking last digit.
            char last = isbn[9];
            if (last != 'X' && (last < '0'
                             || last > '9'))
                return false;

            // If last digit is 'X', add 10
            // to sum, else add its value.
            sum += ((last == 'X') ? 10 :
                              (last - '0'));

            // Return true if weighted sum
            // of digits is divisible by 11.
            return (sum % 11 == 0);
        }
        /// <summary>
        /// Checks whether a string is all digits
        /// </summary>
        /// <param name="num">String storing digits</param>
        /// <returns>True if string contains all digits, false if not</returns>
        public static bool IsDigitsOnly(string num)
        {
            if (int.TryParse(num, out _))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Removes white space from the beginning and end of a string 
        /// </summary>
        /// <param name="text">the string to have white space removed</param>
        /// <returns>A string with white space removed from the beginning and end of a string</returns>
        public static string RemoveAllWhiteSpace(string text)
        {
            return text.Trim();
        }
    }
    
}
