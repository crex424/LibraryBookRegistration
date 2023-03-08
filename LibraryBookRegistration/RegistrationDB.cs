using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookRegistration
{
    /// <summary>
    /// Adds Registration to database
    /// </summary>
    /// <param name="r">Registration to be added</param>
    public class RegistrationDB
    {
        public static void Add(Registration r)
        {
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // prepare insert statement
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.Connection = con;
            // parameterized query
            insertCmd.CommandText = "INSERT INTO Registration (CustomerID, ISBN, RegDate) " +
                                                      "VALUES (@customerID, @isbn, @regDate) ";
            insertCmd.Parameters.AddWithValue("@customerID", r.CustomerID);
            insertCmd.Parameters.AddWithValue("@isbn", r.ISBN);
            insertCmd.Parameters.AddWithValue("@regDate", r.RegDate);

            // open connection to the database
            con.Open();

            // execute insert qury
            insertCmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes a Registration from database
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="isbn"></param>
        public static void Delete(int customerID, string isbn)
        {
            // use "using" statement to close connection automatically
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            SqlCommand deleteCmd = new SqlCommand();
            deleteCmd.Connection = con;
            deleteCmd.CommandText = "DELETE FROM Registration " +
                                    "WHERE CustomerID = @customerID " +
                                    "  AND ISBN = @isbn ";
            deleteCmd.Parameters.AddWithValue("@customerID", customerID);
            deleteCmd.Parameters.AddWithValue("@isbn", isbn);

            // Open connection to the database
            con.Open();

            // Execute query
            deleteCmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Get a registration from database
        /// </summary>
        /// <param name="r">Registration to be retrieved</param>
        /// <returns></returns>
        public static Registration GetRegistration(Registration r)
        {
            Registration currReg = GetRegistration(r.CustomerID, r.ISBN);

            return currReg;
        }

        /// <summary>
        /// Get a registration from database by CustomerID and ISBN
        /// </summary>
        /// <param name="customerID">CustomerID of the Customer</param>
        /// <param name="isbn">ISBN of the book</param>
        /// <returns>Registration</returns>
        public static Registration GetRegistration(int customerID, string isbn)
        {
            // Get connection
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // Prepare the query 
            SqlCommand selectCmd = new SqlCommand();
            selectCmd.Connection = con;
            selectCmd.CommandText = "SELECT CustomerID, ISBN, RegDate " +
                                    "FROM Registration " +
                                    "WHERE CustomerID = @customerID " +
                                    "        AND ISBN = @isbn ";
            selectCmd.Parameters.AddWithValue("@customerID", customerID);
            selectCmd.Parameters.AddWithValue("@isbn", isbn);

            // open connection to the database
            con.Open();

            // Execute the query and use results
            SqlDataReader reader = selectCmd.ExecuteReader();

            DateTime regDate = Convert.ToDateTime(reader["RegDate"]);

            Registration currReg = new Registration(customerID, isbn, regDate);

            return currReg;
        }

        /// <summary>
        /// Gets a list of all Registrations
        /// </summary>
        /// <returns>List of registrations</returns>
        public static List<Registration> GetAllRegistrations()
        {
            // Get connection
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // Prepare the query 
            SqlCommand selectCmd = new SqlCommand();
            selectCmd.Connection = con;
            selectCmd.CommandText = "SELECT CustomerID, ISBN, RegDate " +
                                    "FROM Registration " +
                                    "ORDER BY CustomerID, ISBN, RegDate ";

            // open connection to the database
            con.Open();

            // Execute the query and use results
            SqlDataReader reader = selectCmd.ExecuteReader();

            List<Registration> registrations = new();

            while (reader.Read())
            {
                int customerID = Convert.ToInt32(reader["CustomerID"]);
                string isbn = reader["ISBN"].ToString();
                DateTime regDate = Convert.ToDateTime(reader["RegDate"]);

                Registration tempReg = new Registration(customerID, isbn, regDate);
                registrations.Add(tempReg);
            }

            // Return list of Customers
            return registrations;
        }

        /// <summary>
        /// Gets a list of registrations of a Customer
        /// </summary>
        /// <param name="customerID">CustomerID of the Customer to get list</param>
        /// <returns>List of registrations of a Customer</returns>
        public static List<Registration> GetRegistrationsByCustomerID(int customerID)
        {
            // Get connection
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // Prepare the query 
            SqlCommand selectCmd = new SqlCommand();
            selectCmd.Connection = con;
            selectCmd.CommandText = "SELECT CustomerID, ISBN, RegDate " +
                                    "FROM Registration " +
                                    "WHERE CustomerID = @customerID " +
                                    "ORDER BY ISBN, RegDate ";
            selectCmd.Parameters.AddWithValue("@customerID", customerID);

            // open connection to the database
            con.Open();

            // Execute the query and use results
            SqlDataReader reader = selectCmd.ExecuteReader();

            List<Registration> registrationsByCustomerID = new();

            while (reader.Read())
            {
                string isbn = reader["ISBN"].ToString();
                DateTime regDate = Convert.ToDateTime(reader["RegDate"]);

                Registration tempReg = new Registration(customerID, isbn, regDate);
                registrationsByCustomerID.Add(tempReg);
            }

            // Return list of Registrations filtered by CustomerID
            return registrationsByCustomerID;
        }

        /// <summary>
        /// Add a registration to database
        /// </summary>
        /// <param name="r">Registration to be added</param>
        /// <returns>True if adding successfully</returns>
        public static bool RegisterBook(Registration r)
        {
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // prepare insert statement
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.Connection = con;
            // parameterized query
            insertCmd.CommandText = "INSERT INTO Registration (CustomerID, ISBN, RegDate) " +
                                                      "VALUES (@customerID, @isbn, @regDate) ";
            insertCmd.Parameters.AddWithValue("@customerID", r.CustomerID);
            insertCmd.Parameters.AddWithValue("@isbn", r.ISBN);
            insertCmd.Parameters.AddWithValue("@regDate", r.RegDate);

            // open connection to the database
            con.Open();

            // execute insert qury
            int rows = insertCmd.ExecuteNonQuery();

            return rows != 0;
        }

        /// <summary>
        /// Counts Registrations of a Customer
        /// </summary>
        /// <param name="customerID">CustomerID of the Customer</param>
        /// <returns>Counts Registrations of a Customer</returns>
        public static int CountRegistrationsGroupByCustomerID(int customerID)
        {
            // Get connection
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // Prepare the query 
            SqlCommand selectCmd = new SqlCommand();
            selectCmd.Connection = con;
            selectCmd.CommandText = "SELECT CustomerID, COUNT(ISBN) AS CountRegistrationsGroupByCustomerID " +
                                    "FROM Registration " +
                                    "WHERE CustomerID = @customerID " +
                                    "GROUP BY CustomerID ";
            selectCmd.Parameters.AddWithValue("@customerID", customerID);

            // open connection to the database
            con.Open();

            // Execute the query and use results
            SqlDataReader reader = selectCmd.ExecuteReader();

            int countRegistrationsGroupByCustomerID;

            try
            {
                reader.Read();
                countRegistrationsGroupByCustomerID = Convert.ToInt32(reader["CountRegistrationsGroupByCustomerID"]);
            }
            catch (InvalidOperationException)
            {
                countRegistrationsGroupByCustomerID = 0;
            }

            // Return list of Customers
            return countRegistrationsGroupByCustomerID;
        }
        /// <summary>
        /// Counts how many customers have registered with a specific books
        /// ISBN.
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns>Count of how many customers have registered with a specific books ISBN</returns>
        public static int CountRegistrationsGroupByISBN(string isbn)
        {
            // Get connection
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // Prepare the query 
            SqlCommand selectCmd = new SqlCommand();
            selectCmd.Connection = con;
            selectCmd.CommandText = "SELECT ISBN, COUNT(CustomerID) AS CountRegistrationsGroupByISBN " +
                                    "FROM Registration " +
                                    "WHERE ISBN = @isbn " +
                                    "GROUP BY ISBN ";
            selectCmd.Parameters.AddWithValue("@isbn", isbn);

            // open connection to the database
            con.Open();

            // Execute the query and use results
            SqlDataReader reader = selectCmd.ExecuteReader();

            int countRegistrationsGroupByISBN;

            try
            {
                reader.Read();
                countRegistrationsGroupByISBN = Convert.ToInt32(reader["CountRegistrationsGroupByISBN"]);
            }
            catch (InvalidOperationException)
            {
                countRegistrationsGroupByISBN = 0;
            }

            // Return list of Customers
            return countRegistrationsGroupByISBN;
        }
    }
}
