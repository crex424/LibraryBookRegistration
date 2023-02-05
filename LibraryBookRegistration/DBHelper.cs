using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookRegistration
{
    /// <summary>
    /// Represents Database Helper tools
    /// </summary>
    public class DBHelper
    {
        /// <summary>
        /// Creates a connection with given local database name
        /// </summary>
        /// <param name="dbo">Given database name</param>
        /// <returns>Connection with given local database name</returns>
        public static SqlConnection GetDatabaseConnection(string dbo)
        {
            // establish connection to database
            return new SqlConnection("Data Source=localhost;Initial Catalog=" + dbo + ";Integrated Security=True");
        }

        /// <summary>
        /// Creates a connection with the default local database named "BookRegistration"
        /// </summary>
        /// <returns>Connection with "BookRegistration"</returns>
        public static SqlConnection GetDatabaseConnection()
        {
            // establish connection to database
            return new SqlConnection("Data Source=localhost;Initial Catalog=" + "BookRegistration" + ";Integrated Security=True");
        }
    }
}
