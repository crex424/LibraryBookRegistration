using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookRegistration
{
    /// <summary>
    /// Represents CRUD Functionality of Customer
    /// </summary>
    public class CustomerDB
    {
        /// <summary>
        /// Adds a Customer to the database
        /// </summary>
        /// <param name="c">The Customer to be added</param>
        public static void Add(Customer c)
        {
            // establish connection to database
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // prepare insert statement
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.Connection = con;
            // Parameterize query
            insertCmd.CommandText = "INSERT INTO Customer(DateOfBirth, FirstName, LastName, Title) " +
                                              "VALUES (@dob, @fName, @lName, @title)";
            insertCmd.Parameters.AddWithValue("@dob", c.DateOfBirth);
            insertCmd.Parameters.AddWithValue("@fName", c.FirstName);
            insertCmd.Parameters.AddWithValue("@lName", c.LastName);
            insertCmd.Parameters.AddWithValue("title", c.Title);

            // open connection to the database
            con.Open();

            // execute insert query
            insertCmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Updates a Customer
        /// </summary>
        /// <param name="c">Customer to be updated</param>
        /// <exception cref="ArgumentException">Thrown if Customer does not exist</exception>
        public static void Update(Customer c)
        {
            // establish connection to database
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // prepare insert statement
            SqlCommand updateCmd = new SqlCommand();
            updateCmd.Connection = con;
            // parameterize query
            updateCmd.CommandText = "UPDATE Customer " +
                                    "SET DateOfBirth = @dob " +
                                    " , FirstName = @fName " +
                                    " , LastName = @lName " +
                                    " , Title = @title " +
                                    "WHERE CustomerID = @customerId";
            updateCmd.Parameters.AddWithValue("@dob", c.DateOfBirth);
            updateCmd.Parameters.AddWithValue("@fName", c.FirstName);
            updateCmd.Parameters.AddWithValue("@lName", c.LastName);
            updateCmd.Parameters.AddWithValue("@title", c.Title);
            updateCmd.Parameters.AddWithValue("@customerId", c.CustomerID);

            // open connection to the database
            con.Open();

            // execute query
            int rows = updateCmd.ExecuteNonQuery();
            if (rows == 0)
            {
                throw new ArgumentException("A Customer with that Id does not exist!");
            }
        }
        /// <summary>
        /// Deletes a Customer
        /// </summary>
        /// <param name="c">The Customer to be deleted</param>
        /// <exception cref="SqlException">Thrown for SQL problem</exception>
        public static void Delete(Customer c)
        {
            if (c.CustomerID == 0)
            {
                throw new ArgumentException("The CustomerID must be populated!");
            }
            Delete(c.CustomerID);
        }
        /// <summary>
        /// Deletes a Customer using CustomerID
        /// </summary>
        /// <param name="customerID"></param>
        /// <exception cref="ArgumentException">Thrown if Customer does not exist</exception>
        /// <exception cref="SqlException">Thrown for SQL problem</exception>
        public static void Delete(int customerID)
        {
            // use "using" statement to close connection automatically
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            SqlCommand deleteCmd = new SqlCommand();
            deleteCmd.Connection = con;
            deleteCmd.CommandText = "DELETE FROM Customer " +
                                    "WHERE CustomerID = @customerID ";
            deleteCmd.Parameters.AddWithValue("@customerID", customerID);

            // Open connection to the database
            con.Open();

            // Execute query
            int rows = deleteCmd.ExecuteNonQuery();
            if (rows == 0)
            {
                throw new ArgumentException("A customer with that id does not exist!");
            }
        }
        /// <summary>
        /// Gets a customer using CustomerID
        /// </summary>
        /// <param name="customerID">The CustomerID used to get Customer</param>
        /// <returns>A Customer</returns>
        public static Customer GetCustomer(int customerID)
        {
            // Get connection
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // Prepare the query 
            SqlCommand selectCmd = new SqlCommand();
            selectCmd.Connection = con;
            selectCmd.CommandText = "SELECT CustomerID, Title, FirstName, LastName, DateOfBirth " +
                                    "FROM Customer " +
                                    "WHERE CustomerID = @customerID ";
            selectCmd.Parameters.AddWithValue("@customerID", customerID);

            // open connection to the database
            con.Open();

            // Execute the query and use results
            SqlDataReader reader = selectCmd.ExecuteReader();

            reader.Read();
            string title = reader["Title"].ToString();
            string fName = reader["FirstName"].ToString();
            string lName = reader["LastName"].ToString();
            DateTime dob = Convert.ToDateTime(reader["DateOfBirth"]);

            Customer currentCustomer = new Customer(title, fName, lName, dob);
            currentCustomer.CustomerID = customerID;

            // Return customer
            return currentCustomer;
        }

        /// <summary>
        /// Gets a list of all customers ordered by last name in
        /// ascending order
        /// </summary>
        /// <returns>a list of all customers ordered by last name in
        /// ascending order</returns>
        public static List<Customer> GetAllCustomers()
        {
            // Get connection
            using SqlConnection con = DBHelper.GetDatabaseConnection();

            // Prepare Query
            SqlCommand selCmd = new SqlCommand();
            selCmd.Connection = con;
            selCmd.CommandText = "SELECT CustomerID, DateOfBirth, FirstName, LastName, Title " +
                "FROM Customer " +
                "ORDER BY LastName";

            con.Open();

            // Execute the query and use results
            SqlDataReader reader = selCmd.ExecuteReader();

            List<Customer> customers = new List<Customer>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["CustomerID"]);
                string fName = reader["FirstName"].ToString();
                string lName = reader["LastName"].ToString();
                string title = reader["Title"].ToString();
                DateTime dob = Convert.ToDateTime(reader["DateOfBirth"]);
                Customer tempCustomer = new Customer(title, fName, lName, dob);
                tempCustomer.CustomerID = id;

                customers.Add(tempCustomer);
            }

            // return customers
            return customers;
        }
    }
}
